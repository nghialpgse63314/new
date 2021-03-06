USE [master]
GO
/****** Object:  Database [Hotels]    Script Date: 3/26/2019 7:35:13 AM ******/
CREATE DATABASE [Hotels]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Hotels', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.LPGN\MSSQL\DATA\Hotels.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Hotels_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.LPGN\MSSQL\DATA\Hotels_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Hotels] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Hotels].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Hotels] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Hotels] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Hotels] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Hotels] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Hotels] SET ARITHABORT OFF 
GO
ALTER DATABASE [Hotels] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Hotels] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Hotels] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Hotels] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Hotels] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Hotels] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Hotels] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Hotels] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Hotels] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Hotels] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Hotels] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Hotels] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Hotels] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Hotels] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Hotels] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Hotels] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Hotels] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Hotels] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Hotels] SET  MULTI_USER 
GO
ALTER DATABASE [Hotels] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Hotels] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Hotels] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Hotels] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Hotels] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Hotels]
GO
/****** Object:  Table [dbo].[Guest]    Script Date: 3/26/2019 7:35:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guest](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[phone] [int] NULL,
	[roomid] [int] NULL,
 CONSTRAINT [PK_Guest] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 3/26/2019 7:35:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[roomnumber] [int] NOT NULL,
	[status] [nchar](10) NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[roomnumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Guest] ([id], [name], [address], [phone], [roomid]) VALUES (1, N'asd', N'asd', 123, 102)
INSERT [dbo].[Guest] ([id], [name], [address], [phone], [roomid]) VALUES (2, N'c', N'c', 3, 103)
INSERT [dbo].[Guest] ([id], [name], [address], [phone], [roomid]) VALUES (3, N'asd', N'asd', 123, 205)
INSERT [dbo].[Guest] ([id], [name], [address], [phone], [roomid]) VALUES (4, N'qs', N'asd', 123, 202)
INSERT [dbo].[Guest] ([id], [name], [address], [phone], [roomid]) VALUES (5, N'sdasd', N'asdasd1', 312123123, 111)
INSERT [dbo].[Guest] ([id], [name], [address], [phone], [roomid]) VALUES (6, N'asd', N'asd', 123, 104)
INSERT [dbo].[Guest] ([id], [name], [address], [phone], [roomid]) VALUES (7, N'asd', N'asd', 123, 109)
INSERT [dbo].[Guest] ([id], [name], [address], [phone], [roomid]) VALUES (8, N'asd', N'asd', 123, 101)
INSERT [dbo].[Guest] ([id], [name], [address], [phone], [roomid]) VALUES (9, N'asd', N'asd', 123, 105)
INSERT [dbo].[Room] ([roomnumber], [status]) VALUES (101, N'In-used   ')
INSERT [dbo].[Room] ([roomnumber], [status]) VALUES (102, N'In-used   ')
INSERT [dbo].[Room] ([roomnumber], [status]) VALUES (103, N'In-used   ')
INSERT [dbo].[Room] ([roomnumber], [status]) VALUES (104, N'In-used   ')
INSERT [dbo].[Room] ([roomnumber], [status]) VALUES (105, N'In-used   ')
INSERT [dbo].[Room] ([roomnumber], [status]) VALUES (106, N'Available ')
INSERT [dbo].[Room] ([roomnumber], [status]) VALUES (109, N'In-used   ')
INSERT [dbo].[Room] ([roomnumber], [status]) VALUES (111, N'In-used   ')
INSERT [dbo].[Room] ([roomnumber], [status]) VALUES (123, N'Available ')
INSERT [dbo].[Room] ([roomnumber], [status]) VALUES (201, N'In used   ')
INSERT [dbo].[Room] ([roomnumber], [status]) VALUES (202, N'In-used   ')
INSERT [dbo].[Room] ([roomnumber], [status]) VALUES (205, N'In-used   ')
ALTER TABLE [dbo].[Guest]  WITH CHECK ADD  CONSTRAINT [FK_Guest_Room] FOREIGN KEY([roomid])
REFERENCES [dbo].[Room] ([roomnumber])
GO
ALTER TABLE [dbo].[Guest] CHECK CONSTRAINT [FK_Guest_Room]
GO
USE [master]
GO
ALTER DATABASE [Hotels] SET  READ_WRITE 
GO
