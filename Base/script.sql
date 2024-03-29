USE [redsocialort]
GO
/****** Object:  Table [dbo].[Lugar]    Script Date: 09/18/2014 21:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lugar](
	[UsuarioID] [int] NOT NULL,
	[HorarioDesde] [datetime] NULL,
	[HorarioHasta] [datetime] NULL,
	[DirCalle] [nvarchar](100) NOT NULL,
	[DirNro] [int] NOT NULL,
 CONSTRAINT [PK_Lugar] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Amigo]    Script Date: 09/18/2014 21:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amigo](
	[UsuarioID] [int] NOT NULL,
	[UsuarioIDAmigo] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
 CONSTRAINT [PK_Amigo] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC,
	[UsuarioIDAmigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musico]    Script Date: 09/18/2014 21:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musico](
	[UsuarioID] [int] NOT NULL,
	[UsuarioFechaNacimiento] [date] NOT NULL,
	[UsuarioGenero] [nvarchar](100) NOT NULL,
	[CuentaYoutube] [nvarchar](100) NULL,
	[CuentaFacebook] [nvarchar](100) NULL,
	[CuentaSoundCloud] [nvarchar](100) NULL,
	[CuentaTwitter] [nvarchar](100) NULL,
 CONSTRAINT [PK_Musico] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 09/18/2014 21:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioNombre] [nvarchar](30) NOT NULL,
	[UsuarioPerfil] [char](1) NOT NULL,
	[UsuarioEmail] [nvarchar](100) NOT NULL,
	[UsuarioPassword] [nvarchar](100) NOT NULL,
	[UsuarioProvincia] [nvarchar](100) NOT NULL,
	[UsuarioCiudad] [nvarchar](100) NOT NULL,
	[UsuarioFoto] [nvarchar](100) NULL,
	[UsuarioFechaRegistracion] [datetime] NOT NULL,
	[UsuarioFechaActualizacion] [datetime] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Solicitud]    Script Date: 09/18/2014 21:09:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitud](
	[SolicitudID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[UsuarioIDSolicita] [int] NOT NULL,
	[SolicitudEstadoID] [tinyint] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_Solicitud] PRIMARY KEY CLUSTERED 
(
	[SolicitudID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1=Pendiente
2=Aceptada
3=Rechazada' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Solicitud', @level2type=N'COLUMN',@level2name=N'SolicitudEstadoID'
GO
/****** Object:  StoredProcedure [dbo].[UsuarioBuscarPorEmailPassword]    Script Date: 09/18/2014 21:09:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuarioBuscarPorEmailPassword]

@UsuarioEmail nvarchar(100),
@UsuarioPassword nvarchar(100)

AS

SELECT	*
FROM	Usuario u
LEFT JOIN Musico m ON u.UsuarioID = m.UsuarioID
LEFT JOIN Lugar l ON u.UsuarioID = l.UsuarioID
WHERE	UsuarioEmail = @UsuarioEmail AND
		UsuarioPassword = @UsuarioPassword
GO
/****** Object:  StoredProcedure [dbo].[UsuarioBuscarEmail]    Script Date: 09/18/2014 21:09:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuarioBuscarEmail]

@UsuarioEmail nvarchar(100)

AS

IF EXISTS (SELECT * FROM Usuario WHERE UsuarioEmail = @UsuarioEmail)
	SELECT 1
ELSE
	SELECT 0
GO
/****** Object:  StoredProcedure [dbo].[UsuarioBuscar]    Script Date: 09/18/2014 21:09:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuarioBuscar]

@UsuarioNombre nvarchar(100)

AS

SELECT TOP 10 * 
FROM	Usuario u
LEFT JOIN Musico m ON u.UsuarioID = m.UsuarioID
LEFT JOIN Lugar l ON u.UsuarioID = l.UsuarioID
WHERE UsuarioNombre LIKE '%'+@UsuarioNombre+'%'
/****** Object:  StoredProcedure [dbo].[UsuarioActualizarFoto]    Script Date: 09/27/2013 14:29:50 ******/
SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[UsuarioActualizarFoto]    Script Date: 09/18/2014 21:09:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuarioActualizarFoto]

@UsuarioID int,
@UsuarioFoto nvarchar(100)

AS

UPDATE	Usuario
SET		UsuarioFoto = @UsuarioFoto
WHERE	UsuarioID = @UsuarioID
GO
/****** Object:  StoredProcedure [dbo].[MusicoInsert]    Script Date: 09/18/2014 21:09:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MusicoInsert]


@UsuarioNombre nvarchar(30),
@UsuarioPerfil char (1),
@UsuarioEmail nvarchar(100),
@UsuarioPassword nvarchar(100),
@UsuarioProvincia nvarchar(100),
@UsuarioCiudad nvarchar(100),
@UsuarioFechaRegistracion datetime,
@UsuarioFechaNacimiento date,
@UsuarioGenero nvarchar(100),
@UsuarioID int output

AS

BEGIN TRANSACTION
INSERT INTO Usuario
(
UsuarioNombre,
UsuarioPerfil,
UsuarioEmail,
UsuarioPassword,
UsuarioProvincia,
UsuarioCiudad,
UsuarioFechaRegistracion
)
VALUES
(
@UsuarioNombre,
@UsuarioPerfil,
@UsuarioEmail,
@UsuarioPassword,
@UsuarioProvincia,
@UsuarioCiudad,
@UsuarioFechaRegistracion
)

SET @UsuarioID = (SELECT @@IDENTITY)

INSERT INTO Musico
(
UsuarioID,
UsuarioFechaNacimiento,
UsuarioGenero
)
VALUES
(
@UsuarioID,
@UsuarioFechaNacimiento,
@UsuarioGenero
)

COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[LugarInsert]    Script Date: 09/18/2014 21:09:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LugarInsert]


@UsuarioNombre nvarchar(30),
@UsuarioPerfil char (1),
@UsuarioEmail nvarchar(100),
@UsuarioPassword nvarchar(100),
@UsuarioProvincia nvarchar(100),
@UsuarioCiudad nvarchar(100),
@UsuarioFechaRegistracion datetime,
@DirCalle nvarchar (100),
@DirNro int,
@UsuarioID int output

AS

BEGIN TRANSACTION
INSERT INTO Usuario
(
UsuarioNombre,
UsuarioPerfil,
UsuarioEmail,
UsuarioPassword,
UsuarioProvincia,
UsuarioCiudad,
UsuarioFechaRegistracion
)
VALUES
(
@UsuarioNombre,
@UsuarioPerfil,
@UsuarioEmail,
@UsuarioPassword,
@UsuarioProvincia,
@UsuarioCiudad,
@UsuarioFechaRegistracion
)

SET @UsuarioID = (SELECT @@IDENTITY)

INSERT INTO Lugar
(
UsuarioID,
DirCalle,
DirNro
)
VALUES
(
@UsuarioID,
@DirCalle,
@DirNro
)


COMMIT TRANSACTION
GO
/****** Object:  Default [DF_Amigo_FechaAlta]    Script Date: 09/18/2014 21:09:28 ******/
ALTER TABLE [dbo].[Amigo] ADD  CONSTRAINT [DF_Amigo_FechaAlta]  DEFAULT (getdate()) FOR [FechaAlta]
GO
/****** Object:  Default [DF_Solicitud_FechaAlta]    Script Date: 09/18/2014 21:09:28 ******/
ALTER TABLE [dbo].[Solicitud] ADD  CONSTRAINT [DF_Solicitud_FechaAlta]  DEFAULT (getdate()) FOR [FechaAlta]
GO
