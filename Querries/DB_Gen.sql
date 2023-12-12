USE [DeviceRepairing]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_Role1]
GO
ALTER TABLE [dbo].[Request] DROP CONSTRAINT [FK_Request_State]
GO
ALTER TABLE [dbo].[Request] DROP CONSTRAINT [FK_Request_Device]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12.12.2023 6:51:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[State]    Script Date: 12.12.2023 6:51:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[State]') AND type in (N'U'))
DROP TABLE [dbo].[State]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12.12.2023 6:51:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
DROP TABLE [dbo].[Role]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 12.12.2023 6:51:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Request]') AND type in (N'U'))
DROP TABLE [dbo].[Request]
GO
/****** Object:  Table [dbo].[Device]    Script Date: 12.12.2023 6:51:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Device]') AND type in (N'U'))
DROP TABLE [dbo].[Device]
GO
/****** Object:  Schema [for_dr_admin]    Script Date: 12.12.2023 6:51:13 ******/
DROP SCHEMA [for_dr_admin]
GO
/****** Object:  User [dr_admin]    Script Date: 12.12.2023 6:51:13 ******/
DROP USER [dr_admin]
GO
USE [master]
GO
/****** Object:  Login [NT SERVICE\Winmgmt]    Script Date: 12.12.2023 6:51:13 ******/
DROP LOGIN [NT SERVICE\Winmgmt]
GO
/****** Object:  Login [NT SERVICE\SQLWriter]    Script Date: 12.12.2023 6:51:13 ******/
DROP LOGIN [NT SERVICE\SQLWriter]
GO
/****** Object:  Login [NT SERVICE\SQLTELEMETRY$SQLEXPRESS]    Script Date: 12.12.2023 6:51:13 ******/
DROP LOGIN [NT SERVICE\SQLTELEMETRY$SQLEXPRESS]
GO
/****** Object:  Login [NT Service\MSSQL$SQLEXPRESS]    Script Date: 12.12.2023 6:51:13 ******/
DROP LOGIN [NT Service\MSSQL$SQLEXPRESS]
GO
/****** Object:  Login [NT AUTHORITY\СИСТЕМА]    Script Date: 12.12.2023 6:51:13 ******/
DROP LOGIN [NT AUTHORITY\СИСТЕМА]
GO
/****** Object:  Login [EmpOfReg]    Script Date: 12.12.2023 6:51:13 ******/
DROP LOGIN [EmpOfReg]
GO
/****** Object:  Login [DRGNbook\theko]    Script Date: 12.12.2023 6:51:13 ******/
DROP LOGIN [DRGNbook\theko]
GO
/****** Object:  Login [dr_warehouse]    Script Date: 12.12.2023 6:51:13 ******/
DROP LOGIN [dr_warehouse]
GO
/****** Object:  Login [dr_operator]    Script Date: 12.12.2023 6:51:13 ******/
DROP LOGIN [dr_operator]
GO
/****** Object:  Login [dr_engineer]    Script Date: 12.12.2023 6:51:13 ******/
DROP LOGIN [dr_engineer]
GO
/****** Object:  Login [dr_admin]    Script Date: 12.12.2023 6:51:13 ******/
DROP LOGIN [dr_admin]
GO
/****** Object:  Login [Doctor]    Script Date: 12.12.2023 6:51:13 ******/
DROP LOGIN [Doctor]
GO
/****** Object:  Login [BUILTIN\Пользователи]    Script Date: 12.12.2023 6:51:13 ******/
DROP LOGIN [BUILTIN\Пользователи]
GO
/****** Object:  Login [Admin]    Script Date: 12.12.2023 6:51:13 ******/
DROP LOGIN [Admin]
GO
/****** Object:  Login [##MS_PolicyTsqlExecutionLogin##]    Script Date: 12.12.2023 6:51:13 ******/
DROP LOGIN [##MS_PolicyTsqlExecutionLogin##]
GO
/****** Object:  Login [##MS_PolicyEventProcessingLogin##]    Script Date: 12.12.2023 6:51:13 ******/
DROP LOGIN [##MS_PolicyEventProcessingLogin##]
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [##MS_PolicyEventProcessingLogin##]    Script Date: 12.12.2023 6:51:13 ******/
CREATE LOGIN [##MS_PolicyEventProcessingLogin##] WITH PASSWORD=N'ml6cvp5fGv2AU3izl5bY53uBvOKC1xe6NnQcP94Snrk=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [##MS_PolicyEventProcessingLogin##] DISABLE
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [##MS_PolicyTsqlExecutionLogin##]    Script Date: 12.12.2023 6:51:13 ******/
CREATE LOGIN [##MS_PolicyTsqlExecutionLogin##] WITH PASSWORD=N'+Fd4Di2MI58FxSfeR75yNIidlQaqgG+XzGI1rh4Ke8E=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [##MS_PolicyTsqlExecutionLogin##] DISABLE
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [Admin]    Script Date: 12.12.2023 6:51:13 ******/
CREATE LOGIN [Admin] WITH PASSWORD=N'2wQ+myl0SJk1Gab+hqld0nacym4Xb6Y4pD0QxhZWYkk=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER LOGIN [Admin] DISABLE
GO
/****** Object:  Login [BUILTIN\Пользователи]    Script Date: 12.12.2023 6:51:13 ******/
CREATE LOGIN [BUILTIN\Пользователи] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [Doctor]    Script Date: 12.12.2023 6:51:13 ******/
CREATE LOGIN [Doctor] WITH PASSWORD=N'qsT8fFWoBEwtnrA8tbnpJEsxbUDeM3HXChbaTDhRjTA=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER LOGIN [Doctor] DISABLE
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [dr_admin]    Script Date: 12.12.2023 6:51:13 ******/
CREATE LOGIN [dr_admin] WITH PASSWORD=N'Z3fCN1YzpRNlbp75KsvsvhEmq9EPgu0lEns2Z82+Ciw=', DEFAULT_DATABASE=[DeviceRepairing], DEFAULT_LANGUAGE=[русский], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER LOGIN [dr_admin] DISABLE
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [dr_engineer]    Script Date: 12.12.2023 6:51:13 ******/
CREATE LOGIN [dr_engineer] WITH PASSWORD=N'OVesvI4O4eWgaStLrgW7g6N4I5OFlskNLKQ1z5PXX44=', DEFAULT_DATABASE=[DeviceRepairing], DEFAULT_LANGUAGE=[русский], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER LOGIN [dr_engineer] DISABLE
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [dr_operator]    Script Date: 12.12.2023 6:51:13 ******/
CREATE LOGIN [dr_operator] WITH PASSWORD=N'TOQSdWbkN6K5F8aLhgxfwzCHuJATSbAPvnjjT70rDr8=', DEFAULT_DATABASE=[DeviceRepairing], DEFAULT_LANGUAGE=[русский], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER LOGIN [dr_operator] DISABLE
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [dr_warehouse]    Script Date: 12.12.2023 6:51:13 ******/
CREATE LOGIN [dr_warehouse] WITH PASSWORD=N'fkBd2Gv8KMgPcmUWR6oVaWlBIXmL6Z5h7eP9Lk1tvHc=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER LOGIN [dr_warehouse] DISABLE
GO
/****** Object:  Login [DRGNbook\theko]    Script Date: 12.12.2023 6:51:13 ******/
CREATE LOGIN [DRGNbook\theko] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [EmpOfReg]    Script Date: 12.12.2023 6:51:13 ******/
CREATE LOGIN [EmpOfReg] WITH PASSWORD=N'yJsyu5XdG9aqrq1veuvM+DdWxhg4xj7nCqIkap4GoUE=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER LOGIN [EmpOfReg] DISABLE
GO
/****** Object:  Login [NT AUTHORITY\СИСТЕМА]    Script Date: 12.12.2023 6:51:13 ******/
CREATE LOGIN [NT AUTHORITY\СИСТЕМА] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/****** Object:  Login [NT Service\MSSQL$SQLEXPRESS]    Script Date: 12.12.2023 6:51:13 ******/
CREATE LOGIN [NT Service\MSSQL$SQLEXPRESS] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/****** Object:  Login [NT SERVICE\SQLTELEMETRY$SQLEXPRESS]    Script Date: 12.12.2023 6:51:13 ******/
CREATE LOGIN [NT SERVICE\SQLTELEMETRY$SQLEXPRESS] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/****** Object:  Login [NT SERVICE\SQLWriter]    Script Date: 12.12.2023 6:51:13 ******/
CREATE LOGIN [NT SERVICE\SQLWriter] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
/****** Object:  Login [NT SERVICE\Winmgmt]    Script Date: 12.12.2023 6:51:13 ******/
CREATE LOGIN [NT SERVICE\Winmgmt] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[русский]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [DRGNbook\theko]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT Service\MSSQL$SQLEXPRESS]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT SERVICE\SQLWriter]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT SERVICE\Winmgmt]
GO
USE [DeviceRepairing]
GO
/****** Object:  User [dr_admin]    Script Date: 12.12.2023 6:51:13 ******/
CREATE USER [dr_admin] FOR LOGIN [dr_admin] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [dr_admin]
GO
/****** Object:  Schema [for_dr_admin]    Script Date: 12.12.2023 6:51:13 ******/
CREATE SCHEMA [for_dr_admin]
GO
/****** Object:  Table [dbo].[Device]    Script Date: 12.12.2023 6:51:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Device](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Manifucator] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
	[MalfunctionInfo] [nvarchar](2048) NULL,
 CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 12.12.2023 6:51:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[C_FirstName] [nvarchar](15) NULL,
	[C_SecondName] [nvarchar](15) NULL,
	[C_LastName] [nvarchar](15) NOT NULL,
	[C_PhoneNumber] [nvarchar](50) NULL,
	[DateOfRequest] [datetime] NOT NULL,
	[IsAccepted] [bit] NOT NULL,
	[StateID] [int] NOT NULL,
	[DeviceID] [int] NOT NULL,
	[RepairCost] [decimal](19, 4) NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12.12.2023 6:51:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Role1] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 12.12.2023 6:51:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RequestState] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12.12.2023 6:51:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](15) NULL,
	[SecondName] [nvarchar](15) NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[MobileNumber] [nvarchar](12) NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Device] ON 
GO
INSERT [dbo].[Device] ([ID], [Manifucator], [Model], [MalfunctionInfo]) VALUES (1, N'IPoh', N'5C', N'Не открывается Сапёр


')
GO
INSERT [dbo].[Device] ([ID], [Manifucator], [Model], [MalfunctionInfo]) VALUES (4, N'IPon', N'20+', N'Насрали в динамик

')
GO
INSERT [dbo].[Device] ([ID], [Manifucator], [Model], [MalfunctionInfo]) VALUES (6, N'IPhone', N'100 Pro', N'Не даёт скидку на тонер
')
GO
INSERT [dbo].[Device] ([ID], [Manifucator], [Model], [MalfunctionInfo]) VALUES (7, N'Google', N'Pixel 4 (6/64)', N'Не набирается номер Огузка
')
GO
INSERT [dbo].[Device] ([ID], [Manifucator], [Model], [MalfunctionInfo]) VALUES (8, N'LG', N'Nexus 5X', N'

')
GO
INSERT [dbo].[Device] ([ID], [Manifucator], [Model], [MalfunctionInfo]) VALUES (9, N'Xiaomi', N'Redmi 228 Pro', N'
')
GO
INSERT [dbo].[Device] ([ID], [Manifucator], [Model], [MalfunctionInfo]) VALUES (10, N'test', N'test', N'test
')
GO
INSERT [dbo].[Device] ([ID], [Manifucator], [Model], [MalfunctionInfo]) VALUES (11, N'', N'', N'
')
GO
INSERT [dbo].[Device] ([ID], [Manifucator], [Model], [MalfunctionInfo]) VALUES (12, N'', N'', N'
')
GO
INSERT [dbo].[Device] ([ID], [Manifucator], [Model], [MalfunctionInfo]) VALUES (13, N'', N'', N'
')
GO
INSERT [dbo].[Device] ([ID], [Manifucator], [Model], [MalfunctionInfo]) VALUES (14, N'', N'', N'
')
GO
INSERT [dbo].[Device] ([ID], [Manifucator], [Model], [MalfunctionInfo]) VALUES (15, N'', N'', N'
')
GO
INSERT [dbo].[Device] ([ID], [Manifucator], [Model], [MalfunctionInfo]) VALUES (16, N'', N'', N'
')
GO
INSERT [dbo].[Device] ([ID], [Manifucator], [Model], [MalfunctionInfo]) VALUES (17, N'', N'', N'
')
GO
INSERT [dbo].[Device] ([ID], [Manifucator], [Model], [MalfunctionInfo]) VALUES (18, N'', N'', N'
')
GO
INSERT [dbo].[Device] ([ID], [Manifucator], [Model], [MalfunctionInfo]) VALUES (19, N'', N'', N'
')
GO
INSERT [dbo].[Device] ([ID], [Manifucator], [Model], [MalfunctionInfo]) VALUES (20, N'', N'', N'
')
GO
INSERT [dbo].[Device] ([ID], [Manifucator], [Model], [MalfunctionInfo]) VALUES (21, N'', N'', N'
')
GO
INSERT [dbo].[Device] ([ID], [Manifucator], [Model], [MalfunctionInfo]) VALUES (22, N'', N'', N'

')
GO
INSERT [dbo].[Device] ([ID], [Manifucator], [Model], [MalfunctionInfo]) VALUES (23, N'1', N'1', N'1
')
GO
SET IDENTITY_INSERT [dbo].[Device] OFF
GO
SET IDENTITY_INSERT [dbo].[Request] ON 
GO
INSERT [dbo].[Request] ([ID], [C_FirstName], [C_SecondName], [C_LastName], [C_PhoneNumber], [DateOfRequest], [IsAccepted], [StateID], [DeviceID], [RepairCost]) VALUES (1, N'Иван', N'Иванович', N'Иванов', N'+79042229911', CAST(N'2023-04-21T04:11:00.000' AS DateTime), 1, 3, 1, CAST(15000.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[Request] ([ID], [C_FirstName], [C_SecondName], [C_LastName], [C_PhoneNumber], [DateOfRequest], [IsAccepted], [StateID], [DeviceID], [RepairCost]) VALUES (2, N'Иван', N'Леонидович', N'Машкашов', N'+88003334455', CAST(N'2023-12-01T10:48:22.387' AS DateTime), 0, 1, 4, CAST(228.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[Request] ([ID], [C_FirstName], [C_SecondName], [C_LastName], [C_PhoneNumber], [DateOfRequest], [IsAccepted], [StateID], [DeviceID], [RepairCost]) VALUES (3, N'Кирилл', N'Евгеньевич', N'Кондрацкий', N'+79042224583', CAST(N'2023-12-01T11:38:47.280' AS DateTime), 1, 4, 6, CAST(100.0100 AS Decimal(19, 4)))
GO
INSERT [dbo].[Request] ([ID], [C_FirstName], [C_SecondName], [C_LastName], [C_PhoneNumber], [DateOfRequest], [IsAccepted], [StateID], [DeviceID], [RepairCost]) VALUES (4, N'Виктор', N'Петрович', N'Баринов', N'+77777777777', CAST(N'2023-12-01T11:46:55.220' AS DateTime), 1, 2, 7, CAST(228.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[Request] ([ID], [C_FirstName], [C_SecondName], [C_LastName], [C_PhoneNumber], [DateOfRequest], [IsAccepted], [StateID], [DeviceID], [RepairCost]) VALUES (5, N'Наруто', N'Евгеньевич', N'Узумаки', NULL, CAST(N'2023-12-01T11:49:05.783' AS DateTime), 1, 1, 8, CAST(626.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[Request] ([ID], [C_FirstName], [C_SecondName], [C_LastName], [C_PhoneNumber], [DateOfRequest], [IsAccepted], [StateID], [DeviceID], [RepairCost]) VALUES (6, N'Иисус', N'Христосович', N'Богов', N'+66666666666', CAST(N'2023-12-01T11:50:29.737' AS DateTime), 0, 5, 9, CAST(333.0000 AS Decimal(19, 4)))
GO
SET IDENTITY_INSERT [dbo].[Request] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([ID], [Role1]) VALUES (1, N'Admin')
GO
INSERT [dbo].[Role] ([ID], [Role1]) VALUES (2, N'Operator')
GO
INSERT [dbo].[Role] ([ID], [Role1]) VALUES (3, N'Engineer')
GO
INSERT [dbo].[Role] ([ID], [Role1]) VALUES (4, N'Warehouseman')
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[State] ON 
GO
INSERT [dbo].[State] ([ID], [RequestState]) VALUES (1, N'Отказано в ремонте')
GO
INSERT [dbo].[State] ([ID], [RequestState]) VALUES (2, N'В процессе')
GO
INSERT [dbo].[State] ([ID], [RequestState]) VALUES (3, N'В ожидании')
GO
INSERT [dbo].[State] ([ID], [RequestState]) VALUES (4, N'Завершено')
GO
INSERT [dbo].[State] ([ID], [RequestState]) VALUES (5, N'Ожидание деталей')
GO
SET IDENTITY_INSERT [dbo].[State] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([ID], [FirstName], [SecondName], [LastName], [MobileNumber], [Login], [Password], [RoleID]) VALUES (2, N'Александр', N'Павлович', N'Ячменев', N'88005553535', N'admin', N'21232f297a57a5a743894a0e4a801fc3', 1)
GO
INSERT [dbo].[Users] ([ID], [FirstName], [SecondName], [LastName], [MobileNumber], [Login], [Password], [RoleID]) VALUES (5, N'Александр', N'Павлович', N'Ячменев', N'0', N'engineer', N'9d127ff383d595262c67036f50493133', 3)
GO
INSERT [dbo].[Users] ([ID], [FirstName], [SecondName], [LastName], [MobileNumber], [Login], [Password], [RoleID]) VALUES (7, N'Александр', N'Павлович', N'Ячменев', N'1', N'operator', N'4b583376b2767b923c3e1da60d10de59', 2)
GO
INSERT [dbo].[Users] ([ID], [FirstName], [SecondName], [LastName], [MobileNumber], [Login], [Password], [RoleID]) VALUES (9, N'Александр', N'Павлович', N'Ячменев', N'1337', N'whouse', N'78b8864c8f0ebd16162326ccb3d3145b', 4)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Device] FOREIGN KEY([DeviceID])
REFERENCES [dbo].[Device] ([ID])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Device]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_State] FOREIGN KEY([StateID])
REFERENCES [dbo].[State] ([ID])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_State]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Role1] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Role1]
GO
