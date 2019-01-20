begin Tran t1;
alter table AnimalGroups
ADD  RowVersion INT Default 1 not null;
alter table Animals
ADD  RowVersion INT Default 1 not null;
alter table Cleanings 
ADD  RowVersion INT Default 1 not null;
alter table Delivery
ADD  RowVersion INT Default 1 not null;
alter table Employees
ADD  RowVersion INT Default 1 not null;
alter table Feedings
ADD  RowVersion INT Default 1 not null;
alter table FoodProducts
ADD  RowVersion INT Default 1 not null;
alter table Pavilions
ADD  RowVersion INT Default 1 not null;
alter table Suppliers
ADD  RowVersion INT Default 1 not null;
commit Tran t1;


begin tran t2;
update  AnimalGroups
set RowVersion = 1

update  Animals
set RowVersion = 1

update  Cleanings
set RowVersion = 1

update  Delivery
set RowVersion = 1

update  Employees
set RowVersion = 1

update  Feedings
set RowVersion = 1

update  FoodProducts
set RowVersion = 1

update  Pavilions
set RowVersion = 1

update  Suppliers
set RowVersion = 1
commit tran t2;



select * from Suppliers;