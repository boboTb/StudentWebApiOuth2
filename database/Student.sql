USE [master]
GO
/****** Object:  Database [StudentskaSluzba]    Script Date: 12/15/2021 6:28:40 PM ******/
CREATE DATABASE [StudentskaSluzba]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentskaSluzba', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS2019\MSSQL\DATA\StudentskaSluzba.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudentskaSluzba_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS2019\MSSQL\DATA\StudentskaSluzba_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [StudentskaSluzba] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentskaSluzba].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentskaSluzba] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentskaSluzba] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentskaSluzba] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentskaSluzba] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentskaSluzba] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentskaSluzba] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudentskaSluzba] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentskaSluzba] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentskaSluzba] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentskaSluzba] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentskaSluzba] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentskaSluzba] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentskaSluzba] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentskaSluzba] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentskaSluzba] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudentskaSluzba] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentskaSluzba] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentskaSluzba] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentskaSluzba] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentskaSluzba] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentskaSluzba] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentskaSluzba] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentskaSluzba] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudentskaSluzba] SET  MULTI_USER 
GO
ALTER DATABASE [StudentskaSluzba] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentskaSluzba] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentskaSluzba] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentskaSluzba] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StudentskaSluzba] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StudentskaSluzba] SET QUERY_STORE = OFF
GO
USE [StudentskaSluzba]
GO
/****** Object:  User [IIS APPPOOL\EDW]    Script Date: 12/15/2021 6:28:40 PM ******/
CREATE USER [IIS APPPOOL\EDW] FOR LOGIN [IIS APPPOOL\EDW] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [HET\bobo_r1]    Script Date: 12/15/2021 6:28:40 PM ******/
CREATE USER [HET\bobo_r1] FOR LOGIN [HET\bobo_r1] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[AppUser]    Script Date: 12/15/2021 6:28:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUser](
	[User_ID] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kurs]    Script Date: 12/15/2021 6:28:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kurs](
	[Kurs_ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv_Kursa] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Kurs] PRIMARY KEY CLUSTERED 
(
	[Kurs_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kurs Student]    Script Date: 12/15/2021 6:28:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kurs Student](
	[Kurs_ID] [int] NOT NULL,
	[Student_ID] [int] NOT NULL,
 CONSTRAINT [PK_Kurs_Student] PRIMARY KEY CLUSTERED 
(
	[Kurs_ID] ASC,
	[Student_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status Studenta]    Script Date: 12/15/2021 6:28:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status Studenta](
	[Status_Studenta_ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv_Statusa] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Status_studenta] PRIMARY KEY CLUSTERED 
(
	[Status_Studenta_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 12/15/2021 6:28:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Student_ID] [int] IDENTITY(1,1) NOT NULL,
	[Broj_Indeksa] [nvarchar](10) NOT NULL,
	[Ime] [nvarchar](50) NOT NULL,
	[Prezime] [nvarchar](50) NOT NULL,
	[Status_Studenta] [int] NOT NULL,
	[Godina] [int] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Student_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AppUser] ([User_ID], [UserName], [Password]) VALUES (1, N'Admin', N'Admin')
GO
SET IDENTITY_INSERT [dbo].[Kurs] ON 

INSERT [dbo].[Kurs] ([Kurs_ID], [Naziv_Kursa]) VALUES (1, N'Programiranje')
INSERT [dbo].[Kurs] ([Kurs_ID], [Naziv_Kursa]) VALUES (2, N'Dizajn')
INSERT [dbo].[Kurs] ([Kurs_ID], [Naziv_Kursa]) VALUES (3, N'BazePodataka')
INSERT [dbo].[Kurs] ([Kurs_ID], [Naziv_Kursa]) VALUES (10, N'Racunarske Mreze')
SET IDENTITY_INSERT [dbo].[Kurs] OFF
GO
INSERT [dbo].[Kurs Student] ([Kurs_ID], [Student_ID]) VALUES (1, 1)
INSERT [dbo].[Kurs Student] ([Kurs_ID], [Student_ID]) VALUES (1, 2)
INSERT [dbo].[Kurs Student] ([Kurs_ID], [Student_ID]) VALUES (1, 7)
INSERT [dbo].[Kurs Student] ([Kurs_ID], [Student_ID]) VALUES (2, 1)
INSERT [dbo].[Kurs Student] ([Kurs_ID], [Student_ID]) VALUES (2, 4)
INSERT [dbo].[Kurs Student] ([Kurs_ID], [Student_ID]) VALUES (2, 7)
INSERT [dbo].[Kurs Student] ([Kurs_ID], [Student_ID]) VALUES (3, 1)
INSERT [dbo].[Kurs Student] ([Kurs_ID], [Student_ID]) VALUES (3, 2)
INSERT [dbo].[Kurs Student] ([Kurs_ID], [Student_ID]) VALUES (3, 4)
INSERT [dbo].[Kurs Student] ([Kurs_ID], [Student_ID]) VALUES (10, 1)
INSERT [dbo].[Kurs Student] ([Kurs_ID], [Student_ID]) VALUES (10, 2)
GO
SET IDENTITY_INSERT [dbo].[Status Studenta] ON 

INSERT [dbo].[Status Studenta] ([Status_Studenta_ID], [Naziv_Statusa]) VALUES (1, N'Redovan')
INSERT [dbo].[Status Studenta] ([Status_Studenta_ID], [Naziv_Statusa]) VALUES (2, N'Vanredan')
SET IDENTITY_INSERT [dbo].[Status Studenta] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Student_ID], [Broj_Indeksa], [Ime], [Prezime], [Status_Studenta], [Godina]) VALUES (1, N'11/11', N'Marko', N'Markovic', 1, 1)
INSERT [dbo].[Student] ([Student_ID], [Broj_Indeksa], [Ime], [Prezime], [Status_Studenta], [Godina]) VALUES (2, N'12/11', N'Petar', N'Petrovic', 2, 1)
INSERT [dbo].[Student] ([Student_ID], [Broj_Indeksa], [Ime], [Prezime], [Status_Studenta], [Godina]) VALUES (4, N'13/11', N'John', N'Smith', 1, 1)
INSERT [dbo].[Student] ([Student_ID], [Broj_Indeksa], [Ime], [Prezime], [Status_Studenta], [Godina]) VALUES (7, N'88/33', N'Bozidar', N'Radanovic', 2, 5)
INSERT [dbo].[Student] ([Student_ID], [Broj_Indeksa], [Ime], [Prezime], [Status_Studenta], [Godina]) VALUES (9, N'11/44', N'Bozidar', N'NNNN', 2, 3)
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [DF_Student_Godina]  DEFAULT ((1)) FOR [Godina]
GO
ALTER TABLE [dbo].[Kurs Student]  WITH CHECK ADD  CONSTRAINT [FK_Kurs Student_Kurs] FOREIGN KEY([Kurs_ID])
REFERENCES [dbo].[Kurs] ([Kurs_ID])
GO
ALTER TABLE [dbo].[Kurs Student] CHECK CONSTRAINT [FK_Kurs Student_Kurs]
GO
ALTER TABLE [dbo].[Kurs Student]  WITH CHECK ADD  CONSTRAINT [FK_Kurs Student_Student] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[Student] ([Student_ID])
GO
ALTER TABLE [dbo].[Kurs Student] CHECK CONSTRAINT [FK_Kurs Student_Student]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Status Studenta] FOREIGN KEY([Status_Studenta])
REFERENCES [dbo].[Status Studenta] ([Status_Studenta_ID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Status Studenta]
GO
/****** Object:  StoredProcedure [dbo].[ReadStudent]    Script Date: 12/15/2021 6:28:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[ReadStudent] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT *
     FROM dbo.Student
END
GO
USE [master]
GO
ALTER DATABASE [StudentskaSluzba] SET  READ_WRITE 
GO
