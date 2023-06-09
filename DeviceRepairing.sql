USE [master]
GO

/****** Object:  Database [DeviceRepairing]    Script Date: 17.05.2023 4:40:38 ******/
CREATE DATABASE [DeviceRepairing]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DeviceRepairing', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DeviceRepairing.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DeviceRepairing_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DeviceRepairing_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DeviceRepairing].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [DeviceRepairing] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [DeviceRepairing] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [DeviceRepairing] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [DeviceRepairing] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [DeviceRepairing] SET ARITHABORT OFF 
GO

ALTER DATABASE [DeviceRepairing] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [DeviceRepairing] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [DeviceRepairing] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [DeviceRepairing] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [DeviceRepairing] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [DeviceRepairing] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [DeviceRepairing] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [DeviceRepairing] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [DeviceRepairing] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [DeviceRepairing] SET  DISABLE_BROKER 
GO

ALTER DATABASE [DeviceRepairing] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [DeviceRepairing] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [DeviceRepairing] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [DeviceRepairing] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [DeviceRepairing] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [DeviceRepairing] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [DeviceRepairing] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [DeviceRepairing] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [DeviceRepairing] SET  MULTI_USER 
GO

ALTER DATABASE [DeviceRepairing] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [DeviceRepairing] SET DB_CHAINING OFF 
GO

ALTER DATABASE [DeviceRepairing] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [DeviceRepairing] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [DeviceRepairing] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [DeviceRepairing] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [DeviceRepairing] SET QUERY_STORE = OFF
GO

ALTER DATABASE [DeviceRepairing] SET  READ_WRITE 
GO

