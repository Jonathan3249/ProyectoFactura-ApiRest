USE [Fact_Software]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 12/11/2022 14:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompleto] [nvarchar](100) NULL,
	[Direccion] [nvarchar](max) NULL,
	[Telefono] [nvarchar](50) NULL,
	[IdTipoCliente] [int] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 12/11/2022 14:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[IdFactura] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdTarifa] [int] NOT NULL,
	[IdObservaciones] [int] NOT NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Observaciones]    Script Date: 12/11/2022 14:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Observaciones](
	[IdObservaciones] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_Observaciones] PRIMARY KEY CLUSTERED 
(
	[IdObservaciones] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarifas]    Script Date: 12/11/2022 14:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarifas](
	[IdTarifa] [int] IDENTITY(1,1) NOT NULL,
	[TipoTarifa] [nvarchar](50) NULL,
	[Precio] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Tarifas] PRIMARY KEY CLUSTERED 
(
	[IdTarifa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCliente]    Script Date: 12/11/2022 14:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCliente](
	[IdTipoCliente] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionTipo] [nvarchar](100) NULL,
 CONSTRAINT [PK_TipoCliente] PRIMARY KEY CLUSTERED 
(
	[IdTipoCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_TipoCliente] FOREIGN KEY([IdTipoCliente])
REFERENCES [dbo].[TipoCliente] ([IdTipoCliente])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_TipoCliente]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Clientes]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Observaciones] FOREIGN KEY([IdObservaciones])
REFERENCES [dbo].[Observaciones] ([IdObservaciones])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Observaciones]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Tarifas] FOREIGN KEY([IdTarifa])
REFERENCES [dbo].[Tarifas] ([IdTarifa])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Tarifas]
GO
