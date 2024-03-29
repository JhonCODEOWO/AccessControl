USE [master]
GO
/****** Object:  Database [Acceso]    Script Date: 22/05/2023 02:41:49 p. m. ******/
CREATE DATABASE [Acceso]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Acceso', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Acceso.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Acceso_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Acceso_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Acceso] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Acceso].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Acceso] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Acceso] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Acceso] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Acceso] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Acceso] SET ARITHABORT OFF 
GO
ALTER DATABASE [Acceso] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Acceso] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Acceso] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Acceso] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Acceso] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Acceso] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Acceso] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Acceso] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Acceso] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Acceso] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Acceso] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Acceso] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Acceso] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Acceso] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Acceso] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Acceso] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Acceso] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Acceso] SET RECOVERY FULL 
GO
ALTER DATABASE [Acceso] SET  MULTI_USER 
GO
ALTER DATABASE [Acceso] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Acceso] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Acceso] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Acceso] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Acceso] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Acceso', N'ON'
GO
USE [Acceso]
GO
/****** Object:  Table [dbo].[Posesión]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Posesión](
	[ID] [int] NOT NULL,
	[Marca] [varchar](200) NULL,
	[Color] [varchar](40) NULL,
	[Descripción] [varchar](200) NULL,
	[Placas] [varchar](15) NULL,
	[Tipo] [int] NOT NULL,
	[Dueño] [int] NOT NULL,
	[Zona] [int] NOT NULL,
 CONSTRAINT [PK_Posesion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Propietario]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Propietario](
	[ID] [int] NOT NULL,
	[Nombre] [varchar](200) NULL,
	[A_Materno] [varchar](200) NULL,
	[A_Paterno] [varchar](200) NULL,
	[CURP] [varchar](18) NULL,
	[RFC] [varchar](13) NULL,
	[Ubicacion] [varchar](200) NULL,
	[TelefonoPrincipal] [varchar](15) NULL,
	[TelefonoSecundario] [varchar](15) NULL,
	[CorreoElectronico] [varchar](50) NULL,
	[TipoPropietario] [int] NULL,
	[Codigo] [varchar](50) NULL,
	[ImagenPerfil] [varchar](1000) NULL,
 CONSTRAINT [PK_Propietario] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Registro]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registro](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Prop] [int] NULL,
	[ID_Posesion] [int] NULL,
	[HoraEntrada] [datetime] NOT NULL,
 CONSTRAINT [PK_Registro] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoPosesion]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoPosesion](
	[ID] [int] NOT NULL,
	[Nombre_Tipo] [varchar](50) NULL,
 CONSTRAINT [PK_TipoPosesion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoPropietario]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoPropietario](
	[ID] [int] NOT NULL,
	[Nombre_Tipo_Prop] [varchar](100) NULL,
 CONSTRAINT [PK_TipoPropietario] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Zonas]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Zonas](
	[ID] [int] NOT NULL,
	[NombreZona] [varchar](80) NULL,
 CONSTRAINT [PK_Zonas] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Posesión]  WITH CHECK ADD  CONSTRAINT [FK_Dueño] FOREIGN KEY([Dueño])
REFERENCES [dbo].[Propietario] ([ID])
GO
ALTER TABLE [dbo].[Posesión] CHECK CONSTRAINT [FK_Dueño]
GO
ALTER TABLE [dbo].[Posesión]  WITH CHECK ADD  CONSTRAINT [FK_TipoPosesion] FOREIGN KEY([Tipo])
REFERENCES [dbo].[TipoPosesion] ([ID])
GO
ALTER TABLE [dbo].[Posesión] CHECK CONSTRAINT [FK_TipoPosesion]
GO
ALTER TABLE [dbo].[Posesión]  WITH CHECK ADD  CONSTRAINT [FK_Zona] FOREIGN KEY([Zona])
REFERENCES [dbo].[Zonas] ([ID])
GO
ALTER TABLE [dbo].[Posesión] CHECK CONSTRAINT [FK_Zona]
GO
ALTER TABLE [dbo].[Propietario]  WITH CHECK ADD  CONSTRAINT [FK_TipoPropietario] FOREIGN KEY([TipoPropietario])
REFERENCES [dbo].[TipoPropietario] ([ID])
GO
ALTER TABLE [dbo].[Propietario] CHECK CONSTRAINT [FK_TipoPropietario]
GO
ALTER TABLE [dbo].[Registro]  WITH CHECK ADD  CONSTRAINT [FK_Posesión] FOREIGN KEY([ID_Posesion])
REFERENCES [dbo].[Posesión] ([ID])
GO
ALTER TABLE [dbo].[Registro] CHECK CONSTRAINT [FK_Posesión]
GO
ALTER TABLE [dbo].[Registro]  WITH CHECK ADD  CONSTRAINT [FK_Propietario] FOREIGN KEY([ID_Prop])
REFERENCES [dbo].[Propietario] ([ID])
GO
ALTER TABLE [dbo].[Registro] CHECK CONSTRAINT [FK_Propietario]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarPosesion]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarPosesion](
@ID int,
@Marca varchar(200),
@Color varchar(40),
@Descripción varchar(200),
@Placas varchar(15),
@Tipo int,
@Dueño int,
@Zona int
)
AS
UPDATE Posesión SET Marca = @Marca, Color = @Color, Descripción = @Descripción, Placas = @Placas, Tipo = @Tipo, Dueño = @Dueño, Zona = @Zona
WHERE ID = @ID

GO
/****** Object:  StoredProcedure [dbo].[ActualizarPropietario]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarPropietario](
@ID int,
@Nombre varchar(200),
@A_Materno varchar(200),
@A_Paterno varchar(200),
@CURP varchar(18),
@RFC varchar(13),
@Ubicacion varchar(200),
@TelefonoPrincipal varchar(10),
@TelefonoSecundario varchar(10),
@CorreoElectronico varchar(50),
@TipoPropietario int,
@Codigo varchar(50),
@ImagenPerfil varchar(1000)
)
AS
UPDATE Propietario SET Nombre = @Nombre, A_Materno = @A_Materno, A_Paterno = @A_Paterno, CURP = @CURP, RFC = @RFC, Ubicacion = @Ubicacion,
				       TelefonoPrincipal = @TelefonoPrincipal, TelefonoSecundario = @TelefonoSecundario, TipoPropietario = @TipoPropietario, Codigo = @Codigo, ImagenPerfil  = @ImagenPerfil
WHERE ID = @ID

GO
/****** Object:  StoredProcedure [dbo].[ActualizarTipoPosesion]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarTipoPosesion]
(
  @ID int,
  @Nombre_Tipo varchar(50)
)
AS
BEGIN
  UPDATE TipoPosesion
  SET Nombre_Tipo = @Nombre_Tipo
  WHERE ID = @ID
END

GO
/****** Object:  StoredProcedure [dbo].[ActualizarTipoPropietario]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarTipoPropietario]
(
  @ID int,
  @Nombre_Tipo_Prop varchar(100)
)
AS
BEGIN
  UPDATE TipoPropietario
  SET Nombre_Tipo_Prop = @Nombre_Tipo_Prop
  WHERE ID = @ID
END

GO
/****** Object:  StoredProcedure [dbo].[ActualizarZonas]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarZonas]
(
  @ID int,
  @NombreZona varchar(80)
)
AS
BEGIN
  UPDATE Zonas
  SET NombreZona = @NombreZona
  WHERE ID = @ID
END

GO
/****** Object:  StoredProcedure [dbo].[EliminarPosesion]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarPosesion](
@ID int
)
AS
DELETE FROM Posesión WHERE ID = @ID

GO
/****** Object:  StoredProcedure [dbo].[EliminarPropietario]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarPropietario](
@ID int
)
AS	
DELETE FROM Propietario WHERE ID =  @ID

GO
/****** Object:  StoredProcedure [dbo].[EliminarTipoPosesion]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarTipoPosesion]
(
  @ID int
)
AS
BEGIN
  DELETE FROM TipoPosesion
  WHERE ID = @ID
END

GO
/****** Object:  StoredProcedure [dbo].[EliminarTipoPropietario]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarTipoPropietario]
(
  @ID int
)
AS
BEGIN
  DELETE FROM TipoPropietario
  WHERE ID = @ID
END

GO
/****** Object:  StoredProcedure [dbo].[EliminarZonas]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarZonas]
(
  @ID int
)
AS
BEGIN
  DELETE FROM Zonas
  WHERE ID = @ID
END

GO
/****** Object:  StoredProcedure [dbo].[EncontrarIDProp]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EncontrarIDProp](
@Nombre varchar(100)
) 
AS SELECT ID FROM Propietario WHERE Nombre = @Nombre
GO
/****** Object:  StoredProcedure [dbo].[InsertarPosesion]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarPosesion](
@ID int,
@Marca varchar(200),
@Color varchar(40),
@Descripción varchar(200),
@Placas varchar(15),
@Tipo int,
@Dueño int,
@Zona int
)
AS
INSERT INTO Posesión VALUES (@ID, @Marca, @Color, @Descripción, @Placas, @Tipo, @Dueño, @Zona)

GO
/****** Object:  StoredProcedure [dbo].[InsertarPropietario]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarPropietario](
@ID int,
@Nombre varchar(200),
@A_Materno varchar(200),
@A_Paterno varchar(200),
@CURP varchar(18),
@RFC varchar(13),
@Ubicacion varchar(200),
@TelefonoPrincipal varchar(10),
@TelefonoSecundario varchar(10),
@CorreoElectronico varchar(50),
@TipoPropietario int,
@Codigo varchar(50),
@ImagenPerfil varchar(1000)
)
AS
INSERT INTO Propietario VALUES (@ID, @Nombre, @A_Materno, @A_Paterno, @CURP, @RFC, @Ubicacion, @TelefonoPrincipal, @TelefonoSecundario,
								@CorreoElectronico, @TipoPropietario, @Codigo, @ImagenPerfil)

GO
/****** Object:  StoredProcedure [dbo].[InsertarTipoPosesion]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarTipoPosesion]
(
  @ID int,
  @Nombre_Tipo varchar(50)
)
AS
BEGIN
  INSERT INTO TipoPosesion (ID, Nombre_Tipo)
  VALUES (@ID, @Nombre_Tipo)
END

GO
/****** Object:  StoredProcedure [dbo].[InsertarTipoPropietario]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarTipoPropietario]
(
  @ID int,
  @Nombre_Tipo_Prop varchar(100)
)
AS
BEGIN
  INSERT INTO TipoPropietario ( ID, Nombre_Tipo_Prop)
  VALUES (@ID, @Nombre_Tipo_Prop)
END

GO
/****** Object:  StoredProcedure [dbo].[InsertarZonas]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarZonas]
(
  @ID int,
  @NombreZona varchar(80)
)
AS
BEGIN
  INSERT INTO Zonas (ID, NombreZona)
  VALUES (@ID, @NombreZona)
END

GO
/****** Object:  StoredProcedure [dbo].[ListaIdentificacion]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListaIdentificacion](
@Codigo varchar(1000)
) AS SELECT Nombre,A_Paterno AS 'Apellido Paterno', A_Materno AS 'Apellido Materno',Nombre_Tipo_Prop AS 'Tipo de persona', NombreZona AS 'Zona', ImagenPerfil FROM Propietario INNER JOIN TipoPropietario ON Propietario.TipoPropietario = TipoPropietario.ID INNER JOIN Posesión ON Propietario.ID = Posesión.Dueño
																		 INNER JOIN TipoPosesion ON Posesión.Tipo = TipoPosesion.ID INNER JOIN Zonas ON Posesión.Zona = Zonas.ID WHERE Propietario.Codigo = @Codigo;
GO
/****** Object:  StoredProcedure [dbo].[ObetenerAparcamiento]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObetenerAparcamiento](
@Codigo varchar(100)
)
AS
SELECT Nombre, Nombre_Tipo, Marca, Color, NombreZona FROM Posesión INNER JOIN Propietario ON Posesión.Dueño = Propietario.ID INNER JOIN TipoPosesion ON Posesión.Tipo = TipoPosesion.ID INNER JOIN Zonas ON Posesión.Zona = Zonas.ID
WHERE Propietario.Codigo = @Codigo
GO
/****** Object:  StoredProcedure [dbo].[VisualizarPosesiones]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VisualizarPosesiones] AS SELECT Posesión.ID, Nombre_Tipo AS 'Tipo de transporte', Marca,Placas ,Color, Descripción, Nombre AS 'Dueño', NombreZona AS 'Lugar de estacionamiento'FROM Posesión INNER JOIN Propietario ON Posesión.Dueño = Propietario.ID INNER JOIN
															  Zonas  ON Posesión.Zona = Zonas.ID INNER JOIN TipoPosesion ON Posesión.Tipo
															  = TipoPosesion.ID
GO
/****** Object:  StoredProcedure [dbo].[VisualizarPropietarios]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VisualizarPropietarios] AS SELECT * FROM Propietario go
GO
/****** Object:  StoredProcedure [dbo].[VisualizarTipoPosesion]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VisualizarTipoPosesion] AS SELECT * FROM TipoPosesion GO
GO
/****** Object:  StoredProcedure [dbo].[VisualizarTipoPropietario]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[VisualizarTipoPropietario] AS SELECT * FROM TipoPropietario GO
GO
/****** Object:  StoredProcedure [dbo].[VisualizarZonas]    Script Date: 22/05/2023 02:41:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VisualizarZonas] AS SELECT * FROM Zonas
GO
USE [master]
GO
ALTER DATABASE [Acceso] SET  READ_WRITE 
GO
