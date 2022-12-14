USE [master]
GO
/****** Object:  Database [GymManager]    Script Date: 10/6/2021 1:55:20 PM ******/
CREATE DATABASE [GymManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GymManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GymManager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GymManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\GymManager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GymManager] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GymManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GymManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GymManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GymManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GymManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GymManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [GymManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GymManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GymManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GymManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GymManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GymManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GymManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GymManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GymManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GymManager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GymManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GymManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GymManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GymManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GymManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GymManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GymManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GymManager] SET RECOVERY FULL 
GO
ALTER DATABASE [GymManager] SET  MULTI_USER 
GO
ALTER DATABASE [GymManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GymManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GymManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GymManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GymManager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GymManager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'GymManager', N'ON'
GO
ALTER DATABASE [GymManager] SET QUERY_STORE = OFF
GO
USE [GymManager]
GO
/****** Object:  Table [dbo].[tblEmployees]    Script Date: 10/6/2021 1:55:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmployees](
	[employeeId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[dob] [date] NOT NULL,
	[gender] [nvarchar](7) NOT NULL,
	[address] [nvarchar](250) NOT NULL,
	[mobile_number] [nvarchar](10) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_tblEmployees] PRIMARY KEY CLUSTERED 
(
	[employeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblInstructors]    Script Date: 10/6/2021 1:55:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblInstructors](
	[instructorId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[dob] [date] NOT NULL,
	[gender] [nvarchar](7) NOT NULL,
	[address] [nvarchar](250) NOT NULL,
	[mobile_number] [nvarchar](10) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_tblInstructors] PRIMARY KEY CLUSTERED 
(
	[instructorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblMembers]    Script Date: 10/6/2021 1:55:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMembers](
	[memberId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[dob] [date] NOT NULL,
	[gender] [nvarchar](7) NOT NULL,
	[weight] [int] NULL,
	[height] [int] NULL,
	[address] [nvarchar](250) NOT NULL,
	[mobile_number] [nvarchar](10) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
	[deleted_at] [datetime] NULL,
 CONSTRAINT [PK_tblMembers] PRIMARY KEY CLUSTERED 
(
	[memberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblShift]    Script Date: 10/6/2021 1:55:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblShift](
	[shiftId] [int] IDENTITY(1,1) NOT NULL,
	[instructorId] [int] NOT NULL,
	[day] [varchar](10) NOT NULL,
	[shift] [varchar](30) NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
 CONSTRAINT [PK_tblShift] PRIMARY KEY CLUSTERED 
(
	[shiftId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTimeSlots]    Script Date: 10/6/2021 1:55:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTimeSlots](
	[timeslotId] [int] IDENTITY(1,1) NOT NULL,
	[memberId] [int] NOT NULL,
	[day] [varchar](10) NOT NULL,
	[timeslot] [varchar](30) NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
 CONSTRAINT [PK_tblTimeSlot] PRIMARY KEY CLUSTERED 
(
	[timeslotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUsers]    Script Date: 10/6/2021 1:55:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsers](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblWorkouts]    Script Date: 10/6/2021 1:55:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblWorkouts](
	[workoutId] [int] IDENTITY(1,1) NOT NULL,
	[memberId] [int] NOT NULL,
	[exercise] [varchar](50) NOT NULL,
	[reps] [int] NOT NULL,
	[sets] [int] NOT NULL,
	[updated_at] [datetime] NOT NULL,
 CONSTRAINT [PK_tblWorkouts] PRIMARY KEY CLUSTERED 
(
	[workoutId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblEmployees] ON 

INSERT [dbo].[tblEmployees] ([employeeId], [name], [dob], [gender], [address], [mobile_number], [created_at], [updated_at], [deleted_at]) VALUES (1, N'Melan Maduranga', CAST(N'1992-06-23' AS Date), N'Male', N'Habaraduwa, Galle', N'774587954', CAST(N'2021-09-26T01:14:27.957' AS DateTime), CAST(N'2021-09-26T02:23:32.780' AS DateTime), NULL)
INSERT [dbo].[tblEmployees] ([employeeId], [name], [dob], [gender], [address], [mobile_number], [created_at], [updated_at], [deleted_at]) VALUES (2, N'', CAST(N'2021-09-26' AS Date), N'-', N'', N'', CAST(N'2021-09-26T01:42:05.150' AS DateTime), CAST(N'2021-09-26T01:42:05.150' AS DateTime), CAST(N'2021-09-26T02:13:06.357' AS DateTime))
INSERT [dbo].[tblEmployees] ([employeeId], [name], [dob], [gender], [address], [mobile_number], [created_at], [updated_at], [deleted_at]) VALUES (3, N'Chamidu Perera', CAST(N'1995-02-24' AS Date), N'Male', N'Unawatuna, Galle.', N'112365478', CAST(N'2021-09-26T02:15:29.520' AS DateTime), CAST(N'2021-10-05T10:12:56.770' AS DateTime), NULL)
INSERT [dbo].[tblEmployees] ([employeeId], [name], [dob], [gender], [address], [mobile_number], [created_at], [updated_at], [deleted_at]) VALUES (4, N'Vishwa Nipun Srimal', CAST(N'1999-07-14' AS Date), N'Male', N'53, Hediwatte, Habaraduwa', N'718531949', CAST(N'2021-10-05T10:14:00.457' AS DateTime), CAST(N'2021-10-05T10:14:24.103' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tblEmployees] OFF
GO
SET IDENTITY_INSERT [dbo].[tblInstructors] ON 

INSERT [dbo].[tblInstructors] ([instructorId], [name], [dob], [gender], [address], [mobile_number], [created_at], [updated_at], [deleted_at]) VALUES (1, N'Melanne Maduranga', CAST(N'1994-06-03' AS Date), N'Male', N'Test, Habaraduwa', N'0712584569', CAST(N'2021-09-28T02:35:46.300' AS DateTime), CAST(N'2021-09-28T02:35:46.300' AS DateTime), NULL)
INSERT [dbo].[tblInstructors] ([instructorId], [name], [dob], [gender], [address], [mobile_number], [created_at], [updated_at], [deleted_at]) VALUES (2, N'Chamindu Shan', CAST(N'1993-06-11' AS Date), N'Male', N'Test, Thalpe , Koggala', N'774581236', CAST(N'2021-09-28T02:40:16.413' AS DateTime), CAST(N'2021-09-28T03:03:53.180' AS DateTime), CAST(N'2021-09-29T02:14:04.373' AS DateTime))
INSERT [dbo].[tblInstructors] ([instructorId], [name], [dob], [gender], [address], [mobile_number], [created_at], [updated_at], [deleted_at]) VALUES (3, N'Test 3', CAST(N'1999-09-28' AS Date), N'Male', N'sd asd dde', N'0147852369', CAST(N'2021-09-28T02:45:48.130' AS DateTime), CAST(N'2021-09-28T02:45:48.130' AS DateTime), CAST(N'2021-09-28T03:03:26.270' AS DateTime))
INSERT [dbo].[tblInstructors] ([instructorId], [name], [dob], [gender], [address], [mobile_number], [created_at], [updated_at], [deleted_at]) VALUES (4, N'Vishwa Nipun', CAST(N'1999-07-14' AS Date), N'Male', N'Hediwatte, Habaraduwa.', N'0718531949', CAST(N'2021-09-28T03:05:35.073' AS DateTime), CAST(N'2021-09-28T03:05:35.073' AS DateTime), NULL)
INSERT [dbo].[tblInstructors] ([instructorId], [name], [dob], [gender], [address], [mobile_number], [created_at], [updated_at], [deleted_at]) VALUES (5, N'Test', CAST(N'1999-07-14' AS Date), N'Male', N'Hediwatte, Habaraduwa.', N'0718531111', CAST(N'2021-09-29T00:38:44.143' AS DateTime), CAST(N'2021-09-29T00:38:44.143' AS DateTime), CAST(N'2021-09-29T00:38:50.920' AS DateTime))
INSERT [dbo].[tblInstructors] ([instructorId], [name], [dob], [gender], [address], [mobile_number], [created_at], [updated_at], [deleted_at]) VALUES (6, N'Test 5', CAST(N'2021-09-06' AS Date), N'Female', N' df ff', N'123654789', CAST(N'2021-09-29T00:39:11.667' AS DateTime), CAST(N'2021-10-01T18:14:59.440' AS DateTime), CAST(N'2021-10-01T18:15:06.113' AS DateTime))
INSERT [dbo].[tblInstructors] ([instructorId], [name], [dob], [gender], [address], [mobile_number], [created_at], [updated_at], [deleted_at]) VALUES (7, N'Chamindu Liyanage', CAST(N'1994-04-14' AS Date), N'Male', N'Hediwatte, Habaraduwa.', N'0715489632', CAST(N'2021-10-01T18:15:46.060' AS DateTime), CAST(N'2021-10-01T18:15:46.060' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tblInstructors] OFF
GO
SET IDENTITY_INSERT [dbo].[tblMembers] ON 

INSERT [dbo].[tblMembers] ([memberId], [name], [dob], [gender], [weight], [height], [address], [mobile_number], [created_at], [updated_at], [deleted_at]) VALUES (1, N'Tharindu Hashi', CAST(N'1999-09-25' AS Date), N'Male', 60, 123, N'asd asd rrd', N'123654789', CAST(N'2021-09-25T01:32:56.613' AS DateTime), CAST(N'2021-09-26T02:23:04.633' AS DateTime), CAST(N'2021-10-01T23:34:13.847' AS DateTime))
INSERT [dbo].[tblMembers] ([memberId], [name], [dob], [gender], [weight], [height], [address], [mobile_number], [created_at], [updated_at], [deleted_at]) VALUES (2, N'sdad asd', CAST(N'2021-09-25' AS Date), N'Male', 12, 112, N'asd asd', N'asdasdasds', CAST(N'2021-09-25T01:46:31.320' AS DateTime), CAST(N'2021-09-25T01:46:31.320' AS DateTime), CAST(N'2021-09-26T00:29:54.960' AS DateTime))
INSERT [dbo].[tblMembers] ([memberId], [name], [dob], [gender], [weight], [height], [address], [mobile_number], [created_at], [updated_at], [deleted_at]) VALUES (3, N'Kavindu Tharaka', CAST(N'1999-09-08' AS Date), N'Male', 65, 180, N'Habaraduwa, Galle', N'0713408146', CAST(N'2021-09-25T01:51:31.617' AS DateTime), CAST(N'2021-09-25T01:51:31.617' AS DateTime), NULL)
INSERT [dbo].[tblMembers] ([memberId], [name], [dob], [gender], [weight], [height], [address], [mobile_number], [created_at], [updated_at], [deleted_at]) VALUES (4, N'Hashini Bhagya Hewage', CAST(N'1999-04-20' AS Date), N'Female', 80, 180, N'Maharamba Rd, Unawatuna.', N'774308478', CAST(N'2021-09-25T02:17:33.870' AS DateTime), CAST(N'2021-10-05T10:06:38.463' AS DateTime), NULL)
INSERT [dbo].[tblMembers] ([memberId], [name], [dob], [gender], [weight], [height], [address], [mobile_number], [created_at], [updated_at], [deleted_at]) VALUES (5, N'Vishwa Nipun', CAST(N'2021-09-25' AS Date), N'Male', 70, 125, N'Test, sad', N'012345689', CAST(N'2021-09-25T03:34:35.260' AS DateTime), CAST(N'2021-09-25T03:34:35.260' AS DateTime), NULL)
INSERT [dbo].[tblMembers] ([memberId], [name], [dob], [gender], [weight], [height], [address], [mobile_number], [created_at], [updated_at], [deleted_at]) VALUES (6, N'Tests2', CAST(N'2021-09-12' AS Date), N'Male', 123, 33, N'asd asd ', N'1231231233', CAST(N'2021-09-25T23:52:50.373' AS DateTime), CAST(N'2021-09-25T23:52:50.373' AS DateTime), CAST(N'2021-09-26T02:17:43.270' AS DateTime))
INSERT [dbo].[tblMembers] ([memberId], [name], [dob], [gender], [weight], [height], [address], [mobile_number], [created_at], [updated_at], [deleted_at]) VALUES (7, N'Dwayne Rock', CAST(N'2021-09-25' AS Date), N'Male', 70, 125, N'California, LA', N'718549632', CAST(N'2021-10-01T23:33:47.867' AS DateTime), CAST(N'2021-10-05T01:01:55.173' AS DateTime), NULL)
INSERT [dbo].[tblMembers] ([memberId], [name], [dob], [gender], [weight], [height], [address], [mobile_number], [created_at], [updated_at], [deleted_at]) VALUES (8, N'Testing Person', CAST(N'1990-06-06' AS Date), N'Female', 70, 125, N'Test Address', N'0771482596', CAST(N'2021-10-05T01:02:55.373' AS DateTime), CAST(N'2021-10-05T01:02:55.373' AS DateTime), CAST(N'2021-10-05T01:03:16.907' AS DateTime))
INSERT [dbo].[tblMembers] ([memberId], [name], [dob], [gender], [weight], [height], [address], [mobile_number], [created_at], [updated_at], [deleted_at]) VALUES (9, N'Test Member', CAST(N'1999-04-05' AS Date), N'Male', 80, 180, N'Test Address', N'0771111111', CAST(N'2021-10-05T10:07:14.233' AS DateTime), CAST(N'2021-10-05T10:07:14.233' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[tblMembers] OFF
GO
SET IDENTITY_INSERT [dbo].[tblShift] ON 

INSERT [dbo].[tblShift] ([shiftId], [instructorId], [day], [shift], [created_at], [updated_at]) VALUES (4, 1, N'Tuesday', N'From 12.00 AM to 06.00 AM', CAST(N'2021-09-29T01:29:57.873' AS DateTime), CAST(N'2021-09-29T02:17:29.767' AS DateTime))
INSERT [dbo].[tblShift] ([shiftId], [instructorId], [day], [shift], [created_at], [updated_at]) VALUES (8, 1, N'Friday', N'From 12.00 PM to 06.00 PM', CAST(N'2021-09-29T01:59:41.090' AS DateTime), CAST(N'2021-09-29T01:59:41.090' AS DateTime))
INSERT [dbo].[tblShift] ([shiftId], [instructorId], [day], [shift], [created_at], [updated_at]) VALUES (9, 4, N'Sunday', N'From 12.00 PM to 06.00 PM', CAST(N'2021-09-29T02:17:07.657' AS DateTime), CAST(N'2021-09-29T02:17:17.760' AS DateTime))
INSERT [dbo].[tblShift] ([shiftId], [instructorId], [day], [shift], [created_at], [updated_at]) VALUES (10, 4, N'Thursday', N'From 12.00 PM to 06.00 PM', CAST(N'2021-09-29T02:17:37.127' AS DateTime), CAST(N'2021-09-29T02:17:37.127' AS DateTime))
INSERT [dbo].[tblShift] ([shiftId], [instructorId], [day], [shift], [created_at], [updated_at]) VALUES (13, 7, N'Monday', N'From 06.00 PM to 12.00 AM', CAST(N'2021-10-01T18:18:03.953' AS DateTime), CAST(N'2021-10-05T10:15:51.760' AS DateTime))
INSERT [dbo].[tblShift] ([shiftId], [instructorId], [day], [shift], [created_at], [updated_at]) VALUES (14, 7, N'Thursday', N'From 12.00 PM to 06.00 PM', CAST(N'2021-10-05T01:06:09.130' AS DateTime), CAST(N'2021-10-05T01:06:09.130' AS DateTime))
INSERT [dbo].[tblShift] ([shiftId], [instructorId], [day], [shift], [created_at], [updated_at]) VALUES (15, 7, N'Wednesday', N'From 06.00 PM to 12.00 AM', CAST(N'2021-10-05T10:15:38.760' AS DateTime), CAST(N'2021-10-05T10:15:38.760' AS DateTime))
SET IDENTITY_INSERT [dbo].[tblShift] OFF
GO
SET IDENTITY_INSERT [dbo].[tblTimeSlots] ON 

INSERT [dbo].[tblTimeSlots] ([timeslotId], [memberId], [day], [timeslot], [created_at], [updated_at]) VALUES (1, 4, N'Tuesday', N'From 08.00 AM to 10.00 AM', NULL, CAST(N'2021-10-01T01:52:16.230' AS DateTime))
INSERT [dbo].[tblTimeSlots] ([timeslotId], [memberId], [day], [timeslot], [created_at], [updated_at]) VALUES (2, 4, N'Thursday', N'From 02.00 AM to 04.00 AM', NULL, CAST(N'2021-10-02T01:42:39.100' AS DateTime))
INSERT [dbo].[tblTimeSlots] ([timeslotId], [memberId], [day], [timeslot], [created_at], [updated_at]) VALUES (4, 1, N'Saturday', N'From 10.00 PM to 12.00 AM', NULL, CAST(N'2021-10-01T01:54:15.223' AS DateTime))
INSERT [dbo].[tblTimeSlots] ([timeslotId], [memberId], [day], [timeslot], [created_at], [updated_at]) VALUES (5, 1, N'Saturday', N'From 06.00 PM to 08.00 PM', NULL, CAST(N'2021-10-01T01:54:20.623' AS DateTime))
INSERT [dbo].[tblTimeSlots] ([timeslotId], [memberId], [day], [timeslot], [created_at], [updated_at]) VALUES (6, 1, N'Wednesday', N'From 06.00 PM to 08.00 PM', NULL, CAST(N'2021-10-01T01:54:24.910' AS DateTime))
INSERT [dbo].[tblTimeSlots] ([timeslotId], [memberId], [day], [timeslot], [created_at], [updated_at]) VALUES (7, 3, N'Thursday', N'From 02.00 AM to 04.00 AM', NULL, CAST(N'2021-10-02T00:59:48.203' AS DateTime))
INSERT [dbo].[tblTimeSlots] ([timeslotId], [memberId], [day], [timeslot], [created_at], [updated_at]) VALUES (8, 3, N'Saturday', N'From 08.00 AM to 10.00 AM', NULL, CAST(N'2021-10-02T00:59:18.573' AS DateTime))
INSERT [dbo].[tblTimeSlots] ([timeslotId], [memberId], [day], [timeslot], [created_at], [updated_at]) VALUES (9, 3, N'Sunday', N'From 08.00 AM to 10.00 AM', NULL, CAST(N'2021-10-02T00:59:28.730' AS DateTime))
INSERT [dbo].[tblTimeSlots] ([timeslotId], [memberId], [day], [timeslot], [created_at], [updated_at]) VALUES (10, 3, N'Monday', N'From 06.00 AM to 08.00 AM', NULL, CAST(N'2021-10-02T01:05:25.440' AS DateTime))
INSERT [dbo].[tblTimeSlots] ([timeslotId], [memberId], [day], [timeslot], [created_at], [updated_at]) VALUES (11, 3, N'Tuesday', N'From 02.00 PM to 04.00 PM', NULL, CAST(N'2021-10-02T01:38:26.180' AS DateTime))
INSERT [dbo].[tblTimeSlots] ([timeslotId], [memberId], [day], [timeslot], [created_at], [updated_at]) VALUES (13, 3, N'Friday', N'From 06.00 AM to 08.00 AM', NULL, CAST(N'2021-10-05T10:08:38.873' AS DateTime))
SET IDENTITY_INSERT [dbo].[tblTimeSlots] OFF
GO
SET IDENTITY_INSERT [dbo].[tblUsers] ON 

INSERT [dbo].[tblUsers] ([userId], [username], [password]) VALUES (1, N'admin', N'admin@123')
SET IDENTITY_INSERT [dbo].[tblUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[tblWorkouts] ON 

INSERT [dbo].[tblWorkouts] ([workoutId], [memberId], [exercise], [reps], [sets], [updated_at]) VALUES (1, 1, N'Barbell Curl', 8, 4, CAST(N'2021-09-27T00:49:13.327' AS DateTime))
INSERT [dbo].[tblWorkouts] ([workoutId], [memberId], [exercise], [reps], [sets], [updated_at]) VALUES (2, 3, N'Squat', 9, 3, CAST(N'2021-09-27T01:37:44.400' AS DateTime))
INSERT [dbo].[tblWorkouts] ([workoutId], [memberId], [exercise], [reps], [sets], [updated_at]) VALUES (3, 1, N'Shoulder Press', 8, 3, CAST(N'2021-09-27T01:26:51.457' AS DateTime))
INSERT [dbo].[tblWorkouts] ([workoutId], [memberId], [exercise], [reps], [sets], [updated_at]) VALUES (5, 1, N'Push Down', 12, 3, CAST(N'2021-09-27T01:31:29.360' AS DateTime))
INSERT [dbo].[tblWorkouts] ([workoutId], [memberId], [exercise], [reps], [sets], [updated_at]) VALUES (8, 3, N'Upright', 10, 3, CAST(N'2021-10-02T00:11:02.603' AS DateTime))
INSERT [dbo].[tblWorkouts] ([workoutId], [memberId], [exercise], [reps], [sets], [updated_at]) VALUES (10, 3, N'Curl', 8, 3, CAST(N'2021-10-04T02:46:43.643' AS DateTime))
INSERT [dbo].[tblWorkouts] ([workoutId], [memberId], [exercise], [reps], [sets], [updated_at]) VALUES (11, 3, N'Upright', 12, 3, CAST(N'2021-10-05T10:16:23.467' AS DateTime))
INSERT [dbo].[tblWorkouts] ([workoutId], [memberId], [exercise], [reps], [sets], [updated_at]) VALUES (12, 3, N'Chest Press', 12, 5, CAST(N'2021-10-05T01:08:28.003' AS DateTime))
SET IDENTITY_INSERT [dbo].[tblWorkouts] OFF
GO
USE [master]
GO
ALTER DATABASE [GymManager] SET  READ_WRITE 
GO
