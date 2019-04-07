

create database vjezba


use vjezba


create table VehicleMake
(
Id int primary key identity(1,1),
 Name nvarchar(30)

)

Insert into VehicleMake values ('BMW')
Insert into VehicleMake values ('Ford')
Insert into VehicleMake values ('Opel')


create table VehicleModel
(
Id int primary key identity(1,1),
MakeId int,
Name  nvarchar(30),

  FOREIGN KEY (MakeId)  REFERENCES VehicleMake(Id)

) 
insert into VehicleModel values(1,'x5')
insert into VehicleModel values(2,'Orion 1.6b')

insert into VehicleModel values(3,'Calibra')


















create proc Izmjeni
@id int,
@marka nvarchar(30),
@gorivo nvarchar(30),
@model nvarchar(30),
@Boja nvarchar(30)
as
UPDATE 
  Vozilo
  
SET 
  Vozilo.MarkaVozila=@marka,
  Vozilo.Gorivo=@gorivo

  from 
  Vozilo ,ModelVozila

WHERE 
 
  Vozilo.IDVozila =  ModelVozila.VoziloID
  and IDVozila=@id

update ModelVozila

set
 ModelVozila.ModelV=@model,
 ModelVozila.BojaVoZila=@Boja
 from
 Vozilo,ModelVozila
 where
  ModelVozila.VoziloID=Vozilo.IDVozila
  and VoziloID=@id





create proc PrikazZaModeliBoju
as
select VoziloID,ModelV,BojaVoZila,IDVozila,MarkaVozila,Gorivo

from ModelVozila 
Right Join Vozilo
on ModelVozila.VoziloID=Vozilo.IDVozila where VoziloID is null 




CREATE PROCEDURE UbaciModel
(   @VoziloID INT ,

   @ModelV nvarchar(30),
 @BojaVoZila nvarchar(30)
  
)
AS
BEGIN
   insert into ModelVozila values ( @VoziloID,@ModelV,@BojaVoZila)
   
END
GO




   create proc vratiVozila
   (
   @ID int
   )
   as
  select VoziloID,ModelV,BojaVoZila,IDVozila,MarkaVozila,Gorivo

from ModelVozila 
Right Join Vozilo
on ModelVozila.VoziloID=Vozilo.IDVozila where IDVozila=@ID







create proc PronadjiID
 @idV int
as

select * from Vozilo
where IDVozila=@idV



create proc SamoVozila
as
SELECT * from Vozilo


exec SvaVozila

create proc UbaciVozilo
(   
 @MarkaVozila nvarchar(30),

   @Gorivo nvarchar(30)
)
AS
BEGIN
   insert into Vozilo values ( @MarkaVozila,@Gorivo)
   
END
GO
drop proc SvaVozila


Create proc SvaVozila
as
SELECT Vozilo.MarkaVozila, Gorivo,ModelVozila.BojaVoZila,ModelVozila.ModelV, VoziloID
FROM Vozilo
INNER JOIN   ModelVozila
ON  Vozilo.IDVozila=ModelVozila.VoziloID

select * from ModelVozila

select Vozilo.MarkaVozila,ModelVozila.ModelV , Gorivo,ModelVozila.BojaVoZila
from Vozilo  inner join ModelVozila on Vozilo.IDVozila=ModelVozila.VoziloID where MarkaVozila='mercedes'