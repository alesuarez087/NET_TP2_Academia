USE [master]
GO
/****** Object:  Database [tp2_net]    Script Date: 15/02/2018 17:46:31 ******/
CREATE DATABASE [tp2_net]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'tp2_net', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\tp2_net.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'tp2_net_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\tp2_net_log.ldf' , SIZE = 3456KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [tp2_net] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [tp2_net].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [tp2_net] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [tp2_net] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [tp2_net] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [tp2_net] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [tp2_net] SET ARITHABORT OFF 
GO
ALTER DATABASE [tp2_net] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [tp2_net] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [tp2_net] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [tp2_net] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [tp2_net] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [tp2_net] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [tp2_net] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [tp2_net] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [tp2_net] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [tp2_net] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [tp2_net] SET  DISABLE_BROKER 
GO
ALTER DATABASE [tp2_net] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [tp2_net] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [tp2_net] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [tp2_net] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [tp2_net] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [tp2_net] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [tp2_net] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [tp2_net] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [tp2_net] SET  MULTI_USER 
GO
ALTER DATABASE [tp2_net] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [tp2_net] SET DB_CHAINING OFF 
GO
ALTER DATABASE [tp2_net] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [tp2_net] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [tp2_net]
GO
/****** Object:  User [net]    Script Date: 15/02/2018 17:46:33 ******/
CREATE USER [net] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [lol]    Script Date: 15/02/2018 17:46:33 ******/
CREATE USER [lol] WITH DEFAULT_SCHEMA=[db_datareader]
GO
/****** Object:  User [ConexionRemota]    Script Date: 15/02/2018 17:46:33 ******/
CREATE USER [ConexionRemota] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [net]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [net]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [net]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [net]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [net]
GO
ALTER ROLE [db_datareader] ADD MEMBER [net]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [net]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [net]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [net]
GO
/****** Object:  StoredProcedure [dbo].[AdministradorGetAll]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AdministradorGetAll] 
	-- HAY QUE TOMAR UNA DESICION RESPECTO A LA IDENTIDAD DE LOS TIPOS DE PERSONA PORQUE EL DE LA BASE DE DATOS ES INT
	-- Y EN EL CODIGO ES UN TIPO ESPECIAL. ASUMO:
	-- 0-ADMINISTRADORES
	-- 1-ALUMNOS
	-- 2-PROFESORES
	--
AS
BEGIN
	SELECT * 
	FROM personas 
	WHERE personas.tipo_persona = 0
	ORDER BY personas.apellido, personas.nombre
END

GO
/****** Object:  StoredProcedure [dbo].[AdministradorInsert]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AdministradorInsert]
	-- Add the parameters for the stored procedure here
	@nombre varchar(50), @apellido varchar(50), @fecha_nac datetime, @direccion varchar(50), @telefono varchar(50), @email varchar(50), @id_plan int, @tipo int, @legajo int
AS
BEGIN
	INSERT INTO personas(nombre, apellido, fecha_nac, direccion, telefono, email, id_plan, tipo_persona, legajo) 
			VALUES(@nombre, @apellido, @fecha_nac, @direccion, @telefono, @email, @id_plan, @tipo, @legajo)
	SELECT @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[AdministradorUpdate]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AdministradorUpdate]
	-- Add the parameters for the stored procedure here
	@id int, @nombre varchar(50), @apellido varchar(50), @fecha_nac datetime, @direccion varchar(50), @telefono varchar(50), @email varchar(50), @legajo int, @id_plan int
AS
BEGIN
	UPDATE personas SET nombre = @nombre, apellido = @apellido, fecha_nac = @fecha_nac, direccion = @direccion, telefono = @telefono, email = @email, legajo = @legajo, id_plan = @id_plan WHERE id_persona = @id
END

GO
/****** Object:  StoredProcedure [dbo].[AlumnoBuscador]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AlumnoBuscador]
	-- Add the parameters for the stored procedure here
	@texto varchar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM personas
	WHERE tipo_persona = 1 AND (nombre LIKE '%'+@texto+'%' OR apellido LIKE '%'+@texto+'%')
END

GO
/****** Object:  StoredProcedure [dbo].[AlumnoBuscadorNro]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AlumnoBuscadorNro]
	-- Add the parameters for the stored procedure here
	@legajo int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM personas
	WHERE tipo_persona = 1 AND legajo = @legajo
END

GO
/****** Object:  StoredProcedure [dbo].[AlumnoDelete]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AlumnoDelete]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	DELETE FROM personas WHERE tipo_persona = 1 AND id_persona = @id
END

GO
/****** Object:  StoredProcedure [dbo].[AlumnoGetAll]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AlumnoGetAll] 
	-- HAY QUE TOMAR UNA DESICION RESPECTO A LA IDENTIDAD DE LOS TIPOS DE PERSONA PORQUE EL DE LA BASE DE DATOS ES INT
	-- Y EN EL CODIGO ES UN TIPO ESPECIAL. ASUMO:
	-- 0-ADMINISTRADORES
	-- 1-ALUMNOS
	-- 2-PROFESORES
	--
AS
BEGIN
	SELECT * 
	FROM personas 
	INNER JOIN planes ON personas.id_plan = planes.id_plan 
	INNER JOIN especialidades ON planes.id_especialidad = especialidades.id_especialidad
	WHERE personas.tipo_persona = 1
	ORDER BY personas.apellido, personas.nombre
END

GO
/****** Object:  StoredProcedure [dbo].[AlumnoGetAllTabla]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AlumnoGetAllTabla]
	-- HAY QUE TOMAR UNA DESICION RESPECTO A LA IDENTIDAD DE LOS TIPOS DE PERSONA PORQUE EL DE LA BASE DE DATOS ES INT
	-- Y EN EL CODIGO ES UN TIPO ESPECIAL. ASUMO:
	-- 0-ADMINISTRADORES
	-- 1-ALUMNOS
	-- 2-PROFESORES
	--
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM personas WHERE personas.tipo_persona = 1
END

GO
/****** Object:  StoredProcedure [dbo].[AlumnoGetOne]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AlumnoGetOne]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	SELECT * FROM personas WHERE tipo_persona = 1 AND id_persona = @id
END

GO
/****** Object:  StoredProcedure [dbo].[AlumnoInscripcionUpdate]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AlumnoInscripcionUpdate]
	@id int, @nota int, @condicion varchar(50)
AS
BEGIN
	
	UPDATE alumnos_inscripciones 
	SET nota = @nota, condicion = @condicion
	WHERE alumnos_inscripciones.id_inscripcion = @id
END

GO
/****** Object:  StoredProcedure [dbo].[AlumnoInsert]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AlumnoInsert]
	-- Add the parameters for the stored procedure here
	@nombre varchar(50), @apellido varchar(50), @fecha_nac datetime, @direccion varchar(50), @telefono varchar(50), @email varchar(50), @id_plan int, @tipo int, @legajo int
AS
BEGIN
	INSERT INTO personas(nombre, apellido, fecha_nac, direccion, telefono, email, id_plan, tipo_persona, legajo) 
			VALUES(@nombre, @apellido, @fecha_nac, @direccion, @telefono, @email, @id_plan, @tipo, @legajo)
	SELECT @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[AlumnosInscripcionesDelete]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AlumnosInscripcionesDelete]
	@id int
AS
BEGIN
	
	DELETE FROM alumnos_inscripciones WHERE alumnos_inscripciones.id_inscripcion = @id
END

GO
/****** Object:  StoredProcedure [dbo].[AlumnosInscripcionesGetAll]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AlumnosInscripcionesGetAll]
	@id_persona int
AS
BEGIN
	
	SELECT * FROM alumnos_inscripciones 
	INNER JOIN cursos ON alumnos_inscripciones.id_curso = cursos.id_curso
	INNER JOIN materias ON cursos.id_materia = materias.id_materia
	INNER JOIN comisiones ON cursos.id_comision = comisiones.id_comision
	WHERE alumnos_inscripciones.id_alumno = @id_persona
	ORDER BY comisiones.anio_especialidad, cursos.anio_calendario
END

GO
/****** Object:  StoredProcedure [dbo].[AlumnosInscripcionesGetAllComisiones]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AlumnosInscripcionesGetAllComisiones]
	@id_curso int
AS
BEGIN
	
	SELECT * 
	FROM alumnos_inscripciones 
	INNER JOIN cursos ON alumnos_inscripciones.id_curso = cursos.id_curso
	INNER JOIN materias ON cursos.id_materia = materias.id_materia
	INNER JOIN comisiones ON cursos.id_comision = comisiones.id_comision
	INNER JOIN personas ON alumnos_inscripciones.id_alumno = personas.id_persona
	WHERE alumnos_inscripciones.id_curso = @id_curso
END

GO
/****** Object:  StoredProcedure [dbo].[AlumnosInscripcionesGetOne]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AlumnosInscripcionesGetOne]
	@id int
AS
BEGIN
	
	SELECT * FROM alumnos_inscripciones 
	INNER JOIN cursos ON alumnos_inscripciones.id_curso = cursos.id_curso
	INNER JOIN personas ON alumnos_inscripciones.id_alumno = personas.id_persona
	WHERE alumnos_inscripciones.id_inscripcion = @id
END

GO
/****** Object:  StoredProcedure [dbo].[AlumnosInscripcionesInsert]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AlumnosInscripcionesInsert]
	@id_curso int, @id_alumno int, @condicion varchar(50)
AS
BEGIN
	
	INSERT INTO alumnos_inscripciones(id_alumno, id_curso, condicion) VALUES (@id_alumno, @id_curso, @condicion)
	SELECT @@identity
END

GO
/****** Object:  StoredProcedure [dbo].[AlumnoUpdate]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AlumnoUpdate]
	-- Add the parameters for the stored procedure here
	@id int, @nombre varchar(50), @apellido varchar(50), @fecha_nac datetime, @direccion varchar(50), @telefono varchar(50), @email varchar(50), @legajo int, @id_plan int
AS
BEGIN
	UPDATE personas SET nombre = @nombre, apellido = @apellido, fecha_nac = @fecha_nac, direccion = @direccion, telefono = @telefono, email = @email, legajo = @legajo, id_plan = @id_plan WHERE id_persona = @id
END

GO
/****** Object:  StoredProcedure [dbo].[ComisionDelete]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ComisionDelete]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	DELETE docentes_cursos
	FROM docentes_cursos
	JOIN cursos on docentes_cursos.id_curso = cursos.id_curso
	WHERE cursos.id_comision = @id;

	DELETE alumnos_inscripciones
	FROM alumnos_inscripciones
	JOIN cursos on alumnos_inscripciones.id_curso = cursos.id_curso
	WHERE cursos.id_comision = @id;

	DELETE FROM cursos WHERE cursos.id_comision = @id;
	DELETE FROM comisiones WHERE comisiones.id_comision = @id
END

GO
/****** Object:  StoredProcedure [dbo].[ComisionGetAll]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ComisionGetAll] 
	-- Add the parameters for the stored procedure here
AS
BEGIN
	SELECT * 
	FROM comisiones 
	INNER JOIN planes ON comisiones.id_plan = planes.id_plan 
	INNER JOIN especialidades ON planes.id_especialidad = especialidades.id_especialidad
	ORDER BY comisiones.anio_especialidad, comisiones.desc_comision
END

GO
/****** Object:  StoredProcedure [dbo].[ComisionGetOne]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ComisionGetOne]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	SELECT * FROM comisiones WHERE comisiones.id_comision = @id
END

GO
/****** Object:  StoredProcedure [dbo].[ComisionInsert]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ComisionInsert]
	-- Add the parameters for the stored procedure here
	@descripcion varchar(50), @anio_especialidad varchar(50), @id_plan int
AS
BEGIN
	INSERT INTO comisiones(desc_comision, anio_especialidad, id_plan) VALUES(@descripcion, @anio_especialidad, @id_plan)
	SELECT @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[ComisionUpdate]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ComisionUpdate]
	-- Add the parameters for the stored procedure here
	@id int, @desc_comision varchar(50), @anio_especialidad varchar(50), @id_plan int
AS
BEGIN
	UPDATE comisiones SET desc_comision = @desc_comision, anio_especialidad = @anio_especialidad, id_plan = @id_plan WHERE id_comision = @id
END

GO
/****** Object:  StoredProcedure [dbo].[CursoDelete]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CursoDelete]
	@id int
	--
AS
BEGIN
	DELETE FROM docentes_cursos WHERE id_curso = @id;
	DELETE FROM alumnos_inscripciones WHERE id_curso = @id;
	DELETE FROM cursos WHERE cursos.id_curso = @id
END

GO
/****** Object:  StoredProcedure [dbo].[CursoInsert]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CursoInsert]
	-- Add the parameters for the stored procedure here
	@id_materia int, @cupo int, @id_comision int, @anio_calendario int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO cursos(id_materia, id_comision, anio_calendario, cupo) VALUES(@id_materia, @id_comision, @anio_calendario, @cupo)
	SELECT @@identity
END

GO
/****** Object:  StoredProcedure [dbo].[CursosGetAll]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CursosGetAll]
	
	--
AS
BEGIN
	SELECT * 
	FROM cursos
	INNER JOIN materias ON cursos.id_materia = materias.id_materia
	INNER JOIN planes ON materias.id_plan = planes.id_plan
	INNER JOIN comisiones ON cursos.id_comision = comisiones.id_comision
	INNER JOIN especialidades ON especialidades.id_especialidad = planes.id_especialidad
	ORDER BY comisiones.anio_especialidad, comisiones.desc_comision, cursos.anio_calendario
END

GO
/****** Object:  StoredProcedure [dbo].[CursosGetAllComisiones]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CursosGetAllComisiones]
	@id_materia int
AS
BEGIN
	
	SELECT * FROM cursos
	INNER JOIN comisiones ON cursos.id_comision = comisiones.id_comision
	WHERE cursos.id_materia = @id_materia
	ORDER BY comisiones.anio_especialidad, comisiones.desc_comision, cursos.anio_calendario
END

GO
/****** Object:  StoredProcedure [dbo].[CursosGetAllMateriaComision]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CursosGetAllMateriaComision]
	@id_materia int, @id_comision int
AS
BEGIN
	
	SELECT * FROM cursos
	WHERE id_materia = @id_materia and id_comision = @id_comision
END

GO
/****** Object:  StoredProcedure [dbo].[CursosGetOne]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CursosGetOne]
	@id int
	--
AS
BEGIN
	SELECT * 
	FROM cursos 
	INNER JOIN comisiones ON cursos.id_comision = comisiones.id_comision
	INNER JOIN materias ON cursos.id_materia = materias.id_materia
	INNER JOIN planes ON planes.id_plan = materias.id_plan
	WHERE cursos.id_curso = @id
END

GO
/****** Object:  StoredProcedure [dbo].[CursoUpdate]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CursoUpdate]
	-- Add the parameters for the stored procedure here
	@id_curso int, @id_materia int, @id_comision int, @anio_calendario int, @cupo int
AS
BEGIN
	UPDATE cursos SET cupo=@cupo, id_materia=@id_materia, id_comision=@id_comision, anio_calendario=@anio_calendario WHERE Cursos.id_curso = @id_curso

END

GO
/****** Object:  StoredProcedure [dbo].[DocenteBuscador]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DocenteBuscador]
	-- Add the parameters for the stored procedure here
	@texto varchar
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM personas
	WHERE tipo_persona = 2 AND (nombre LIKE '%'+@texto+'%' OR apellido LIKE '%'+@texto+'%')
END

GO
/****** Object:  StoredProcedure [dbo].[DocenteBuscadorLegajo]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DocenteBuscadorLegajo]
	-- Add the parameters for the stored procedure here
	@legajo int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM personas
	WHERE tipo_persona = 2 AND legajo = @legajo
END

GO
/****** Object:  StoredProcedure [dbo].[DocenteCursoDelete]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DocenteCursoDelete]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM docentes_cursos WHERE id_dictado = @id
END

GO
/****** Object:  StoredProcedure [dbo].[DocenteCursoGetAll]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DocenteCursoGetAll]
	@IdCurso int
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM docentes_cursos
		INNER JOIN cursos ON docentes_cursos.id_curso = cursos.id_curso
		INNER JOIN personas ON docentes_cursos.id_docente = personas.id_persona
		INNER JOIN materias ON cursos.id_materia = materias.id_materia
	WHERE docentes_cursos.id_curso = @IdCurso
	ORDER BY cursos.anio_calendario, docentes_cursos.cargo DESC
END
GO
/****** Object:  StoredProcedure [dbo].[DocenteCursoGetOne]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DocenteCursoGetOne]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM docentes_cursos WHERE id_dictado = @id
END

GO
/****** Object:  StoredProcedure [dbo].[DocenteCursoInsert]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DocenteCursoInsert]
	-- Add the parameters for the stored procedure here
	@id_curso int, @cargo int, @id_docente int
AS
BEGIN
	INSERT INTO docentes_cursos(id_curso, id_docente, cargo) VALUES(@id_curso, @id_docente, @cargo)
	SELECT @@identity
END

GO
/****** Object:  StoredProcedure [dbo].[DocenteCursoUpdate]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DocenteCursoUpdate]
	-- Add the parameters for the stored procedure here
	@id int, @id_curso int, @cargo int, @id_docente int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE docentes_cursos SET id_curso = @id_curso, id_docente = @id_docente, cargo = @cargo WHERE id_dictado = @id
END

GO
/****** Object:  StoredProcedure [dbo].[DocenteGetAll]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DocenteGetAll] 
	-- HAY QUE TOMAR UNA DESICION RESPECTO A LA IDENTIDAD DE LOS TIPOS DE PERSONA PORQUE EL DE LA BASE DE DATOS ES INT
	-- Y EN EL CODIGO ES UN TIPO ESPECIAL. ASUMO:
	-- 0-ADMINISTRADORES
	-- 1-ALUMNOS
	-- 2-PROFESORES
	--
AS
BEGIN
	SELECT * 
	FROM personas 
	INNER JOIN planes ON personas.id_plan = planes.id_plan 
	INNER JOIN especialidades ON planes.id_especialidad = especialidades.id_especialidad
	WHERE personas.tipo_persona = 2
	ORDER BY personas.apellido, personas.nombre
END

GO
/****** Object:  StoredProcedure [dbo].[EspecialidadesDelete]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EspecialidadesDelete] 
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN

DELETE docentes_cursos
	
	FROM docentes_cursos
	JOIN personas on personas.id_persona = docentes_cursos.id_docente
	JOIN planes on personas.id_plan = planes.id_plan
	WHERE planes.id_especialidad = @id;

	DELETE alumnos_inscripciones
	FROM alumnos_inscripciones
	JOIN personas on personas.id_persona = alumnos_inscripciones.id_alumno
	JOIN planes on personas.id_plan = planes.id_plan
	WHERE planes.id_especialidad = @id;

	DELETE modulos_usuarios
	FROM modulos_usuarios
	JOIN usuarios on usuarios.id_usuario = modulos_usuarios.id_usuario
	JOIN personas on personas.id_persona = usuarios.id_persona
	JOIN planes on personas.id_plan = planes.id_plan
	WHERE planes.id_especialidad = @id;

	DELETE usuarios
	FROM usuarios
	JOIN personas on personas.id_persona = usuarios.id_persona
	JOIN planes on personas.id_plan = planes.id_plan
	WHERE planes.id_especialidad = @id;

	DELETE cursos
	FROM cursos
	JOIN materias on materias.id_materia = cursos.id_materia
	JOIN comisiones on comisiones.id_comision = cursos.id_comision
	JOIN planes on materias.id_plan = planes.id_plan AND planes.id_plan = comisiones.id_plan
	WHERE planes.id_especialidad = @id;

	DELETE materias
	FROM materias
	JOIN planes ON materias.id_plan = planes.id_plan
	WHERE planes.id_plan = @id;

	DELETE comisiones 
	FROM comisiones 
	JOIN planes ON comisiones.id_plan = planes.id_plan
	WHERE planes.id_plan = @id;

	DELETE personas
	FROM personas 
	JOIN planes ON personas.id_plan = planes.id_plan
	WHERE planes.id_plan = @id;
	
	
	DELETE FROM planes WHERE id_especialidad = @id;
	DELETE FROM especialidades where id_especialidad = @id
END

GO
/****** Object:  StoredProcedure [dbo].[EspecialidadesGetOne]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EspecialidadesGetOne]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
    -- Insert statements for procedure here
	SELECT * from especialidades where id_especialidad = @id ;
END

GO
/****** Object:  StoredProcedure [dbo].[EspecialidadesInsert]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EspecialidadesInsert] 
	-- Add the parameters for the stored procedure here
	@descripcion varchar(50)
AS
BEGIN
	insert into especialidades (desc_especialidad) values (@descripcion)
	SELECT @@IDENTITY
	END

GO
/****** Object:  StoredProcedure [dbo].[EspecialidadGetAll]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EspecialidadGetAll]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	SELECT *
	FROM especialidades
	ORDER BY especialidades.desc_especialidad
END

GO
/****** Object:  StoredProcedure [dbo].[EspecialidadUpdate]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EspecialidadUpdate]
	-- Add the parameters for the stored procedure here
	@id int, @descripcion varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE especialidades SET desc_especialidad = @descripcion
	WHERE id_especialidad = @id
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllDocenteComision]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllDocenteComision]
	@id_persona int
	--
AS
BEGIN
	SELECT * 
	FROM docentes_cursos
	INNER JOIN cursos ON cursos.id_curso = docentes_cursos.id_curso
	INNER JOIN materias ON cursos.id_materia = materias.id_materia
	INNER JOIN planes ON materias.id_plan = planes.id_plan
	INNER JOIN comisiones ON cursos.id_comision = comisiones.id_comision
	INNER JOIN especialidades ON especialidades.id_especialidad = planes.id_especialidad
	WHERE docentes_cursos.id_docente = @id_persona
	order by cursos.anio_calendario, comisiones.anio_especialidad, comisiones.desc_comision, materias.desc_materia

END

GO
/****** Object:  StoredProcedure [dbo].[GetAllWhereComisionAndMaterias]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllWhereComisionAndMaterias]
	@id_materia int
	--
AS
BEGIN
	SELECT * 
	FROM cursos 
	INNER JOIN comisiones ON cursos.id_comision = comisiones.id_comision
	INNER JOIN materias ON cursos.id_materia = materias.id_materia
	INNER JOIN planes ON materias.id_plan = planes.id_plan
	WHERE materias.id_materia = @id_materia
	order by comisiones.desc_comision, cursos.anio_calendario, materias.desc_materia
END

GO
/****** Object:  StoredProcedure [dbo].[GetDocenteCurso]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetDocenteCurso]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM docentes_cursos
		INNER JOIN cursos ON docentes_cursos.id_curso = cursos.id_curso
		INNER JOIN personas ON docentes_cursos.id_docente = personas.id_persona
END

GO
/****** Object:  StoredProcedure [dbo].[InscripcionesGetAll]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InscripcionesGetAll]
	@id_alumno int, @id_plan int, @anio int
AS
BEGIN
	SELECT * 
	FROM alumnos_inscripciones
	inner join personas on alumnos_inscripciones.id_alumno = personas.id_persona
	inner join cursos on alumnos_inscripciones.id_curso = cursos.id_curso
	inner join materias on cursos.id_materia = materias.id_materia
	inner join comisiones on cursos.id_comision = comisiones.id_comision
	where alumnos_inscripciones.id_alumno = @id_alumno and personas.id_plan = @id_plan and cursos.anio_calendario = @anio
END

GO
/****** Object:  StoredProcedure [dbo].[InscripcionesGetAllForAlumno]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InscripcionesGetAllForAlumno]
	@id_alumno int, @id_plan int
AS
BEGIN
	SELECT * 
	FROM alumnos_inscripciones
	inner join personas on alumnos_inscripciones.id_alumno = personas.id_persona
	inner join cursos on alumnos_inscripciones.id_curso = cursos.id_curso
	where alumnos_inscripciones.id_alumno = @id_alumno and personas.id_plan = @id_plan
END

GO
/****** Object:  StoredProcedure [dbo].[InscripcionesGetAllMateriaCursos]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InscripcionesGetAllMateriaCursos]
	@id_materia int, @anio_calendario int
AS
BEGIN
	
	SELECT *
 from cursos
 inner join materias on materias.id_materia = cursos.id_materia
 inner join comisiones on comisiones.id_comision = cursos.id_comision
 inner join planes on planes.id_plan = materias.id_plan and planes.id_plan = comisiones.id_plan
 where materias.id_materia=@id_materia and anio_calendario=@anio_calendario
 order by comisiones.desc_comision
END

GO
/****** Object:  StoredProcedure [dbo].[InscripcionesGetAllMaterias]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InscripcionesGetAllMaterias]
	@id_plan int, @anio_calendario int
AS
BEGIN
	
	SELECT desc_materia 
	from materias 
	INNER JOIN planes ON materias.id_plan = planes.id_plan 
	INNER JOIN especialidades ON planes.id_especialidad = especialidades.id_especialidad
	inner join cursos on cursos.id_materia = materias.id_materia
	where planes.id_plan = @id_plan and cursos.anio_calendario =  @anio_calendario
	group by desc_materia
	order by desc_materia
END

GO
/****** Object:  StoredProcedure [dbo].[Lista_Especialidades]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Lista_Especialidades]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from especialidades
END

GO
/****** Object:  StoredProcedure [dbo].[MateriaDelete]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MateriaDelete] 
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	DELETE docentes_cursos
	FROM docentes_cursos
	JOIN cursos on docentes_cursos.id_curso = cursos.id_curso
	WHERE cursos.id_materia = @id;

	DELETE alumnos_inscripciones
	FROM alumnos_inscripciones
	JOIN cursos on alumnos_inscripciones.id_curso = cursos.id_curso
	WHERE cursos.id_materia = @id;

	DELETE FROM cursos WHERE cursos.id_materia = @id

	DELETE from materias where id_materia = @id
END

GO
/****** Object:  StoredProcedure [dbo].[MateriaGetAll]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MateriaGetAll]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	SELECT * from materias 
	INNER JOIN planes ON materias.id_plan = planes.id_plan 
	INNER JOIN especialidades ON planes.id_especialidad = especialidades.id_especialidad
	order by materias.desc_materia
END

GO
/****** Object:  StoredProcedure [dbo].[MateriaGetAllConPlanDescripcion]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MateriaGetAllConPlanDescripcion]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	SELECT * from materias INNER JOIN planes ON materias.id_plan = planes.id_plan INNER JOIN especialidades ON planes.id_especialidad = especialidades.id_especialidad
END

GO
/****** Object:  StoredProcedure [dbo].[MateriaGetOne]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MateriaGetOne] 
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from materias where id_materia = @id
END

GO
/****** Object:  StoredProcedure [dbo].[MateriaInsert]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MateriaInsert]
	-- Add the parameters for the stored procedure here
	@desc_materia varchar(50), @hs_semanales int, @hs_totales int, @id_plan int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO materias(desc_materia, hs_semanales, hs_totales, id_plan) values (@desc_materia, @hs_semanales, @hs_totales, @id_plan)
	SELECT @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[MateriasGetAllForPlan]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MateriasGetAllForPlan]
	@id_plan int
AS
BEGIN
	
	SELECT materias.id_materia, materias.desc_materia
	from materias 
	INNER JOIN planes ON materias.id_plan = planes.id_plan 
	INNER JOIN especialidades ON planes.id_especialidad = especialidades.id_especialidad
	inner join cursos on cursos.id_materia = materias.id_materia
	where planes.id_plan = @id_plan
	group by materias.desc_materia, materias.id_materia
	order by materias.desc_materia
END

GO
/****** Object:  StoredProcedure [dbo].[MateriaUpdate]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MateriaUpdate] 
	-- Add the parameters for the stored procedure here
	@id_materia int, @desc_materia varchar(50), @hs_semanales int, @hs_totales int, @id_plan int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE materias SET desc_materia = @desc_materia, hs_semanales = @hs_semanales, hs_totales = @hs_totales, id_plan = @id_plan WHERE id_materia = @id_materia
END

GO
/****** Object:  StoredProcedure [dbo].[ModuloGetAll]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModuloGetAll]
	
	--
AS
BEGIN
	SELECT * 
	FROM modulos
	
END

GO
/****** Object:  StoredProcedure [dbo].[ModuloGetOne]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModuloGetOne]
	
	@id int
	--
AS
BEGIN
	SELECT * 
	FROM modulos
	WHERE modulos.id_modulo = @id
END

GO
/****** Object:  StoredProcedure [dbo].[ModuloUsuarioDelete]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModuloUsuarioDelete]
	@id int
	--
AS
BEGIN
	DELETE FROM modulos_usuarios
	WHERE modulos_usuarios.id_modulo_usuario = @id
END

GO
/****** Object:  StoredProcedure [dbo].[ModuloUsuarioGetAll]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModuloUsuarioGetAll]
	@id int
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM modulos_usuarios
	INNER JOIN modulos ON modulos_usuarios.id_modulo = modulos.id_modulo
	INNER JOIN usuarios ON modulos_usuarios.id_usuario = usuarios.id_usuario
	WHERE modulos_usuarios.id_usuario = @id
END
GO
/****** Object:  StoredProcedure [dbo].[ModuloUsuarioGetOne]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModuloUsuarioGetOne]
	@id_moduloUsuario int
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM modulos_usuarios
	INNER JOIN modulos ON modulos_usuarios.id_modulo = modulos.id_modulo
	INNER JOIN usuarios ON modulos_usuarios.id_usuario = usuarios.id_usuario
	WHERE modulos_usuarios.id_modulo_usuario = @id_moduloUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[ModuloUsuarioGetPermisos]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModuloUsuarioGetPermisos]
	@id int
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM modulos_usuarios
	WHERE modulos_usuarios.id_usuario = @id
END
GO
/****** Object:  StoredProcedure [dbo].[ModuloUsuarioInsert]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModuloUsuarioInsert]
	@id_modulo int, @id_usuario int, @alta bit, @baja bit, @consulta bit, @modificacion bit
	--
AS
BEGIN
	INSERT INTO modulos_usuarios(id_modulo, id_usuario, alta, baja, consulta, modificacion)
						 VALUES (@id_modulo, @id_usuario, @alta, @baja, @consulta, @modificacion)
	SELECT @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[ModuloUsuarioUpdate]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModuloUsuarioUpdate]
	@id int, @id_modulo int, @id_usuario int, @alta bit, @baja bit, @consulta bit, @modificacion bit
	--
AS
BEGIN
	UPDATE modulos_usuarios 
	SET alta=@alta, baja=@baja, consulta=@consulta, modificacion=@modificacion
	WHERE id_modulo_usuario = @id
END

GO
/****** Object:  StoredProcedure [dbo].[PersonaDelete]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PersonaDelete]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM docentes_cursos WHERE docentes_cursos.id_docente = @id;
	DELETE FROM alumnos_inscripciones WHERE id_alumno = @id;
	
	DELETE modulos_usuarios
	FROM modulos_usuarios
	JOIN usuarios on usuarios.id_usuario = modulos_usuarios.id_usuario
	WHERE usuarios.id_persona = @id;

	DELETE FROM usuarios WHERE id_persona = @id;
	DELETE FROM personas WHERE id_persona = @id;
END

GO
/****** Object:  StoredProcedure [dbo].[PersonaGetAll]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PersonaGetAll]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM personas
	order by personas.apellido, personas.nombre
END

GO
/****** Object:  StoredProcedure [dbo].[PersonaGetOne]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PersonaGetOne]
	@id int
AS
BEGIN
	SELECT * 
	FROM personas
	WHERE personas.id_persona = @id
END

GO
/****** Object:  StoredProcedure [dbo].[PersonaGetOneForLegajo]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PersonaGetOneForLegajo]
	@idLegajo int
AS
BEGIN
	SELECT * 
	FROM personas
	WHERE personas.legajo = @idLegajo
END

GO
/****** Object:  StoredProcedure [dbo].[PersonaGetOneId]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PersonaGetOneId]
	@id int
AS
BEGIN
	SELECT * 
	FROM personas
	WHERE personas.id_persona = @id
END

GO
/****** Object:  StoredProcedure [dbo].[PersonaInsert]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PersonaInsert]
	-- Add the parameters for the stored procedure here
	@nombre varchar(50), @apellido varchar(50), @fecha_nac datetime, @direccion varchar(50), @telefono varchar(50), @email varchar(50), @id_plan int, @tipo int, @legajo int
	-- HAY QUE TOMAR UNA DESICION RESPECTO A LA IDENTIDAD DE LOS TIPOS DE PERSONA PORQUE EL DE LA BASE DE DATOS ES INT
	-- Y EN EL CODIGO ES UN TIPO ESPECIAL. ASUMO:
	-- 0-ADMINISTRADORES
	-- 1-ALUMNOS
	-- 2-PROFESORES
	--

AS
BEGIN
	INSERT INTO personas(nombre, apellido, fecha_nac, direccion, telefono, email, id_plan, tipo_persona, legajo) 
			VALUES(@nombre, @apellido, @fecha_nac, @direccion, @telefono, @email, @id_plan, @tipo, @legajo)
	SELECT @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[PersonasGetAll]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PersonasGetAll]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM personas
	order by personas.apellido, personas.nombre
END

GO
/****** Object:  StoredProcedure [dbo].[PersonaUpdate]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PersonaUpdate]
	-- Add the parameters for the stored procedure here
	@id int, @nombre varchar(50), @apellido varchar(50), @fecha_nac datetime, @direccion varchar(50), @telefono varchar(50), @email varchar(50), @legajo int, @id_plan int, @tipo int
AS
BEGIN
	UPDATE personas 
	SET nombre = @nombre, apellido = @apellido, fecha_nac = @fecha_nac, direccion = @direccion, telefono = @telefono, email = @email, legajo = @legajo, id_plan = @id_plan, tipo_persona = @tipo
	WHERE id_persona = @id
END

GO
/****** Object:  StoredProcedure [dbo].[PlanDelete]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PlanDelete]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	DELETE docentes_cursos
	FROM docentes_cursos
	JOIN personas on personas.id_persona = docentes_cursos.id_docente
	WHERE personas.id_plan = @id;

	DELETE alumnos_inscripciones
	FROM alumnos_inscripciones
	JOIN personas on personas.id_persona = alumnos_inscripciones.id_alumno
	WHERE personas.id_plan = @id;

	DELETE modulos_usuarios
	FROM modulos_usuarios
	JOIN usuarios on usuarios.id_usuario = modulos_usuarios.id_usuario
	JOIN personas on personas.id_persona = usuarios.id_persona
	WHERE personas.id_plan = @id;

	DELETE usuarios
	FROM usuarios
	JOIN personas on personas.id_persona = usuarios.id_persona
	WHERE personas.id_plan = @id;

	DELETE cursos
	FROM cursos
	JOIN materias on materias.id_materia = cursos.id_materia
	JOIN comisiones on comisiones.id_comision = cursos.id_comision
	WHERE materias.id_plan = @id AND comisiones.id_plan = @id;

	DELETE FROM materias WHERE id_plan = @id;
	DELETE FROM comisiones WHERE id_plan = @id;
	DELETE FROM personas WHERE id_plan = @id;
	DELETE FROM planes WHERE id_plan = @id;
END

GO
/****** Object:  StoredProcedure [dbo].[PlanGetAll]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PlanGetAll]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM planes 
	INNER JOIN especialidades ON planes.id_especialidad = especialidades.id_especialidad 
	ORDER BY planes.desc_plan
END

GO
/****** Object:  StoredProcedure [dbo].[PlanGetAllForEspecialidad]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PlanGetAllForEspecialidad]
	@idEspecialidad int
AS
BEGIN
	
	SELECT *
	FROM planes
	INNER JOIN especialidades ON especialidades.id_especialidad = planes.id_especialidad
	where especialidades.id_especialidad = @idEspecialidad
	order by planes.desc_plan
END

GO
/****** Object:  StoredProcedure [dbo].[PlanGetOne]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PlanGetOne]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM planes WHERE id_plan = @id
END

GO
/****** Object:  StoredProcedure [dbo].[PlanInsert]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PlanInsert]
	-- Add the parameters for the stored procedure here
	@descripcion varchar(50), @id_especialidad varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO planes(desc_plan, id_especialidad) VALUES (@descripcion, @id_especialidad)
	SELECT @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[PlanUpdate]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PlanUpdate]
	-- Add the parameters for the stored procedure here
	@id int, @descripcion varchar(50), @id_especialidad varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE planes SET desc_plan = @descripcion, id_especialidad = @id_especialidad WHERE id_plan = @id
END

GO
/****** Object:  StoredProcedure [dbo].[ProfesorDelete]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProfesorDelete]
	-- HAY QUE TOMAR UNA DESICION RESPECTO A LA IDENTIDAD DE LOS TIPOS DE PERSONA PORQUE EL DE LA BASE DE DATOS ES INT
	-- Y EN EL CODIGO ES UN TIPO ESPECIAL. ASUMO:
	-- 0-ADMINISTRADORES
	-- 1-ALUMNOS
	-- 2-PROFESORES
	--
	@id int
AS
BEGIN
	DELETE FROM personas WHERE id_persona = @id
END

GO
/****** Object:  StoredProcedure [dbo].[ProfesorGetAll]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProfesorGetAll]
	-- HAY QUE TOMAR UNA DESICION RESPECTO A LA IDENTIDAD DE LOS TIPOS DE PERSONA PORQUE EL DE LA BASE DE DATOS ES INT
	-- Y EN EL CODIGO ES UN TIPO ESPECIAL. ASUMO:
	-- 0-ADMINISTRADORES
	-- 1-ALUMNOS
	-- 2-PROFESORES
	--
AS
BEGIN
	SELECT * 
	FROM personas 
	INNER JOIN planes ON personas.id_plan = planes.id_plan 
	INNER JOIN especialidades ON planes.id_especialidad = especialidades.id_especialidad
	WHERE personas.tipo_persona = 2
	ORDER BY personas.apellido, personas.nombre
END

GO
/****** Object:  StoredProcedure [dbo].[ProfesorGetOne]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProfesorGetOne]
	-- HAY QUE TOMAR UNA DESICION RESPECTO A LA IDENTIDAD DE LOS TIPOS DE PERSONA PORQUE EL DE LA BASE DE DATOS ES INT
	-- Y EN EL CODIGO ES UN TIPO ESPECIAL. ASUMO:
	-- 0-ADMINISTRADORES
	-- 1-ALUMNOS
	-- 2-PROFESORES
	--
	@id int
AS
BEGIN
	SELECT * FROM personas WHERE id_persona = @id
END

GO
/****** Object:  StoredProcedure [dbo].[ProfesorInsert]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProfesorInsert]
	@nombre varchar(50), @apellido varchar(50), @fecha_nac datetime, @direccion varchar(50), @telefono varchar(50), @email varchar(50), @id_plan int, @tipo int, @legajo int
AS
BEGIN
	INSERT INTO personas(nombre, apellido, fecha_nac, direccion, telefono, email, id_plan, tipo_persona, legajo) 
				  VALUES(@nombre, @apellido, @fecha_nac, @direccion, @telefono, @email, @id_plan, @tipo, @legajo)
	SELECT @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[ProfesorUpdate]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProfesorUpdate]
	@id int, @nombre varchar(50), @apellido varchar(50), @fecha_nac datetime, @direccion varchar(50), @telefono varchar(50), @email varchar(50), @legajo int, @id_plan int
AS
BEGIN
	UPDATE personas 
	SET nombre = @nombre, apellido = @apellido, fecha_nac = @fecha_nac, direccion = @direccion, telefono = @telefono, email = @email, legajo = @legajo, id_plan = @id_plan 
	WHERE personas.id_persona = @id AND personas.tipo_persona = 2
END

GO
/****** Object:  StoredProcedure [dbo].[Reporte_Cursos]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Reporte_Cursos]
	-- Add the parameters for the stored procedure here
	@id_curso int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select *
from cursos
left join comisiones on cursos.id_comision = comisiones.id_comision
left join materias on cursos.id_materia = materias.id_materia
left join alumnos_inscripciones on cursos.id_curso = alumnos_inscripciones.id_curso
left join planes on materias.id_plan = planes.id_plan AND comisiones.id_plan = planes.id_plan
left join especialidades on planes.id_especialidad = especialidades.id_especialidad
where cursos.id_curso = @id_curso
END

GO
/****** Object:  StoredProcedure [dbo].[ReporteCursos]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReporteCursos]
	@id_curso int
	--
AS
BEGIN
SELECT personas.apellido, personas.nombre, alumnos_inscripciones.condicion, alumnos_inscripciones.nota,
	   cursos.anio_calendario, comisiones.desc_comision, materias.desc_materia
FROM alumnos_inscripciones
INNER JOIN cursos on cursos.id_curso = alumnos_inscripciones.id_curso
INNER JOIN comisiones on cursos.id_comision = comisiones.id_comision
INNER JOIN materias on materias.id_materia = cursos.id_materia
INNER JOIN personas on alumnos_inscripciones.id_alumno = personas.id_persona
WHERE alumnos_inscripciones.id_curso = @id_curso
ORDER BY personas.apellido, personas.nombre
END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioBuscador]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UsuarioBuscador]
	@texto varchar(50)
AS
BEGIN
	SELECT * FROM usuarios 
	WHERE nombre LIKE '%'+@texto+'%' OR apellido LIKE '%'+@texto+'%' OR nombre_usuario LIKE '%'+@texto+'%'
END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioDelete]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UsuarioDelete]
	@id int
AS
BEGIN
	DELETE FROM modulos_usuarios WHERE modulos_usuarios.id_usuario = @id;
	DELETE FROM usuarios WHERE usuarios.id_usuario = @id
END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioGetAll]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UsuarioGetAll]
AS
BEGIN
	SELECT * FROM usuarios
	order by usuarios.apellido, usuarios.nombre
END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioGetOne]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UsuarioGetOne]
	@id int
AS
BEGIN
	SELECT * FROM usuarios 
	WHERE usuarios.id_usuario = @id
END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioGetOneForPersona]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UsuarioGetOneForPersona]
	@id_persona int, @tipo_persona int
AS
BEGIN
	SELECT * FROM usuarios 
	INNER JOIN personas on personas.id_persona = usuarios.id_persona
	WHERE personas.id_persona = @id_persona and personas.tipo_persona = @tipo_persona
	;
END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioGetOneForUser]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UsuarioGetOneForUser]
	@user varchar(50)
AS
BEGIN
	SELECT * FROM usuarios 
	WHERE usuarios.nombre_usuario = @user
END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioGetOneUsrPass]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UsuarioGetOneUsrPass]
	@user varchar(50), @pass varchar(50)
AS
BEGIN
	SELECT * 
	FROM usuarios
	INNER JOIN personas ON usuarios.id_persona = personas.id_persona
	WHERE usuarios.nombre_usuario = @user AND usuarios.clave = @pass
END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioInsert]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UsuarioInsert]
	@user varchar(50), @clave varchar(50), @nombre varchar(50), @apellido varchar(50), @email varchar(50), @habilitado bit, @id_persona int
AS
BEGIN
	INSERT INTO usuarios(nombre_usuario, clave, nombre, apellido, email, habilitado, cambia_clave, id_persona ) 
		   VALUES (@user, @clave, @nombre, @apellido, @email, @habilitado, 0, @id_persona)
	SELECT @@identity
END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioUpdate]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UsuarioUpdate]
	@id int, @user varchar(50), @clave varchar(50), @nombre varchar(50), @apellido varchar(50), @email varchar(50), @habilitado bit
AS
BEGIN
	DECLARE @base varchar(50)
	SELECT @base = usuarios.clave FROM usuarios WHERE usuarios.id_usuario = @id

	IF (@base = @clave)
		BEGIN
			UPDATE usuarios 
			SET nombre_usuario=@user, habilitado=@habilitado, nombre = @nombre, apellido=@apellido, email=@email
			WHERE usuarios.id_usuario = @id
		END
	ELSE
		BEGIN
		UPDATE usuarios 
			SET nombre_usuario=@user, habilitado=@habilitado, nombre = @nombre, apellido=@apellido, email=@email,
				clave = @clave, cambia_clave = 1
			WHERE usuarios.id_usuario = @id
		END
END

GO
/****** Object:  Table [dbo].[alumnos_inscripciones]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[alumnos_inscripciones](
	[id_inscripcion] [int] IDENTITY(1,1) NOT NULL,
	[id_alumno] [int] NOT NULL,
	[id_curso] [int] NOT NULL,
	[condicion] [varchar](50) NOT NULL,
	[nota] [int] NULL,
 CONSTRAINT [PK_alumnos_inscripciones] PRIMARY KEY CLUSTERED 
(
	[id_inscripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[comisiones]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[comisiones](
	[id_comision] [int] IDENTITY(1,1) NOT NULL,
	[desc_comision] [varchar](50) NOT NULL,
	[anio_especialidad] [int] NOT NULL,
	[id_plan] [int] NOT NULL,
 CONSTRAINT [PK_comisiones] PRIMARY KEY CLUSTERED 
(
	[id_comision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cursos]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cursos](
	[id_curso] [int] IDENTITY(1,1) NOT NULL,
	[id_materia] [int] NOT NULL,
	[id_comision] [int] NOT NULL,
	[anio_calendario] [int] NOT NULL,
	[cupo] [int] NOT NULL,
 CONSTRAINT [PK_cursos] PRIMARY KEY CLUSTERED 
(
	[id_curso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[docentes_cursos]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[docentes_cursos](
	[id_dictado] [int] IDENTITY(1,1) NOT NULL,
	[id_curso] [int] NOT NULL,
	[id_docente] [int] NOT NULL,
	[cargo] [int] NOT NULL,
 CONSTRAINT [PK_docentes_cursos] PRIMARY KEY CLUSTERED 
(
	[id_dictado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[especialidades]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[especialidades](
	[id_especialidad] [int] IDENTITY(1,1) NOT NULL,
	[desc_especialidad] [varchar](50) NOT NULL,
 CONSTRAINT [PK_especialidades] PRIMARY KEY CLUSTERED 
(
	[id_especialidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[materias]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[materias](
	[id_materia] [int] IDENTITY(1,1) NOT NULL,
	[desc_materia] [varchar](50) NOT NULL,
	[hs_semanales] [int] NOT NULL,
	[hs_totales] [int] NOT NULL,
	[id_plan] [int] NOT NULL,
 CONSTRAINT [PK_materias] PRIMARY KEY CLUSTERED 
(
	[id_materia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[modulos]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[modulos](
	[id_modulo] [int] IDENTITY(1,1) NOT NULL,
	[desc_modulo] [varchar](50) NULL,
	[ejecuta] [varchar](50) NULL,
 CONSTRAINT [PK_modulos] PRIMARY KEY CLUSTERED 
(
	[id_modulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[modulos_usuarios]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[modulos_usuarios](
	[id_modulo_usuario] [int] IDENTITY(1,1) NOT NULL,
	[id_modulo] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
	[alta] [bit] NULL,
	[baja] [bit] NULL,
	[modificacion] [bit] NULL,
	[consulta] [bit] NULL,
 CONSTRAINT [PK_modulos_usuarios] PRIMARY KEY CLUSTERED 
(
	[id_modulo_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[personas]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[personas](
	[id_persona] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[direccion] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[fecha_nac] [datetime] NOT NULL,
	[legajo] [int] NULL,
	[tipo_persona] [int] NOT NULL,
	[id_plan] [int] NOT NULL,
 CONSTRAINT [PK_personas] PRIMARY KEY CLUSTERED 
(
	[id_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[planes]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[planes](
	[id_plan] [int] IDENTITY(1,1) NOT NULL,
	[desc_plan] [varchar](50) NOT NULL,
	[id_especialidad] [int] NOT NULL,
 CONSTRAINT [PK_planes] PRIMARY KEY CLUSTERED 
(
	[id_plan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 15/02/2018 17:46:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre_usuario] [varchar](50) NOT NULL,
	[clave] [varchar](50) NOT NULL,
	[habilitado] [bit] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[email] [varchar](50) NULL,
	[cambia_clave] [bit] NULL,
	[id_persona] [int] NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[alumnos_inscripciones]  WITH CHECK ADD  CONSTRAINT [FK_alumnos_inscripciones_cursos] FOREIGN KEY([id_curso])
REFERENCES [dbo].[cursos] ([id_curso])
GO
ALTER TABLE [dbo].[alumnos_inscripciones] CHECK CONSTRAINT [FK_alumnos_inscripciones_cursos]
GO
ALTER TABLE [dbo].[alumnos_inscripciones]  WITH CHECK ADD  CONSTRAINT [FK_alumnos_inscripciones_personas] FOREIGN KEY([id_alumno])
REFERENCES [dbo].[personas] ([id_persona])
GO
ALTER TABLE [dbo].[alumnos_inscripciones] CHECK CONSTRAINT [FK_alumnos_inscripciones_personas]
GO
ALTER TABLE [dbo].[comisiones]  WITH CHECK ADD  CONSTRAINT [FK_comisiones_planes] FOREIGN KEY([id_plan])
REFERENCES [dbo].[planes] ([id_plan])
GO
ALTER TABLE [dbo].[comisiones] CHECK CONSTRAINT [FK_comisiones_planes]
GO
ALTER TABLE [dbo].[cursos]  WITH CHECK ADD  CONSTRAINT [FK_cursos_comisiones] FOREIGN KEY([id_comision])
REFERENCES [dbo].[comisiones] ([id_comision])
GO
ALTER TABLE [dbo].[cursos] CHECK CONSTRAINT [FK_cursos_comisiones]
GO
ALTER TABLE [dbo].[cursos]  WITH CHECK ADD  CONSTRAINT [FK_cursos_materias] FOREIGN KEY([id_materia])
REFERENCES [dbo].[materias] ([id_materia])
GO
ALTER TABLE [dbo].[cursos] CHECK CONSTRAINT [FK_cursos_materias]
GO
ALTER TABLE [dbo].[docentes_cursos]  WITH CHECK ADD  CONSTRAINT [FK_docentes_cursos_cursos] FOREIGN KEY([id_curso])
REFERENCES [dbo].[cursos] ([id_curso])
GO
ALTER TABLE [dbo].[docentes_cursos] CHECK CONSTRAINT [FK_docentes_cursos_cursos]
GO
ALTER TABLE [dbo].[docentes_cursos]  WITH CHECK ADD  CONSTRAINT [FK_docentes_cursos_personas] FOREIGN KEY([id_docente])
REFERENCES [dbo].[personas] ([id_persona])
GO
ALTER TABLE [dbo].[docentes_cursos] CHECK CONSTRAINT [FK_docentes_cursos_personas]
GO
ALTER TABLE [dbo].[materias]  WITH CHECK ADD  CONSTRAINT [FK_materias_planes] FOREIGN KEY([id_plan])
REFERENCES [dbo].[planes] ([id_plan])
GO
ALTER TABLE [dbo].[materias] CHECK CONSTRAINT [FK_materias_planes]
GO
ALTER TABLE [dbo].[modulos_usuarios]  WITH CHECK ADD  CONSTRAINT [FK_modulos_usuarios_modulos] FOREIGN KEY([id_modulo])
REFERENCES [dbo].[modulos] ([id_modulo])
GO
ALTER TABLE [dbo].[modulos_usuarios] CHECK CONSTRAINT [FK_modulos_usuarios_modulos]
GO
ALTER TABLE [dbo].[modulos_usuarios]  WITH CHECK ADD  CONSTRAINT [FK_modulos_usuarios_usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[modulos_usuarios] CHECK CONSTRAINT [FK_modulos_usuarios_usuarios]
GO
ALTER TABLE [dbo].[personas]  WITH CHECK ADD  CONSTRAINT [FK_personas_planes] FOREIGN KEY([id_plan])
REFERENCES [dbo].[planes] ([id_plan])
GO
ALTER TABLE [dbo].[personas] CHECK CONSTRAINT [FK_personas_planes]
GO
ALTER TABLE [dbo].[planes]  WITH CHECK ADD  CONSTRAINT [FK_planes_especialidades] FOREIGN KEY([id_especialidad])
REFERENCES [dbo].[especialidades] ([id_especialidad])
GO
ALTER TABLE [dbo].[planes] CHECK CONSTRAINT [FK_planes_especialidades]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_personas] FOREIGN KEY([id_persona])
REFERENCES [dbo].[personas] ([id_persona])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_personas]
GO
USE [master]
GO
ALTER DATABASE [tp2_net] SET  READ_WRITE 
GO
