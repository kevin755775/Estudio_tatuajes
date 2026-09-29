/*CREATE DATABASE estudio_tatuajes_db;
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

INSERT INTO [Personas] ([Nombre], [NroDoc], [Telefono], [Correo], [FechaNac])
VALUES
('Carlos Andrés Gómez', '10203040', '3001234567', 'carlos.gomez@email.com', '1992-04-12'),
('María Fernanda Rojas', '10203041', '3119876543', 'maria.rojas@email.com', '1998-09-25'),
('Juan Pablo Martínez', '10203042', '3204567890', 'juan.martinez@email.com', '1988-11-03'),
('Laura Sofia Valencia', '10203043', '3156549870', 'laura.valencia@email.com', '2001-01-15'),
('Diego Alejandro Torres', '10203044', '3027891234', 'diego.torres@email.com', '1995-07-30'),
('Mateo Ruiz Henao', '10203045', '3004561234', 'mateo.ruiz@email.com', '1990-03-18'),
('Camila Restrepo Cano', '10203046', '3123456789', 'camila.restrepo@email.com', '1996-08-22'),
('Esteban Morales Ortiz', '10203047', '3187654321', 'esteban.morales@email.com', '1985-12-05'),
('Paula Andrea Castro', '10203048', '3019876543', 'paula.castro@email.com', '1999-05-14'),
('Daniel Felipe Vargas', '10203049', '3101122334', 'daniel.vargas@email.com', '1993-10-08'),
('Andrea Carolina Ríos', '10203050', '3045566778', 'andrea.rios@email.com', '1997-02-28'),
('Gabriel José Salazar', '10203051', '3169988776', 'gabriel.salazar@email.com', '2000-11-19'),
('Natalia Isabel Silva', '10203052', '3003344556', 'natalia.silva@email.com', '1994-06-07'),
('Jorge Luis Mendoza', '10203053', '3132211445', 'jorge.mendoza@email.com', '1989-09-01'),
('Valentina Osorio Gil', '10203054', '3056677889', 'valentina.osorio@email.com', '2002-04-03');

INSERT INTO [Sedes] ([Nombre], [Direccion], [Telefono], [Ciudad])
VALUES
('Estudio Central', 'Av. Poblado #10-20', '6044441122', 'Medellín'),
('Estudio Norte', 'Cl. 85 #15-30', '6013334455', 'Bogotá'),
('Estudio Chapinero', 'Cra. 7 #55-40', '6012223344', 'Bogotá'),
('Estudio Laureles', 'Tr. 39 #72-12', '6045556677', 'Medellín'),
('Estudio Granada', 'Av. 4 Norte #12-45', '6028889900', 'Cali');

INSERT INTO [Portafolios] ([Titulo], [Descripcion], [FechaUltAct], [TotalDisenos])
VALUES
('Sombras y Realismo', 'Trabajos de rostros y retratos en escala de grises', '2026-08-01', 45),
('Neotradicional Color', 'Diseños neotradicionales con paletas vibrantes', '2026-07-28', 32),
('Microrealismo Fineline', 'Trazos finos, letras y piezas pequeñas detalladas', '2026-08-12', 60),
('Oriental & Irezumi', 'Composiciones asiáticas, dragones y carpas koi', '2026-06-19', 28),
('Geometría y Blackwork', 'Patrones geométricos y piezas saturadas en negro', '2026-08-20', 50);

INSERT INTO [Descuentos] ([Codigo], [PorcentajeDesc], [Estado])
VALUES
(1001, 10.00, 1),
(1002, 15.00, 1),
(1003, 20.00, 0),
(1004, 25.00, 1),
(1005, 30.00, 0);

INSERT INTO [EstilosTatuajes] ([Nombre], [Descripcion], [NivelDificultad])
VALUES
('Realismo', 'Reproducción fiel de fotografías y sombras detalladas', 'Alta'),
('Neo Tradicional', 'Trazos gruesos con gradientes detallados y color vivo', 'Media'),
('Linework / Fineline', 'Líneas finas y precisas sin sombras complejas', 'Media'),
('Blackwork', 'Uso exclusivo de tinta negra con altas saturaciones', 'Alta'),
('Acuarela', 'Efecto de pintura de agua sin bordes negros definidos', 'Alta');

INSERT INTO [Consentimientos] ([FechaFirma], [MayorEdad], [FirmaSiNo], [Observaciones])
VALUES
('2026-08-01', 1, 1, 'Ninguna afección reportada'),
('2026-08-02', 1, 1, 'Cliente declara no consumir anticoagulantes'),
('2026-08-05', 1, 1, 'Sin alergias a tintas o anestesia'),
('2026-08-10', 1, 1, 'Proceso prolongado; cliente informado de pausas'),
('2026-08-12', 1, 1, 'Alergia leve al látex; usar guantes de nitrilo');

INSERT INTO [Pagos] ([MetodoPago], [Valor], [Fecha], [Referencia])
VALUES
('Transferencia', 405000.00, '2026-08-01', 'TR-987654'),
('Tarjeta Crédito', 680000.00, '2026-08-02', 'CR-112233'),
('Efectivo', 144000.00, '2026-08-05', 'EF-000123'),
('Transferencia', 900000.00, '2026-08-10', 'TR-456789'),
('Tarjeta Débito', 245000.00, '2026-08-12', 'DB-556677');

INSERT INTO [Proveedores] ([NombreEmpresa], [Telefono], [Direccion], [Correo], [Tipo])
VALUES
('Tattoo Supplies Co', '6017778899', 'Cra. 50 #12-34', 'ventas@tattoosupplies.com', 'Insumos Médicos'),
('InkMaster Distributors', '6049991122', 'Cl. 10 #43-21', 'contacto@inkmaster.com', 'Tintas y Agujas'),
('CareTattoo Hygiene', '6023332211', 'Av. 6 #20-10', 'pedidos@caretattoo.com', 'Higiene y Sanidad'),
('Piercing & BodyArt', '6014445566', 'Cl. 100 #19-05', 'info@piercingbodyart.com', 'Joyería y Merchandising'),
('Equipos Dermógrafos SA', '6042228811', 'Cra. 70 #32-15', 'soporte@dermografos.com', 'Maquinaria');

INSERT INTO [Clientes] ([TipoPiel], [Alergias], [Persona])
VALUES
('Sensible', 'Ninguna', 2),
('Mixta', 'Látex', 4),
('Normal', 'Ninguna', 6),
('Grasa', 'Yodo', 10),
('Sensible', 'Ninguna', 13);

INSERT INTO [Empleados] ([Cargo], [Salario], [FechaIngreso], [Sede], [Persona])
VALUES
('Administrador', 2500000.00, '2024-01-15', 1, 3),
('Recepcionista', 1400000.00, '2024-06-01', 1, 7),
('Auxiliar de Aseo', 1300000.00, '2025-02-10', 2, 8),
('Contador', 3000000.00, '2023-11-01', 2, 12),
('Recepcionista', 1400000.00, '2025-05-20', 3, 14);

INSERT INTO [Tatuadores] ([Licencia], [AnExperiencia], [Especialidad], [Portafolio], [Persona], [Sede])
VALUES
('LIC-2021-001', 8, 'Realismo', 1, 1, 1),
('LIC-2022-045', 5, 'Neo Tradicional', 2, 5, 1),
('LIC-2019-089', 10, 'Linework', 3, 9, 2),
('LIC-2020-112', 7, 'Blackwork', 5, 11, 2),
('LIC-2023-018', 4, 'Acuarela', 4, 15, 3);

INSERT INTO [Cotizaciones] ([ValorEstimado], [FechaEmision], [VigenciaDias], [Tatuador], [Descuento])
VALUES
(450000.00, '2026-07-25', 15, 1, 1),
(800000.00, '2026-07-28', 30, 2, 2),
(180000.00, '2026-08-01', 10, 3, 3),
(120000.00, '2026-08-03', 20, 4, 4),
(350000.00, '2026-08-05', 15, 5, 5);

INSERT INTO [Gastos] ([Valor], [Descripcion], [Fecha], [Categoria], [Sede])
VALUES
(1200000.00, 'Pago de arrendamiento local', '2026-08-01 08:00:00', 'Alquiler', 1),
(350000.00, 'Servicio de energía y agua', '2026-08-03 10:30:00', 'Servicios', 1),
(180000.00, 'Mantenimiento preventivo autoclave', '2026-08-05 15:00:00', 'Mantenimiento', 2),
(95000.00, 'Compra de insumos de cafetería', '2026-08-08 11:20:00', 'Varios', 2),
(210000.00, 'Servicio de internet fibra óptica', '2026-08-10 09:15:00', 'Servicios', 3);

INSERT INTO [Tatuajes] ([ZonaCuerpo], [Ancho], [Alto], [Color], [EstiloTatuaje])
VALUES
('Antebrazo', 5.00, 15.00, 0, 1),
('Muslo', 10.50, 22.00, 1, 2),
('Muñeca', 6.00, 5.00, 0, 3),
('Espalda', 22.00, 30.00, 0, 4),
('Costillas', 20.00, 12.50, 1, 5);

INSERT INTO [Sesiones] ([NroSesion], [DuracionHrs], [FechaInicio], [Tatuaje])
VALUES
(1, 3.50, '2026-08-01', 1),
(1, 4.00, '2026-08-02', 2),
(2, 3.00, '2026-08-16', 2),
(1, 1.50, '2026-08-05', 3),
(1, 5.00, '2026-08-10', 4);

INSERT INTO [Facturas] ([Fecha], [Hora], [Total], [IVA], [Pago])
VALUES
('2026-08-01', '13:30:00', 405000.00, 19.00, 1),
('2026-08-02', '18:15:00', 680000.00, 19.00, 2),
('2026-08-05', '12:45:00', 144000.00, 19.00, 3),
('2026-08-10', '14:20:00', 900000.00, 19.00, 4),
('2026-08-12', '17:00:00', 245000.00, 19.00, 5);

INSERT INTO [ProductosVentas] ([Nombre], [Precio], [Stock], [Marca], [Proveedores], [Sede])
VALUES
('Crema Cuidado Post-Tatuaje 50g', 35000.00, 50, 'BalmTattoo', 1, 1),
('Jabón Neutro Antiséptico 250ml', 22000.00, 30, 'CareClean', 3, 1),
('Piercing Catenaria Titanio', 45000.00, 100, 'BodyArt, Inc', 4, 2),
('Espuma Limpiadora 150ml', 28000.00, 25, 'CareTattoo', 3, 2),
('Parche Curativo Film (Rollo)', 60000.00, 15, 'ProtectInk', 1, 3);

INSERT INTO [Implementos] ([Nombre], [Precio], [Stock], [Marca], [Proveedores], [Sede])
VALUES
('Agujas RL3 Cero 0.35mm (Caja)', 85000.00, 20, 'KWADRON', 2, 1),
('Tinta Negra Dynamic 8oz', 14000.00, 12, 'Dynamic Color', 2, 1),
('Guantes Nitrilo Negro M (Caja)', 32000.00, 40, 'CareHand', 1, 2),
('Papel Hectográfico Spirit (Caja)', 110000.00, 8, 'Reprofx', 1, 2),
('Anestesia Tópica TKTX 10g', 40000.00, 15, 'TKTX', 3, 3);

INSERT INTO [Citas] ([FechaHora], [Estado], [Tatuaje], [Consentimiento], [Factura], [Sede], [Cliente], [Tatuador])
VALUES
('2026-08-01 10:00:00', 'Completada', 1, 1, 1, 1, 1, 1),
('2026-08-02 14:00:00', 'Completada', 2, 2, 2, 1, 2, 2),
('2026-08-05 11:00:00', 'Completada', 3, 3, 3, 2, 3, 3),
('2026-08-10 09:00:00', 'Completada', 4, 4, 4, 2, 4, 4),
('2026-08-12 15:00:00', 'Pendiente', 5, 5, 5, 3, 5, 5);

INSERT INTO [DetallesFacturas] ([Cantidad], [PrecioUnitario], [Subtotal], [Factura], [Producto])
VALUES
(2, 35000.00, 70000.00, 1, 1),
(1, 22000.00, 22000.00, 1, 2),
(1, 45000.00, 45000.00, 2, 3),
(2, 28000.00, 56000.00, 3, 4),
(1, 60000.00, 60000.00, 5, 5);

*/