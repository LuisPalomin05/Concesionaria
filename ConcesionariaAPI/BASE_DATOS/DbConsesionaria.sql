-- Crear Base de Datos
CREATE DATABASE Concesionaria;
GO

USE Concesionaria;
GO

/*========================================================
=                   TABLAS PRINCIPALES                  =
========================================================*/

-- 1. CLIENTES
CREATE TABLE Clientes (
    idCliente INT IDENTITY(1,1) PRIMARY KEY,
    nombreCliente VARCHAR(100) NOT NULL,
    apellidoCliente VARCHAR(100) NOT NULL,
    dniCliente CHAR(8) UNIQUE NOT NULL,
    direccionCliente VARCHAR(200),
    telefonoCliente VARCHAR(20),
    emailCliente VARCHAR(150),
    fechaNacimientoCliente DATETIME DEFAULT GETDATE(),
    CHECK (dniCliente NOT LIKE '%[^0-9]%')
);

----------------------------------------------------------



-- 2. VEHÍCULOS
CREATE TABLE Vehiculos (
    idVehiculo INT IDENTITY(1,1) PRIMARY KEY,
    marcaVehiculo VARCHAR(100) NOT NULL,
    modeloVehiculo VARCHAR(50) NOT NULL,
    precioVehiculo DECIMAL(10,2) NOT NULL,
    stockVehiculo INT NOT NULL,
    colorVehiculo VARCHAR(50),
    descripcionVehiculo VARCHAR(500),
    CHECK (stockVehiculo >= 0),
    CHECK (precioVehiculo > 0)
    )
----------------------------------------------------------

-- 3. EMPLEADOS
CREATE TABLE Empleados (
    idEmpleado INT IDENTITY(1,1) PRIMARY KEY,
    nombreEmpleado VARCHAR(100) NOT NULL,
    apellidoEmpleado VARCHAR(100) NOT NULL,
    dniEmpleado CHAR(8) UNIQUE NOT NULL,
    direccionEmpleado VARCHAR(200),
    telefonoEmpleado VARCHAR(20),
    emailEmpleado VARCHAR(150),
    CHECK (dniEmpleado NOT LIKE '%[^0-9]%')
)

----------------------------------------------------------

-- 4. VENTAS
CREATE TABLE Ventas (
    idVenta INT IDENTITY(1,1) PRIMARY KEY,
    idCliente INT NOT NULL,
    idVehiculo INT NOT NULL,
    idEmpleado INT NOT NULL,
    fechaVenta DATETIME DEFAULT GETDATE(),
    precioVenta DECIMAL(10,2) NOT NULL,
    metodoPago VARCHAR(50) NOT NULL,
    estadoVenta VARCHAR(50) NOT NULL,
    CHECK (estadoVenta IN ('Pendiente', 'Completada', 'Cancelada')),
    CHECK (precioVenta > 0),

    CONSTRAINT FK_Venta_Cliente FOREIGN KEY (idCliente)
        REFERENCES Clientes(idCliente),

    CONSTRAINT FK_Venta_Vehiculo FOREIGN KEY (idVehiculo)
        REFERENCES Vehiculos(idVehiculo),

    CONSTRAINT FK_Venta_Empleado FOREIGN KEY (idEmpleado)
        REFERENCES Empleados(idEmpleado)
);

GO
----------------------------------------------------------
CREATE PROCEDURE sp_listar_clientes
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        idCliente,
        nombreCliente,
        apellidoCliente,
        dniCliente,
        direccionCliente,
        telefonoCliente,
        emailCliente,
        fechaNacimientoCliente
    FROM Clientes;
END;
GO
-----------------------------------------------------------
CREATE PROCEDURE sp_listar_vehiculos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        idVehiculo,
        marcaVehiculo,
        modeloVehiculo,
        precioVehiculo,
        stockVehiculo,
        colorVehiculo,
        descripcionVehiculo
    FROM Vehiculos;
END;
GO

------------------------------------------------------------

CREATE PROCEDURE sp_listar_empleados
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        idEmpleado,
        nombreEmpleado,
        apellidoEmpleado,
        dniEmpleado,
        direccionEmpleado,
        telefonoEmpleado,
        emailEmpleado
    FROM Empleados;
END;
GO

-------------------------------------------------------------

CREATE PROCEDURE sp_listar_ventas
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        v.idVenta,
        v.fechaVenta,
        v.precioVenta,
        v.metodoPago,
        v.estadoVenta,

        c.nombreCliente + ' ' + c.apellidoCliente AS cliente,
        e.nombreEmpleado + ' ' + e.apellidoEmpleado AS empleado,
        ve.marcaVehiculo + ' ' + ve.modeloVehiculo AS vehiculo
    FROM Ventas v
    INNER JOIN Clientes c ON v.idCliente = c.idCliente
    INNER JOIN Empleados e ON v.idEmpleado = e.idEmpleado
    INNER JOIN Vehiculos ve ON v.idVehiculo = ve.idVehiculo;
END;
GO

-------------------------------------------------------------

CREATE PROCEDURE sp_insertar_cliente
    @nombre VARCHAR(100),
    @apellido VARCHAR(100),
    @dni CHAR(8),
    @direccion VARCHAR(200),
    @telefono VARCHAR(20),
    @email VARCHAR(150)
AS
BEGIN
    INSERT INTO Clientes
    (nombreCliente, apellidoCliente, dniCliente, direccionCliente, telefonoCliente, emailCliente)
    VALUES
    (@nombre, @apellido, @dni, @direccion, @telefono, @email);

    SELECT SCOPE_IDENTITY() AS idCliente;
END;
GO

----------------------------------------------------
CREATE PROCEDURE sp_insertar_vehiculo
(
    @marcaVehiculo VARCHAR(50),
    @modeloVehiculo VARCHAR(50),
    @precioVehiculo DECIMAL(10,2),
    @stockVehiculo INT,
    @colorVehiculo VARCHAR(30),
    @descripcionVehiculo VARCHAR(200)
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Vehiculos
    (
        marcaVehiculo,
        modeloVehiculo,
        precioVehiculo,
        stockVehiculo,
        colorVehiculo,
        descripcionVehiculo
    )
    VALUES
    (
        @marcaVehiculo,
        @modeloVehiculo,
        @precioVehiculo,
        @stockVehiculo,
        @colorVehiculo,
        @descripcionVehiculo
    );

    SELECT SCOPE_IDENTITY();
END;
GO


------------------------------------------------

CREATE PROCEDURE sp_insertar_empleado
(
    @nombreEmpleado     VARCHAR(50),
    @apellidoEmpleado   VARCHAR(50),
    @dniEmpleado        VARCHAR(15),
    @direccionEmpleado  VARCHAR(100),
    @telefonoEmpleado   VARCHAR(20),
    @emailEmpleado      VARCHAR(100)
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Empleados
    (
        nombreEmpleado,
        apellidoEmpleado,
        dniEmpleado,
        direccionEmpleado,
        telefonoEmpleado,
        emailEmpleado
    )
    VALUES
    (
        @nombreEmpleado,
        @apellidoEmpleado,
        @dniEmpleado,
        @direccionEmpleado,
        @telefonoEmpleado,
        @emailEmpleado
    );

    SELECT SCOPE_IDENTITY();
END;
GO
