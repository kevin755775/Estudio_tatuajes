CREATE DATABASE estudio_tatuajes_db;
GO

USE estudio_tatuajes_db;
GO


CREATE TABLE [Personas] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Nombre] NVARCHAR(200) NOT NULL,
    [NroDoc] NVARCHAR(50) NOT NULL UNIQUE,
    [Telefono] NVARCHAR(50) NOT NULL,
    [Correo] NVARCHAR(100) NOT NULL,
    [FechaNac] SMALLDATETIME NOT NULL
);

CREATE TABLE [Sedes] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [Direccion] NVARCHAR(200) NOT NULL,
    [Telefono] NVARCHAR(50) NOT NULL,
    [Ciudad] NVARCHAR(100) NOT NULL
);

CREATE TABLE [Portafolios] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Titulo] NVARCHAR(200) NOT NULL,
    [Descripcion] NVARCHAR(500) NOT NULL,
    [FechaUltAct] SMALLDATETIME NOT NULL,
    [TotalDisenos] INT NOT NULL
);

CREATE TABLE [Descuentos] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Codigo] INT NOT NULL UNIQUE,
    [PorcentajeDesc] DECIMAL(10, 2) NOT NULL,
    [Estado] BIT NOT NULL
);

CREATE TABLE [EstilosTatuajes] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [Descripcion] NVARCHAR(500) NOT NULL,
    [NivelDificultad] NVARCHAR(50) NOT NULL
);

CREATE TABLE [Consentimientos] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [FechaFirma] SMALLDATETIME NOT NULL,
    [MayorEdad] BIT NOT NULL,
    [FirmaSiNo] BIT NOT NULL,
    [Observaciones] NVARCHAR(500) NOT NULL
);

CREATE TABLE [Pagos] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [MetodoPago] NVARCHAR(50) NOT NULL,
    [Valor] DECIMAL(10, 2) NOT NULL,
    [Fecha] SMALLDATETIME NOT NULL,
    [Referencia] NVARCHAR(100) NOT NULL
);

CREATE TABLE [Proveedores] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [NombreEmpresa] NVARCHAR(200) NOT NULL,
    [Telefono] NVARCHAR(50) NOT NULL,
    [Direccion] NVARCHAR(200) NOT NULL,
    [Correo] NVARCHAR(100) NOT NULL,
    [Tipo] NVARCHAR(100) NOT NULL
);


CREATE TABLE [Clientes] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [TipoPiel] NVARCHAR(100) NOT NULL,
    [Alergias] NVARCHAR(500) NOT NULL,
    [Persona] INT NOT NULL REFERENCES [Personas]([Id])
);

CREATE TABLE [Empleados] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Cargo] NVARCHAR(100) NOT NULL,
    [Salario] DECIMAL(10, 2) NOT NULL,
    [FechaIngreso] SMALLDATETIME NOT NULL,
    [Sede] INT NOT NULL REFERENCES [Sedes]([Id]),
    [Persona] INT NOT NULL REFERENCES [Personas]([Id])
);

CREATE TABLE [Tatuadores] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Licencia] NVARCHAR(100) NOT NULL,
    [AnExperiencia] INT NOT NULL,
    [Especialidad] NVARCHAR(100) NOT NULL,
    [Portafolio] INT NOT NULL REFERENCES [Portafolios]([Id]),
    [Persona] INT NOT NULL REFERENCES [Personas]([Id]),
    [Sede] INT NOT NULL REFERENCES [Sedes]([Id])
);

CREATE TABLE [Cotizaciones] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [ValorEstimado] DECIMAL(10, 2) NOT NULL,
    [FechaEmision] SMALLDATETIME NOT NULL,
    [VigenciaDias] INT NOT NULL,
    [Tatuador] INT NOT NULL REFERENCES [Tatuadores]([Id]),
    [Descuento] INT NOT NULL REFERENCES [Descuentos]([Id])
);

CREATE TABLE [Gastos] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Valor] DECIMAL(10, 2) NOT NULL,
    [Descripcion] NVARCHAR(500) NOT NULL,
    [Fecha] SMALLDATETIME NOT NULL,
    [Categoria] NVARCHAR(100) NOT NULL,
    [Sede] INT NOT NULL REFERENCES [Sedes]([Id])
);

CREATE TABLE [Tatuajes] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [ZonaCuerpo] NVARCHAR(100) NOT NULL,
    [Ancho] DECIMAL(10, 2) NOT NULL,
    [Alto] DECIMAL(10, 2) NOT NULL,
    [Color] BIT NOT NULL,
    [EstiloTatuaje] INT NOT NULL REFERENCES [EstilosTatuajes]([Id])
);

CREATE TABLE [Sesiones] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [NroSesion] INT NOT NULL,
    [DuracionHrs] DECIMAL(10, 2) NOT NULL,
    [FechaInicio] SMALLDATETIME NOT NULL,
    [Tatuaje] INT NOT NULL REFERENCES [Tatuajes]([Id])
);

CREATE TABLE [Facturas] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Fecha] SMALLDATETIME NOT NULL,
    [Hora] TIME NOT NULL, 
    [Total] DECIMAL(10, 2) NOT NULL,
    [IVA] DECIMAL(10, 2) NOT NULL,
    [Pago] INT NOT NULL REFERENCES [Pagos]([Id])
);

CREATE TABLE [ProductosVentas] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Nombre] NVARCHAR(200) NOT NULL,
    [Precio] DECIMAL(10, 2) NOT NULL,
    [Stock] INT NOT NULL,
    [Marca] NVARCHAR(100) NOT NULL,
    [Proveedores] INT NOT NULL REFERENCES [Proveedores]([Id]),
    [Sede] INT NOT NULL REFERENCES [Sedes]([Id])
);

CREATE TABLE [Implementos] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Nombre] NVARCHAR(200) NOT NULL,
    [Precio] DECIMAL(10, 2) NOT NULL,
    [Stock] INT NOT NULL,
    [Marca] NVARCHAR(100) NOT NULL,
    [Proveedores] INT NOT NULL REFERENCES [Proveedores]([Id]),
    [Sede] INT NOT NULL REFERENCES [Sedes]([Id])
);

CREATE TABLE [Citas] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [FechaHora] SMALLDATETIME NOT NULL,
    [Estado] NVARCHAR(50) NOT NULL,
    [Tatuaje] INT NOT NULL REFERENCES [Tatuajes]([Id]),
    [Consentimiento] INT NOT NULL REFERENCES [Consentimientos]([Id]),
    [Factura] INT NOT NULL REFERENCES [Facturas]([Id]),
    [Sede] INT NOT NULL REFERENCES [Sedes]([Id]),
    [Cliente] INT NOT NULL REFERENCES [Clientes]([Id]),
    [Tatuador] INT NOT NULL REFERENCES [Tatuadores]([Id])
);

CREATE TABLE [DetallesFacturas] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    [Cantidad] INT NOT NULL,
    [PrecioUnitario] DECIMAL(10, 2) NOT NULL,
    [Subtotal] DECIMAL(10, 2) NOT NULL,
    [Factura] INT NOT NULL REFERENCES [Facturas]([Id]),
    [Producto] INT NOT NULL REFERENCES [ProductosVentas]([Id])
);

