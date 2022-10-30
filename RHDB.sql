Declare Varchar(100)
Create Database []
Go
USE [dwirhedb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26/07/2022 05:36:09 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 26/07/2022 05:36:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[CorreoE] [nvarchar](max) NOT NULL,
	[FotoDir] [nvarchar](max) NULL,
	[Depart] [int] NOT NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spObtEmplPorId]    Script Date: 26/07/2022 05:36:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[spObtEmplPorId]
                            @Id int
                            as
                            Begin
                            	Select * from Empleados
                            	Where Id = @Id
                            End
GO

Declare @DN int = 0;
Declare @DRH int = 1;
Declare @DTI int = 2;
Declare @DC int = 3;
Declare @PM Varchar(100) = 'mary.jpg';
Declare @PJ Varchar(100) = 'john.jpg';
Declare @PS Varchar(100) = 'sara.jpg';
Declare @PC Varchar(100) = 'carl.png';
Declare @PP Varchar(100) = 'park.jpg';
Declare @PH Varchar(100) = 'paty.jpg';
Insert Into dbo.Empleados (Nombre,CorreoE,FotoDir,Depart) Values
('Mary Rose','mary@pragimtech.com',@PM,@DRH),
('John Park','john@pragimtech.com',@PJ,@DTI),
('Sara Parner','sara@pragimtech.com',@PS,@DN),
('David','david@pragimtech.com',null,@DC),
('Carl','carl@pragimtech.com',@PC,@DTI),
('Park','park@pragimtech.com',@PP,@DTI),
('Paty','paty@pragimtech.com',@PH,@DTI),
('Juan','juan@gmail.com',null,@DRH),
('Gen','gen@pragimtech.com',null,@DC),
('Lan','lan@pragimtech.com',null,@DN)

Create Procedure spObtEmplPorId
@Id int
as
Begin
	Select * from Empleados
	Where Id = @Id
End

Execute spObtEmplPorId 2

Create Proc spAgrEmpl
@Nom nvarchar(100),
@CorrE nvarchar(100),
@FotoDir nvarchar(100),
@Dep int
As
Begin
	Insert Into Empleados (Nombre,CorreoE,FotoDir,Depart)
	Values (@Nom,@CorrE,@FotoDir,@Dep)
End