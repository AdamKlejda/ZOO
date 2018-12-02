
/****** Object:  Table [dbo].[AnimalGroups]    Script Date: 29.11.2018 10:28:13 ******/
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
/****** Object:  Table [dbo].[Animals]    Script Date: 29.11.2018 10:28:14 ******/
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
/****** Object:  Table [dbo].[Cleanings]    Script Date: 29.11.2018 10:28:14 ******/
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
/****** Object:  Table [dbo].[Delivery]    Script Date: 29.11.2018 10:28:14 ******/
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
/****** Object:  Table [dbo].[Employees]    Script Date: 29.11.2018 10:28:14 ******/
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
/****** Object:  Table [dbo].[Feedings]    Script Date: 29.11.2018 10:28:14 ******/
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
/****** Object:  Table [dbo].[FoodProducts]    Script Date: 29.11.2018 10:28:14 ******/
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
/****** Object:  Table [dbo].[Pavilions]    Script Date: 29.11.2018 10:28:14 ******/
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
/****** Object:  Table [dbo].[Suppliers]    Script Date: 29.11.2018 10:28:14 ******/
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


insert AnimalGroups(Name,PavilionId)
Values(Pawian,2);



select * from AnimalGroups;
drop table AnimalGroups;

EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"
EXEC sp_MSforeachtable @command1 = "DROP TABLE ?";


begin Tran T2;
INSERT [dbo].[Pavilions] ( [Surface], [Name]) VALUES ( 100, N'Africarium')
INSERT [dbo].[Pavilions] ( [Surface], [Name]) VALUES ( 50, N'Nocturnals')
INSERT [dbo].[Pavilions] ( [Surface], [Name]) VALUES ( 73, N'Apery')
INSERT [dbo].[Pavilions] ( [Surface], [Name]) VALUES ( 23, N'Aviary')
INSERT [dbo].[Pavilions] ( [Surface], [Name]) VALUES ( 205, N'Elephant house')
INSERT [dbo].[Pavilions] ( [Surface], [Name]) VALUES ( 67, N'Aquarium')
INSERT [dbo].[AnimalGroups] ( [PavilionId], [Name]) VALUES ( 3, N'Capuchin monkey')
INSERT [dbo].[AnimalGroups] ( [PavilionId], [Name]) VALUES ( 3, N'Baboons')
INSERT [dbo].[AnimalGroups] ( [PavilionId], [Name]) VALUES ( 4, N'Toucans')
INSERT [dbo].[AnimalGroups] ( [PavilionId], [Name]) VALUES ( 4, N'Parrots')
INSERT [dbo].[AnimalGroups] ( [PavilionId], [Name]) VALUES ( 6, N'Whales')
INSERT [dbo].[AnimalGroups] ( [PavilionId], [Name]) VALUES ( 6, N'Penguins')
INSERT [dbo].[AnimalGroups] ( [PavilionId], [Name]) VALUES ( 5, N'Elephants')
INSERT [dbo].[AnimalGroups] ( [PavilionId], [Name]) VALUES ( 2, N'Bats')
INSERT [dbo].[AnimalGroups] ( [PavilionId], [Name]) VALUES ( 1, N'Cats')
INSERT [dbo].[AnimalGroups] ( [PavilionId], [Name]) VALUES ( 1, N'Zebras')
INSERT [dbo].[Animals] ( [AnimalGroupId], [Name], [Species], [BirthDate], [DeathDate], [Sex]) VALUES ( 2, N'Mila', N'Hamadryas baboon', CAST(N'2018-11-12' AS Date), NULL, N'm')
INSERT [dbo].[Animals] ( [AnimalGroupId], [Name], [Species], [BirthDate], [DeathDate], [Sex]) VALUES ( 8, N'Filipus', N'Common vampire bat', CAST(N'2018-11-12' AS Date), NULL, N'm')
INSERT [dbo].[Animals] ( [AnimalGroupId], [Name], [Species], [BirthDate], [DeathDate], [Sex]) VALUES ( 7, N'Adas', N'African bush elephant', CAST(N'2018-11-12' AS Date), NULL, N'm')
INSERT [dbo].[Animals] ( [AnimalGroupId], [Name], [Species], [BirthDate], [DeathDate], [Sex]) VALUES ( 5, N'Eus', N'North Pacific right whale', CAST(N'2018-11-12' AS Date), NULL, N'k')
INSERT [dbo].[Animals] ( [AnimalGroupId], [Name], [Species], [BirthDate], [DeathDate], [Sex]) VALUES ( 10, N'Mania', N'Plains zebra', CAST(N'2018-11-12' AS Date), NULL, N'k')
INSERT [dbo].[Animals] ( [AnimalGroupId], [Name], [Species], [BirthDate], [DeathDate], [Sex]) VALUES ( 6, N'Kowalski', N'Galapagos penguin', CAST(N'2018-11-12' AS Date), NULL, N'm')
INSERT [dbo].[Animals] ( [AnimalGroupId], [Name], [Species], [BirthDate], [DeathDate], [Sex]) VALUES ( 3, N'Stasia', N'Toco toucan', CAST(N'2018-11-12' AS Date), NULL, N'm')
INSERT [dbo].[Animals] ( [AnimalGroupId], [Name], [Species], [BirthDate], [DeathDate], [Sex]) VALUES ( 7, N'Stachu', N'African bush elephant', CAST(N'2018-11-12' AS Date), NULL, N'm')
INSERT [dbo].[Animals] ( [AnimalGroupId], [Name], [Species], [BirthDate], [DeathDate], [Sex]) VALUES ( 9, N'Ecia', N'Iberian lynx', CAST(N'2018-11-12' AS Date), NULL, N'k')
INSERT [dbo].[Animals] ( [AnimalGroupId], [Name], [Species], [BirthDate], [DeathDate], [Sex]) VALUES ( 4, N'Wulf', N'Kakapo', CAST(N'2018-11-12' AS Date), NULL, N'k')
INSERT [dbo].[Animals] ( [AnimalGroupId], [Name], [Species], [BirthDate], [DeathDate], [Sex]) VALUES ( 1, N'Szymus', N'White-fronted capuchin', CAST(N'2018-11-12' AS Date), NULL, N'm')
INSERT [dbo].[Animals] ( [AnimalGroupId], [Name], [Species], [BirthDate], [DeathDate], [Sex]) VALUES ( 1, N'zbyszek', N'Plaszczowy', CAST(N'2018-11-12' AS Date), NULL, N'm')
INSERT [dbo].[Employees] ( [FirstName], [LastName], [Salary], [Position], [login], [password]) VALUES ( N'Filip', N'Matuszczak', 10000, N'CEO', N'fili_69', N'asdf')
INSERT [dbo].[Employees] ( [FirstName], [LastName], [Salary], [Position], [login], [password]) VALUES ( N'Ewa', N'Dziembowska', 5000, N'Secretary', N'ewapotranspiracja', N'fdsa')
INSERT [dbo].[Employees] ( [FirstName], [LastName], [Salary], [Position], [login], [password]) VALUES ( N'Adam', N'Klejda', 5001, N'Main cleanman', N'adamklej', N'abcdef')
INSERT [dbo].[Employees] ( [FirstName], [LastName], [Salary], [Position], [login], [password]) VALUES ( N'Bartosz', N'Mila', 0, N'Slave', N'barmila', N'zxcv')
INSERT [dbo].[Employees] ( [FirstName], [LastName], [Salary], [Position], [login], [password]) VALUES ( N'Stanislaw', N'Wasik', 3000, N'Worker', N'stanwas', N'bvcn')
INSERT [dbo].[Employees] ( [FirstName], [LastName], [Salary], [Position], [login], [password]) VALUES ( N'Stanislaw', N'Gileznosa', 2999, N'Worker', N'gileznosa', N'fdhsd')
INSERT [dbo].[FoodProducts] ( [Name], [Quantity], [ExpiryDate], [Calories]) VALUES ( N'Hay', 10, CAST(N'2018-11-12' AS Date), 1000)
INSERT [dbo].[FoodProducts] ( [Name], [Quantity], [ExpiryDate], [Calories]) VALUES ( N'Worms', 1000, CAST(N'2018-11-12' AS Date), 500)
INSERT [dbo].[FoodProducts] ( [Name], [Quantity], [ExpiryDate], [Calories]) VALUES ( N'Bananas', 500, CAST(N'2018-11-12' AS Date), 100)
INSERT [dbo].[FoodProducts] ( [Name], [Quantity], [ExpiryDate], [Calories]) VALUES ( N'Fish food', 100, CAST(N'2018-11-12' AS Date), 250)
INSERT [dbo].[FoodProducts] ( [Name], [Quantity], [ExpiryDate], [Calories]) VALUES ( N'Seeds', 230, CAST(N'2018-11-12' AS Date), 140)
INSERT [dbo].[FoodProducts] ( [Name], [Quantity], [ExpiryDate], [Calories]) VALUES ( N'Plankton', 102130, CAST(N'2018-11-12' AS Date), 1)
INSERT [dbo].[FoodProducts] ( [Name], [Quantity], [ExpiryDate], [Calories]) VALUES ( N'Dead fishes', 1000, CAST(N'2018-11-12' AS Date), 500)
INSERT [dbo].[FoodProducts] ( [Name], [Quantity], [ExpiryDate], [Calories]) VALUES ( N'Blood', 800, CAST(N'2018-11-12' AS Date), 300)
INSERT [dbo].[Feedings] ( [AnimalGroupId], [EmployeeId], [FoodProductsId], [TimeForFeeding], [FeedingDate], [Quantity]) VALUES ( 5, 4, 6, 50, CAST(N'2018-11-28' AS Date), 10)
INSERT [dbo].[Feedings] ( [AnimalGroupId], [EmployeeId], [FoodProductsId], [TimeForFeeding], [FeedingDate], [Quantity]) VALUES ( 6, 5, 7, 12, CAST(N'2018-11-28' AS Date), 10)
INSERT [dbo].[Feedings] ( [AnimalGroupId], [EmployeeId], [FoodProductsId], [TimeForFeeding], [FeedingDate], [Quantity]) VALUES ( 10, 6, 1, 32, CAST(N'2018-11-28' AS Date), 10)
INSERT [dbo].[Feedings] ( [AnimalGroupId], [EmployeeId], [FoodProductsId], [TimeForFeeding], [FeedingDate], [Quantity]) VALUES ( 8, 5, 8, 5, CAST(N'2018-11-28' AS Date), 10)
INSERT [dbo].[Cleanings] ( [EmployeeId], [PavilionId], [CleaningDate], [TimeForCleaning]) VALUES ( 1, 5, CAST(N'2018-11-28' AS Date), 1000)
INSERT [dbo].[Cleanings] ( [EmployeeId], [PavilionId], [CleaningDate], [TimeForCleaning]) VALUES ( 3, 3, CAST(N'2018-11-28' AS Date), 602)
INSERT [dbo].[Cleanings] ( [EmployeeId], [PavilionId], [CleaningDate], [TimeForCleaning]) VALUES ( 1, 2, CAST(N'2018-11-28' AS Date), 59)
INSERT [dbo].[Cleanings] ( [EmployeeId], [PavilionId], [CleaningDate], [TimeForCleaning]) VALUES ( 4, 1, CAST(N'2018-11-28' AS Date), 59)
INSERT [dbo].[Suppliers] ( [CompanyName], [ContactName], [Address], [City], [Country], [Phone]) VALUES ( N'Foodex', N'Filip', N'Simple 12', N'Los Angeles', N'USA', N'+48-123-123-123')
INSERT [dbo].[Suppliers] ( [CompanyName], [ContactName], [Address], [City], [Country], [Phone]) VALUES ( N'Airpress Polska Sp. z o.o.', N'Ewa', N'Polanka 7', N'Poznan', N'Poland', N'+48-321-432-765')
INSERT [dbo].[Suppliers] ( [CompanyName], [ContactName], [Address], [City], [Country], [Phone]) VALUES ( N'Schiessl', N'Adam', N'Wuerfungel 182', N'Berlin', N'Germany', N'+48-654-234-987')
INSERT [dbo].[Suppliers] ( [CompanyName], [ContactName], [Address], [City], [Country], [Phone]) VALUES ( N'INTECCO', N'Mila', N'Long 712', N'New York', N'USA', N'+48-624-294-387')
INSERT [dbo].[Suppliers] ( [CompanyName], [ContactName], [Address], [City], [Country], [Phone]) VALUES ( N'Foodesy International', N'Szymon', N'Kawaii 13', N'Tokio', N'Japan', N'+48-684-194-388')
INSERT [dbo].[Delivery] ( [SupplierId], [FoodProductsId], [DeliveryDate], [Quantity]) VALUES ( 2, 2, CAST(N'2018-11-12' AS Date), 300)
INSERT [dbo].[Delivery] ( [SupplierId], [FoodProductsId], [DeliveryDate], [Quantity]) VALUES ( 1, 1, CAST(N'2018-11-12' AS Date), 300)
INSERT [dbo].[Delivery] ( [SupplierId], [FoodProductsId], [DeliveryDate], [Quantity]) VALUES ( 4, 4, CAST(N'2018-11-12' AS Date), 100)
INSERT [dbo].[Delivery] ( [SupplierId], [FoodProductsId], [DeliveryDate], [Quantity]) VALUES ( 3, 3, CAST(N'2018-11-12' AS Date), 1000)
INSERT [dbo].[Delivery] ( [SupplierId], [FoodProductsId], [DeliveryDate], [Quantity]) VALUES ( 5, 5, CAST(N'2018-11-12' AS Date), 1000)
INSERT [dbo].[Delivery] ( [SupplierId], [FoodProductsId], [DeliveryDate], [Quantity]) VALUES ( 5, 5, CAST(N'2018-11-12' AS Date), 1000)
INSERT [dbo].[Delivery] ( [SupplierId], [FoodProductsId], [DeliveryDate], [Quantity]) VALUES ( 5, 5, CAST(N'2018-11-12' AS Date), 5000)
INSERT [dbo].[Delivery] ( [SupplierId], [FoodProductsId], [DeliveryDate], [Quantity]) VALUES ( 1, 3, CAST(N'2018-11-12' AS Date), 5000)
INSERT [dbo].[Delivery] ( [SupplierId], [FoodProductsId], [DeliveryDate], [Quantity]) VALUES ( 5, 2, CAST(N'2018-11-12' AS Date), 5000)
INSERT [dbo].[Delivery] ( [SupplierId], [FoodProductsId], [DeliveryDate], [Quantity]) VALUES ( 1, 6, CAST(N'2018-12-01' AS Date), 2130)

commit Tran T2;

select * from Animals;