CREATE DATABASE SupermercadoDB;
GO

USE SupermercadoDB;
GO

CREATE TABLE Bodegas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255) NULL,
    Capacidad DECIMAL(18,2) NOT NULL,
    Estado VARCHAR(50) NOT NULL
);

CREATE TABLE Cargos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255) NULL,
    SalarioBase DECIMAL(18,2) NOT NULL,
    NivelAcceso VARCHAR(50) NOT NULL
);

CREATE TABLE Categorias (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255) NULL,
    Estado VARCHAR(50) NOT NULL,
    FechaCreacion DATETIME NOT NULL
);

CREATE TABLE MetodosPago (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255) NULL,
    RequiereBanco BIT NOT NULL,
    MontoMinimo DECIMAL(18,2) NOT NULL
);

CREATE TABLE Personas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(150) NOT NULL,
    Telefono VARCHAR(50) NULL,
    Correo VARCHAR(100) NULL,
    Documento VARCHAR(50) NOT NULL
);

CREATE TABLE Turnos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    HoraInicio TIME NOT NULL,
    HoraFin TIME NOT NULL,
    Festivos BIT NOT NULL
);

CREATE TABLE Subcategorias (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255) NULL,
    Impuesto DECIMAL(5,2) NOT NULL,
    CategoriaId INT NOT NULL,
    CONSTRAINT FK_Subcategorias_Categorias FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id)
);

CREATE TABLE Clientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Estado VARCHAR(50) NOT NULL,
    PersonaId INT NOT NULL,
    CONSTRAINT FK_Clientes_Personas FOREIGN KEY (PersonaId) REFERENCES Personas(Id)
);

CREATE TABLE Empleados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FechaContratacion DATETIME NOT NULL,
    PersonaId INT NOT NULL,
    CargoId INT NOT NULL,
    CONSTRAINT FK_Empleados_Personas FOREIGN KEY (PersonaId) REFERENCES Personas(Id),
    CONSTRAINT FK_Empleados_Cargos FOREIGN KEY (CargoId) REFERENCES Cargos(Id)
);

CREATE TABLE Proveedores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Direccion VARCHAR(255) NOT NULL,
    NombreEmpresa VARCHAR(150) NOT NULL,
    TipoProveedor VARCHAR(50) NOT NULL,
    PersonaId INT NOT NULL,
    CONSTRAINT FK_Proveedores_Personas FOREIGN KEY (PersonaId) REFERENCES Personas(Id)
);

CREATE TABLE Productos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(150) NOT NULL,
    Precio DECIMAL(18,2) NOT NULL,
    CodigoBarras VARCHAR(100) NOT NULL,
    SubcategoriaId INT NOT NULL,
    CONSTRAINT FK_Productos_Subcategorias FOREIGN KEY (SubcategoriaId) REFERENCES Subcategorias(Id)
);

CREATE TABLE ComprasProveedores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NumeroFactura INT NOT NULL,
    FechaCompra DATETIME NOT NULL,
    TotalCompra DECIMAL(18,2) NOT NULL,
    ProveedorId INT NOT NULL,
    CONSTRAINT FK_ComprasProveedores_Proveedores FOREIGN KEY (ProveedorId) REFERENCES Proveedores(Id)
);

CREATE TABLE Facturas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FechaHora DATETIME NOT NULL,
    TotalPagar DECIMAL(18,2) NOT NULL,
    Estado VARCHAR(50) NOT NULL,
    ClienteId INT NOT NULL,
    EmpleadoId INT NOT NULL,
    MetodoPagoId INT NOT NULL,
    CONSTRAINT FK_Facturas_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id),
    CONSTRAINT FK_Facturas_Empleados FOREIGN KEY (EmpleadoId) REFERENCES Empleados(Id),
    CONSTRAINT FK_Facturas_MetodosPago FOREIGN KEY (MetodoPagoId) REFERENCES MetodosPago(Id)
);

CREATE TABLE ProgramacionTurnos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FechaAsignacion DATETIME NOT NULL,
    HorasExtras INT NOT NULL,
    EmpleadoId INT NOT NULL,
    TurnoId INT NOT NULL,
    CONSTRAINT FK_ProgramacionTurnos_Empleados FOREIGN KEY (EmpleadoId) REFERENCES Empleados(Id),
    CONSTRAINT FK_ProgramacionTurnos_Turnos FOREIGN KEY (TurnoId) REFERENCES Turnos(Id)
);

CREATE TABLE SueldoEmpleados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MontoPagado DECIMAL(18,2) NOT NULL,
    FechaPago DATETIME NOT NULL,
    MetodoPago VARCHAR(50) NOT NULL,
    EmpleadoId INT NOT NULL,
    CONSTRAINT FK_SueldoEmpleados_Empleados FOREIGN KEY (EmpleadoId) REFERENCES Empleados(Id)
);

CREATE TABLE Inventarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Stock INT NOT NULL,
    StockMinimo INT NOT NULL,
    ProductoId INT NOT NULL,
    BodegaId INT NOT NULL,
    CONSTRAINT FK_Inventarios_Productos FOREIGN KEY (ProductoId) REFERENCES Productos(Id),
    CONSTRAINT FK_Inventarios_Bodegas FOREIGN KEY (BodegaId) REFERENCES Bodegas(Id)
);

CREATE TABLE DetallesCompras (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PrecioCompra DECIMAL(18,2) NOT NULL,
    Cantidad INT NOT NULL,
    ProductoId INT NOT NULL,
    CompraProveedorId INT NOT NULL,
    CONSTRAINT FK_DetallesCompras_Productos FOREIGN KEY (ProductoId) REFERENCES Productos(Id),
    CONSTRAINT FK_DetallesCompras_ComprasProveedores FOREIGN KEY (CompraProveedorId) REFERENCES ComprasProveedores(Id)
);

CREATE TABLE DetallesFacturas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL,
    FacturaId INT NOT NULL,
    ProductoId INT NOT NULL,
    CONSTRAINT FK_DetallesFacturas_Facturas FOREIGN KEY (FacturaId) REFERENCES Facturas(Id),
    CONSTRAINT FK_DetallesFacturas_Productos FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
);

CREATE TABLE CuentasCobrar (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SaldoPendiente DECIMAL(18,2) NOT NULL,
    EstadoDeuda VARCHAR(50) NOT NULL,
    ClienteId INT NOT NULL,
    FacturaId INT NOT NULL,
    CONSTRAINT FK_CuentasCobrar_Clientes FOREIGN KEY (ClienteId) REFERENCES Clientes(Id),
    CONSTRAINT FK_CuentasCobrar_Facturas FOREIGN KEY (FacturaId) REFERENCES Facturas(Id)
);

CREATE TABLE MovimientosInventarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TipoMovimiento VARCHAR(50) NOT NULL,
    CantidadMovimiento INT NOT NULL,
    FechaHora DATETIME NOT NULL,
    InventarioId INT NOT NULL,
    CONSTRAINT FK_MovimientosInventarios_Inventarios FOREIGN KEY (InventarioId) REFERENCES Inventarios(Id)
);