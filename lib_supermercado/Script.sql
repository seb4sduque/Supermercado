
/*
CREATE DATABASE SupermercadoDB;
GO

USE SupermercadoDB;
GO

CREATE TABLE Bodegas (
    Id INT IDENTITY(1, 1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255) NULL,
    Capacidad DECIMAL(18,2) NOT NULL,
    Estado NVARCHAR(50) NOT NULL
);

CREATE TABLE Cargos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255) NULL,
    SalarioBase DECIMAL(18,2) NOT NULL,
    NivelAcceso NVARCHAR(50) NOT NULL
);

CREATE TABLE Categorias (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255) NULL,
    Estado NVARCHAR(50) NOT NULL,
    FechaCreacion DATETIME NOT NULL
);

CREATE TABLE MetodosPago (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255) NULL,
    RequiereBanco BIT NOT NULL,
    MontoMinimo DECIMAL(18,2) NOT NULL
);

CREATE TABLE Personas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    Telefono NVARCHAR(50) NULL,
    Correo NVARCHAR(100) NULL,
    Documento NVARCHAR(50) NOT NULL
);

CREATE TABLE Turnos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    HoraInicio TIME NOT NULL,
    HoraFin TIME NOT NULL,
    Festivos BIT NOT NULL
);

CREATE TABLE Subcategorias (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255) NULL,
    Impuesto DECIMAL(5,2) NOT NULL,
    Categoria INT NOT NULL,
    CONSTRAINT FK_Subcategorias_Categorias FOREIGN KEY (Categoria) REFERENCES Categorias(Id)
);

CREATE TABLE Clientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Estado NVARCHAR(50) NOT NULL,
    Persona INT NOT NULL,
    CONSTRAINT FK_Clientes_Personas FOREIGN KEY (Persona) REFERENCES Personas(Id)
);

CREATE TABLE Empleados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FechaContratacion DATETIME NOT NULL,
    Persona INT NOT NULL,
    Cargo INT NOT NULL,
    CONSTRAINT FK_Empleados_Personas FOREIGN KEY (Persona) REFERENCES Personas(Id),
    CONSTRAINT FK_Empleados_Cargos FOREIGN KEY (Cargo) REFERENCES Cargos(Id)
);

CREATE TABLE Proveedores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Direccion NVARCHAR(255) NOT NULL,
    NombreEmpresa NVARCHAR(150) NOT NULL,
    TipoProveedor NVARCHAR(50) NOT NULL,
    Persona INT NOT NULL,
    CONSTRAINT FK_Proveedores_Personas FOREIGN KEY (Persona) REFERENCES Personas(Id)
);

CREATE TABLE Productos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(150) NOT NULL,
    Precio DECIMAL(18,2) NOT NULL,
    CodigoBarras NVARCHAR(100) NOT NULL,
    Subcategoria INT NOT NULL,
    CONSTRAINT FK_Productos_Subcategorias FOREIGN KEY (Subcategoria) REFERENCES Subcategorias(Id)
);

CREATE TABLE ComprasProveedores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NumeroFactura INT NOT NULL,
    FechaCompra DATETIME NOT NULL,
    TotalCompra DECIMAL(18,2) NOT NULL,
    Proveedor INT NOT NULL,
    CONSTRAINT FK_ComprasProveedores_Proveedores FOREIGN KEY (Proveedor) REFERENCES Proveedores(Id)
);

CREATE TABLE Facturas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FechaHora DATETIME NOT NULL,
    TotalPagar DECIMAL(18,2) NOT NULL,
    Estado NVARCHAR(50) NOT NULL,
    Cliente INT NOT NULL,
    Empleado INT NOT NULL,
    MetodoPago INT NOT NULL,
    CONSTRAINT FK_Facturas_Clientes FOREIGN KEY (Cliente) REFERENCES Clientes(Id),
    CONSTRAINT FK_Facturas_Empleados FOREIGN KEY (Empleado) REFERENCES Empleados(Id),
    CONSTRAINT FK_Facturas_MetodosPago FOREIGN KEY (MetodoPago) REFERENCES MetodosPago(Id)
);

CREATE TABLE ProgramacionTurnos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FechaAsignacion DATETIME NOT NULL,
    HorasExtras INT NOT NULL,
    Empleado INT NOT NULL,
    Turno INT NOT NULL,
    CONSTRAINT FK_ProgramacionTurnos_Empleados FOREIGN KEY (Empleado) REFERENCES Empleados(Id),
    CONSTRAINT FK_ProgramacionTurnos_Turnos FOREIGN KEY (Turno) REFERENCES Turnos(Id)
);

CREATE TABLE SueldoEmpleados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MontoPagado DECIMAL(18,2) NOT NULL,
    FechaPago DATETIME NOT NULL,
    MetodoPago NVARCHAR(50) NOT NULL,
    Empleado INT NOT NULL,
    CONSTRAINT FK_SueldoEmpleados_Empleados FOREIGN KEY (Empleado) REFERENCES Empleados(Id)
);

CREATE TABLE Inventarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Stock INT NOT NULL,
    StockMinimo INT NOT NULL,
    Producto INT NOT NULL,
    Bodega INT NOT NULL,
    CONSTRAINT FK_Inventarios_Productos FOREIGN KEY (Producto) REFERENCES Productos(Id),
    CONSTRAINT FK_Inventarios_Bodegas FOREIGN KEY (Bodega) REFERENCES Bodegas(Id)
);

CREATE TABLE DetallesCompras (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PrecioCompra DECIMAL(18,2) NOT NULL,
    Cantidad INT NOT NULL,
    Producto INT NOT NULL,
    CompraProveedor INT NOT NULL,
    CONSTRAINT FK_DetallesCompras_Productos FOREIGN KEY (Producto) REFERENCES Productos(Id),
    CONSTRAINT FK_DetallesCompras_ComprasProveedores FOREIGN KEY (CompraProveedor) REFERENCES ComprasProveedores(Id)
);

CREATE TABLE DetallesFacturas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL,
    Factura INT NOT NULL,
    Producto INT NOT NULL,
    CONSTRAINT FK_DetallesFacturas_Facturas FOREIGN KEY (Factura) REFERENCES Facturas(Id),
    CONSTRAINT FK_DetallesFacturas_Productos FOREIGN KEY (Producto) REFERENCES Productos(Id)
);

CREATE TABLE CuentasCobrar (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SaldoPendiente DECIMAL(18,2) NOT NULL,
    EstadoDeuda NVARCHAR(50) NOT NULL,
    Cliente INT NOT NULL,
    Factura INT NOT NULL,
    CONSTRAINT FK_CuentasCobrar_Clientes FOREIGN KEY (Cliente) REFERENCES Clientes(Id),
    CONSTRAINT FK_CuentasCobrar_Facturas FOREIGN KEY (Factura) REFERENCES Facturas(Id)
);

CREATE TABLE MovimientosInventarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TipoMovimiento NVARCHAR(50) NOT NULL,
    CantidadMovimiento INT NOT NULL,
    FechaHora DATETIME NOT NULL,
    Inventario INT NOT NULL,
    CONSTRAINT FK_MovimientosInventarios_Inventarios FOREIGN KEY (Inventario) REFERENCES Inventarios(Id)
);

USE SupermercadoDB;
GO

-- =====================================================
-- NIVEL 1: Tablas que NO dependen de otras
-- =====================================================

INSERT INTO Bodegas (Nombre, Descripcion, Capacidad, Estado) VALUES
('Bodega Principal', 'Bodega central de almacenamiento', 5000.00, 'Activa'),
('Bodega Secundaria', 'Bodega para productos de baja rotación', 2000.00, 'Activa');

INSERT INTO Cargos (Nombre, Descripcion, SalarioBase, NivelAcceso) VALUES
('Administrador', 'Gestión general del negocio', 3500000.00, 'Total'),
('Cajero', 'Atención y cobro a clientes', 1500000.00, 'Medio');

INSERT INTO Categorias (Nombre, Descripcion, Estado, FechaCreacion) VALUES
('Bebidas', 'Gaseosas, jugos y agua', 'Activa', '2026-01-10T08:00:00'),
('Alimentos', 'Productos alimenticios', 'Activa', '2026-01-10T08:05:00');

INSERT INTO MetodosPago (Nombre, Descripcion, RequiereBanco, MontoMinimo) VALUES
('Efectivo', 'Pago en efectivo', 0, 0.00),
('Tarjeta', 'Tarjeta débito o crédito', 1, 5000.00);

INSERT INTO Personas (Nombre, Telefono, Correo, Documento) VALUES
('Carlos Gómez', '3001112233', 'carlos.gomez@correo.com', '1001001001'),
('María Rodríguez', '3002223344', 'maria.rodriguez@correo.com', '1002002002');

INSERT INTO Turnos (Nombre, HoraInicio, HoraFin, Festivos) VALUES
('Mañana', '06:00:00', '14:00:00', 0),
('Tarde', '14:00:00', '22:00:00', 0);

USE SupermercadoDB;
GO


-- =====================================================
-- NIVEL 2: Dependen de tablas del nivel 1
-- =====================================================

INSERT INTO Subcategorias (Nombre, Descripcion, Impuesto, Categoria) VALUES
(N'Gaseosas', N'Bebidas carbonatadas', 19.00, 1),
(N'Lácteos', N'Leche, queso y derivados', 5.00, 2);

INSERT INTO Clientes (Estado, Persona) VALUES
(N'Activo', 1),
(N'Activo', 2);

INSERT INTO Empleados (FechaContratacion, Persona, Cargo) VALUES
('2025-03-01T08:00:00', 1, 1),
('2025-06-15T08:00:00', 2, 2);

INSERT INTO Proveedores (Direccion, NombreEmpresa, TipoProveedor, Persona) VALUES
(N'Calle 10 # 20-30, Medellín', N'Distribuidora Andina', N'Bebidas', 1),
(N'Carrera 50 # 15-20, Envigado', N'Alimentos del Valle', N'Alimentos', 2);

-- =====================================================
-- NIVEL 3: Dependen de tablas del nivel 2
-- =====================================================

INSERT INTO Productos (Nombre, Precio, CodigoBarras, Subcategoria) VALUES
(N'Gaseosa Cola 1.5L', 5500.00, N'7701234567890', 1),
(N'Leche Entera 1L', 4200.00, N'7709876543210', 2);

INSERT INTO ComprasProveedores (NumeroFactura, FechaCompra, TotalCompra, Proveedor) VALUES
(1001, '2026-08-01T09:00:00', 400000.00, 1),
(1002, '2026-08-05T10:30:00', 300000.00, 2);

INSERT INTO Facturas (FechaHora, TotalPagar, Estado, Cliente, Empleado, MetodoPago) VALUES
('2026-09-10T10:15:00', 5500.00, N'Pagada', 1, 2, 1),
('2026-09-11T16:40:00', 8400.00, N'Pendiente', 2, 2, 2);

INSERT INTO ProgramacionTurnos (FechaAsignacion, HorasExtras, Empleado, Turno) VALUES
('2026-09-15T00:00:00', 0, 1, 1),
('2026-09-15T00:00:00', 2, 2, 2);

INSERT INTO SueldoEmpleados (MontoPagado, FechaPago, MetodoPago, Empleado) VALUES
(3500000.00, '2026-09-30T00:00:00', N'Transferencia', 1),
(1500000.00, '2026-09-30T00:00:00', N'Transferencia', 2);

-- =====================================================
-- NIVEL 4: Dependen de tablas del nivel 3
-- =====================================================

INSERT INTO Inventarios (Stock, StockMinimo, Producto, Bodega) VALUES
(100, 20, 1, 1),
(100, 15, 2, 2);

INSERT INTO DetallesCompras (PrecioCompra, Cantidad, Producto, CompraProveedor) VALUES
(4000.00, 100, 1, 1),
(3000.00, 100, 2, 2);

INSERT INTO DetallesFacturas (Cantidad, PrecioUnitario, Factura, Producto) VALUES
(1, 5500.00, 1, 1),
(2, 4200.00, 2, 2);

INSERT INTO CuentasCobrar (SaldoPendiente, EstadoDeuda, Cliente, Factura) VALUES
(0.00, N'Pagada', 1, 1),
(8400.00, N'Pendiente', 2, 2);

-- =====================================================
-- NIVEL 5: Dependen de Inventarios
-- =====================================================

INSERT INTO MovimientosInventarios (TipoMovimiento, CantidadMovimiento, FechaHora, Inventario) VALUES
(N'Entrada', 100, '2026-08-01T09:30:00', 1),
(N'Salida', 1, '2026-09-10T10:15:00', 1);
GO




*/