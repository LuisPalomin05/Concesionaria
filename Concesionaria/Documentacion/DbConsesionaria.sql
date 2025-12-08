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
    nombreCliente VARCHAR(100),
    apellidoCliente VARCHAR(100),
    dniCliente CHAR(8) UNIQUE,
    direccionCliente VARCHAR(200),
    telefonoCliente VARCHAR(20),
    emailCliente VARCHAR(150),
    fechaRegistroCliente DATETIME DEFAULT GETDATE()
);

----------------------------------------------------------

-- 2.1 TIPO VEHÍCULOS
CREATE TABLE TipoVehiculos (
    idTipoVehiculo INT IDENTITY(1,1) PRIMARY KEY,
    nombreTipoVehiculo VARCHAR(100) NOT NULL
);

-- 2.2 MODELO VEHÍCULOS
CREATE TABLE ModeloVehiculos (
    idModeloVehiculo INT IDENTITY(1,1) PRIMARY KEY,
    nombreModeloVehiculo VARCHAR(100) NOT NULL
);

----------------------------------------------------------

-- 2. VEHÍCULOS
CREATE TABLE Vehiculos (
    idVehiculo INT IDENTITY(1,1) PRIMARY KEY,
    marcaVehiculo VARCHAR(100),
    modeloVehiculo INT,
    anioVehiculo INT,
    tipoVehiculo INT,
    precioVehiculo DECIMAL(10,2),
    disponibilidadVehiculo VARCHAR(50),
    colorVehiculo VARCHAR(50),
    descripcionVehiculo VARCHAR(500),

    CONSTRAINT FK_Vehiculo_Modelo FOREIGN KEY (modeloVehiculo)
        REFERENCES ModeloVehiculos(idModeloVehiculo),

    CONSTRAINT FK_Vehiculo_Tipo FOREIGN KEY (tipoVehiculo)
        REFERENCES TipoVehiculos(idTipoVehiculo)
);

----------------------------------------------------------

-- 3.1 TIPO EMPLEADOS
CREATE TABLE TipoEmpleados (
    idTipoEmpleado INT IDENTITY(1,1) PRIMARY KEY,
    nombreTipoEmpleado VARCHAR(100) NOT NULL
);

----------------------------------------------------------

-- 3. EMPLEADOS
CREATE TABLE Empleados (
    idEmpleado INT IDENTITY(1,1) PRIMARY KEY,
    nombreEmpleado VARCHAR(100),
    apellidoEmpleado VARCHAR(100),
    dniEmpleado CHAR(8) UNIQUE,
    direccionEmpleado VARCHAR(200),
    telefonoEmpleado VARCHAR(20),
    emailEmpleado VARCHAR(150),
    tipoEmpleado INT,

    CONSTRAINT FK_Empleado_TipoEmpleado FOREIGN KEY (tipoEmpleado)
        REFERENCES TipoEmpleados(idTipoEmpleado)
);

----------------------------------------------------------

-- 4. VENTAS
CREATE TABLE Ventas (
    idVenta INT IDENTITY(1,1) PRIMARY KEY,
    idCliente INT,
    idVehiculo INT,
    idEmpleado INT,
    fechaVenta DATETIME DEFAULT GETDATE(),
    precioVenta DECIMAL(10,2),
    metodoPago VARCHAR(50),
    estadoVenta VARCHAR(50),

    CONSTRAINT FK_Venta_Cliente FOREIGN KEY (idCliente)
        REFERENCES Clientes(idCliente),

    CONSTRAINT FK_Venta_Vehiculo FOREIGN KEY (idVehiculo)
        REFERENCES Vehiculos(idVehiculo),

    CONSTRAINT FK_Venta_Empleado FOREIGN KEY (idEmpleado)
        REFERENCES Empleados(idEmpleado)
);
