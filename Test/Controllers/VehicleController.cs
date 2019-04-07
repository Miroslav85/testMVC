using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test.Models;
using PagedList;
namespace Test.Controllers
{
	public class VehicleController : Controller
	{
		vjezbaEntities db = new vjezbaEntities();
		// GET: Vehicle
		public ActionResult Index()

		{

			List<VehicleMake> list = new List<VehicleMake>();
			using (db)
			{
			 list=	db.VehicleMake.ToList();
			}
			var sort = list.OrderBy(x => x.Name).ToList() ;
			return View(sort);
		}

		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			VehicleMake vehicleMake = db.VehicleMake.Find(id);
			if (vehicleMake == null)
			{
				return HttpNotFound();
			}
			return View(vehicleMake);
		}

		public ActionResult create()
		{
			
			return View();
		}
		[HttpPost]
		public ActionResult create( VehicleMake v)
		{
			using (db)
			{
				db.VehicleMake.Add(v);
				db.SaveChanges();
			}
			return View();
			
		}

		public ActionResult edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			VehicleMake vehicleMake = db.VehicleMake.Find(id);
			if (vehicleMake == null)
			{
				return HttpNotFound();
			}
			return View(vehicleMake);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Name")] VehicleMake vehicleMake)
		{
			if (ModelState.IsValid)
			{
				db.Entry(vehicleMake).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(vehicleMake);
		}

		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			VehicleMake vehicleMake = db.VehicleMake.Find(id);
			if (vehicleMake == null)
			{
				return HttpNotFound();
			}
			return View(vehicleMake);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)

		{
			

			List <VehicleModel>modeli = db.VehicleModel.ToList();

			VehicleMake vehicleMake = db.VehicleMake.Find(id);
			int modelID = vehicleMake.Id;


			foreach (var i in modeli)
			{
				if (i.MakeId==modelID)
				{
					db.VehicleModel.Remove(i);
					
				}
			}

			
			
			db.VehicleMake.Remove(vehicleMake);
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