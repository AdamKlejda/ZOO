
begin Tran T1;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnimalGroups](
	[AnimalGroupId] [int]IDENTITY (1,1) NOT NULL,
	[PavilionId] [int] NOT NULL,
	[Name] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AnimalGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Animals](
	[AnimalId] [int]IDENTITY (1,1) NOT NULL,
	[AnimalGroupId] [int] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Species] [varchar](255) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[DeathDate] [date] NULL,
	[Sex] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[AnimalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cleanings](
	[CleaningId] [int]IDENTITY (1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[PavilionId] [int] NOT NULL,
	[CleaningDate] [date] NOT NULL,
	[TimeForCleaning] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CleaningId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery](
	[DeliveryId] [int]IDENTITY (1,1) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[FoodProductsId] [int] NOT NULL,
	[DeliveryDate] [date] NOT NULL,
	[Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DeliveryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int]IDENTITY (1,1) NOT NULL,
	[FirstName] [varchar](255) NOT NULL,
	[LastName] [varchar](255) NOT NULL,
	[Salary] [int] NOT NULL,
	[Position] [varchar](255) NOT NULL,
	[login] [varchar](255) NOT NULL,
	[password] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedings](
	[FeedingId] [int] IDENTITY (1,1) NOT NULL,
	[AnimalGroupId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[FoodProductsId] [int] NOT NULL,
	[TimeForFeeding] [int] NOT NULL,
	[FeedingDate] [date] NOT NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodProducts](
	[FoodProductsId] [int] IDENTITY (1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Quantity] [int] NOT NULL,
	[ExpiryDate] [date] NOT NULL,
	[Calories] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FoodProductsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pavilions](
	[PavilionId] [int]IDENTITY (1,1) NOT NULL,
	[Surface] [int] NULL,
	[Name] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PavilionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierId] [int] IDENTITY (1,1) NOT NULL,
	[CompanyName] [varchar](255) NOT NULL,
	[ContactName] [varchar](255) NOT NULL,
	[Address] [varchar](255) NOT NULL,
	[City] [varchar](255) NOT NULL,
	[Country] [varchar](255) NOT NULL,
	[Phone] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Animals] ADD  DEFAULT (getdate()) FOR [BirthDate]
GO
ALTER TABLE [dbo].[Animals] ADD  DEFAULT (NULL) FOR [DeathDate]
GO
ALTER TABLE [dbo].[Animals] ADD  DEFAULT ('M') FOR [Sex]
GO
ALTER TABLE [dbo].[Cleanings] ADD  DEFAULT (getdate()) FOR [CleaningDate]
GO
ALTER TABLE [dbo].[Delivery] ADD  DEFAULT (getdate()) FOR [DeliveryDate]
GO
ALTER TABLE [dbo].[Delivery] ADD  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Feedings] ADD  DEFAULT (getdate()) FOR [FeedingDate]
GO
ALTER TABLE [dbo].[FoodProducts] ADD  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[FoodProducts] ADD  DEFAULT (getdate()) FOR [ExpiryDate]
GO
ALTER TABLE [dbo].[Pavilions] ADD  DEFAULT ((0)) FOR [Surface]
GO
ALTER TABLE [dbo].[AnimalGroups]  WITH CHECK ADD FOREIGN KEY([PavilionId])
REFERENCES [dbo].[Pavilions] ([PavilionId])
GO
ALTER TABLE [dbo].[Animals]  WITH CHECK ADD FOREIGN KEY([AnimalGroupId])
REFERENCES [dbo].[AnimalGroups] ([AnimalGroupId])
GO
ALTER TABLE [dbo].[Cleanings]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Cleanings]  WITH CHECK ADD FOREIGN KEY([PavilionId])
REFERENCES [dbo].[Pavilions] ([PavilionId])
GO
ALTER TABLE [dbo].[Delivery]  WITH CHECK ADD FOREIGN KEY([FoodProductsId])
REFERENCES [dbo].[FoodProducts] ([FoodProductsId])
GO
ALTER TABLE [dbo].[Delivery]  WITH CHECK ADD FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Suppliers] ([SupplierId])
GO
ALTER TABLE [dbo].[Feedings]  WITH CHECK ADD FOREIGN KEY([AnimalGroupId])
REFERENCES [dbo].[AnimalGroups] ([AnimalGroupId])
GO
ALTER TABLE [dbo].[Feedings]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Feedings]  WITH CHECK ADD FOREIGN KEY([FoodProductsId])
REFERENCES [dbo].[FoodProducts] ([FoodProductsId])
GO

commit Tran T1;

begin Tran t2;
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




commit Tran t2;


begin tran T3;
---------------------Triggers----------------------------------------------------------------
GO
Create trigger FeedOnce
on Feedings
for Insert,Update
as
 if (Select Count(*) from Feedings f, inserted i where f.AnimalGroupId=i.AnimalGroupId and f.FeedingDate=i.FeedingDate)>1
  begin
	 raiserror('*** Those animals have already eaten tonight ***',16,1)
	 rollback
  end
-------------
Go

create   trigger FoodDelivered
on Delivery
for Insert,Update
as

UPDATE FoodProducts
SET FoodProducts.Quantity = s.Quantity+d.Quantity
FROM FoodProducts s JOIN inserted d ON s.FoodProductsId = d.FoodProductsId
-------------
GO

create   trigger FoodEaten
on Feedings
for Insert,Update
as

UPDATE FoodProducts
SET FoodProducts.Quantity = s.Quantity-d.Quantity
FROM FoodProducts s JOIN inserted d ON s.FoodProductsId = d.FoodProductsId
if (select f.Quantity from FoodProducts f join inserted i on f.FoodProductsId=i.FoodProductsId)<=50 
begin
RAISERROR ('*** There is too little food! You should order more! ***',16,1)
end
-------------




------------------Procedures-------------------------------------------------------------------
Go
CREATE procedure KillAnimal
@a int
as
if ((select DeathDate from Animals where AnimalId=@a) is null) 
begin
Update Animals
set DeathDate = GETDATE()
where AnimalId=@a
end
else
begin
RAISERROR ('*** This animal is already dead! ***',16,1)
end

-------------

GO

create procedure Food_Report 
@start DATETIME, @stop DATETIME
as
Select fp.Name, SUM(f.Quantity) as Eaten, SUM(d.Quantity) as Bought, SUM(d.Quantity)-SUM(f.Quantity) as Balance
from Feedings f, FoodProducts fp, Delivery d 
where (fp.FoodProductsId=f.FoodProductsId or fp.FoodProductsId=d.FoodProductsId) and ((f.FeedingDate BETWEEN @start AND @stop) or (d.DeliveryDate BETWEEN @start AND @stop))
group by fp.Name;
-------------


GO


create procedure Calories_per_Group
@start DATETIME, @stop DATETIME
as

Select a.Name, SUM(f.Quantity * fp.Calories) as Eaten 
from Feedings f, FoodProducts fp, AnimalGroups a
where fp.FoodProductsId=f.FoodProductsId 
and f.AnimalGroupId=a.AnimalGroupId  
and (f.FeedingDate BETWEEN @start AND @stop)
group by a.Name;



------------------Views-------------------------------------------------------------------
GO
create view BusiestEmployees as 
  Select TOP 3 e.FirstName,e.LastName, Count(e.EmployeeId) as Appearances 
 from Employees e, Feedings f, Cleanings c 
 where (e.EmployeeId=f.EmployeeId or (e.EmployeeId=c.EmployeeId)) 
 group by e.FirstName,e.LastName 
 order by Appearances DESC;

-------------
GO


commit Tran T3;




