
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
*/