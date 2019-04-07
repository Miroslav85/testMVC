using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
	public class VehicleModelsController : Controller
	{
		private vjezbaEntities db = new vjezbaEntities();

		// GET: VehicleModels
		public ActionResult Index()
		{
			
			var vehicleModel = db.VehicleModel.Include(v => v.VehicleMake);
		var sort=	vehicleModel.OrderBy(x => x.VehicleMake.Name).ToList() ;

			return View(sort);
		}

		// GET: VehicleModels/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			VehicleModel vehicleModel = db.VehicleModel.Find(id);
			if (vehicleModel == null)
			{
				return HttpNotFound();
			}
			return View(vehicleModel);
		}

		// GET: VehicleModels/Create
		public ActionResult Create()
		{
			ViewBag.MakeId = new SelectList(db.VehicleMake, "Id", "Name");
			return View();
		}

		// POST: VehicleModels/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,MakeId,Name")] VehicleModel vehicleModel)
		{
			if (ModelState.IsValid)
			{
				db.VehicleModel.Add(vehicleModel);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.MakeId = new SelectList(db.VehicleMake, "Id", "Name", vehicleModel.MakeId);
			return View(vehicleModel);
		}

		// GET: VehicleModels/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			VehicleModel vehicleModel = db.VehicleModel.Find(id);
			if (vehicleModel == null)
			{
				return HttpNotFound();
			}
			ViewBag.MakeId = new SelectList(db.VehicleMake, "Id", "Name", vehicleModel.MakeId);
			return View(vehicleModel);
		}

		// POST: VehicleModels/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,MakeId,Name")] VehicleModel vehicleModel)
		{
			if (ModelState.IsValid)
			{
				db.Entry(vehicleModel).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.MakeId = new SelectList(db.VehicleMake, "Id", "Name", vehicleModel.MakeId);
			return View(vehicleModel);
		}

		// GET: VehicleModels/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			VehicleModel vehicleModel = db.VehicleModel.Find(id);
			if (vehicleModel == null)
			{
				return HttpNotFound();
			}
			return View(vehicleModel);
		}

		// POST: VehicleModels/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			VehicleModel vehicleModel = db.VehicleModel.Find(id);
			db.VehicleModel.Remove(vehicleModel);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
