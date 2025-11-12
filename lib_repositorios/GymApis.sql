CREATE DATABASE GIMNASIO
GO
USE GIMNASIO
GO

-- 1. Usuarios
CREATE TABLE Usuarios (
    IdUsuario INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Apellido NVARCHAR(100),
    Documento NVARCHAR(20),
    Telefono NVARCHAR(20),
    Correo NVARCHAR(100),
    FechaNacimiento DATE,
    Rol NVARCHAR(20), -- Cliente, Admin
    Estado BIT
);
GO
-- 2. Entrenadores
CREATE TABLE Entrenadores (
    IdEntrenador INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Especialidad NVARCHAR(100),
    Telefono NVARCHAR(20),
    Correo NVARCHAR(100),
    Estado BIT
);
GO
-- 3. Membresías
CREATE TABLE Membresias (
    IdMembresia INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(50),
    Descripcion NVARCHAR(200),
    Precio DECIMAL(10,2),
    DuracionDias INT,
    Estado BIT
);
GO
-- 4. Pagos
CREATE TABLE Pagos (
    IdPago INT PRIMARY KEY IDENTITY,
    IdUsuario INT,
    IdMembresia INT,
    FechaPago DATE,
    Monto DECIMAL(10,2),
    MetodoPago NVARCHAR(50),
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
    FOREIGN KEY (IdMembresia) REFERENCES Membresias(IdMembresia)
);

-- 5. Rutinas
CREATE TABLE Rutinas (
    IdRutina INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Objetivo NVARCHAR(200),
    Nivel NVARCHAR(50),
    Estado BIT
);
GO
-- 6. Ejercicios
CREATE TABLE Ejercicios (
    IdEjercicio INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    GrupoMuscular NVARCHAR(50),
    Descripcion NVARCHAR(200),
    Estado BIT
);
GO
-- 7. RutinaEjercicio
CREATE TABLE RutinaEjercicio (
    IdRutinaEjercicio INT PRIMARY KEY IDENTITY,
    IdRutina INT,
    IdEjercicio INT,
    Series INT,
    Repeticiones INT,
    FOREIGN KEY (IdRutina) REFERENCES Rutinas(IdRutina),
    FOREIGN KEY (IdEjercicio) REFERENCES Ejercicios(IdEjercicio)
);
GO
-- 8. Asistencia
CREATE TABLE Asistencia (
    IdAsistencia INT PRIMARY KEY IDENTITY,
    IdUsuario INT,
    Fecha DATE,
    HoraEntrada TIME,
    HoraSalida TIME,
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
);
GO
-- 9. Clases
CREATE TABLE Clases (
    IdClase INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Descripcion NVARCHAR(200),
    CupoMaximo INT,
    Estado BIT
);
GO
-- 10. HorariosClase
CREATE TABLE HorariosClase (
    IdHorarioClase INT PRIMARY KEY IDENTITY,
    IdClase INT,
    DiaSemana NVARCHAR(20),
    HoraInicio TIME,
    HoraFin TIME,
    FOREIGN KEY (IdClase) REFERENCES Clases(IdClase)
);
GO
-- 11. InscripcionClase
CREATE TABLE InscripcionClase (
    IdInscripcion INT PRIMARY KEY IDENTITY,
    IdUsuario INT,
    IdHorarioClase INT,
    FechaInscripcion DATE,
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
    FOREIGN KEY (IdHorarioClase) REFERENCES HorariosClase(IdHorarioClase)
);
GO
-- 12. EvaluacionesFisicas
CREATE TABLE EvaluacionesFisicas (
    IdEvaluacion INT PRIMARY KEY IDENTITY,
    IdUsuario INT,
    FechaEvaluacion DATE,
    Peso DECIMAL(5,2),
    Altura DECIMAL(5,2),
    IMC DECIMAL(5,2),
    Observaciones NVARCHAR(300),
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
);
GO
-- 13. Mensajes
CREATE TABLE Mensajes (
    IdMensaje INT PRIMARY KEY IDENTITY,
    IdUsuario INT,
    IdEntrenador INT,
    FechaEnvio DATETIME,
    Contenido NVARCHAR(500),
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
    FOREIGN KEY (IdEntrenador) REFERENCES Entrenadores(IdEntrenador)
);
GO
-- 14. Productos
CREATE TABLE Productos (
    IdProducto INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Descripcion NVARCHAR(200),
    Precio DECIMAL(10,2),
    Stock INT,
    Estado BIT
);
GO
-- 15. VentasProducto
CREATE TABLE VentasProducto (
    IdVenta INT PRIMARY KEY IDENTITY,
    IdUsuario INT,
    IdProducto INT,
    FechaVenta DATE,
    Cantidad INT,
    Total DECIMAL(10,2),
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
    FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto)
);
GO

-- 16. Auditorias
CREATE TABLE Auditorias (
    IdAuditoria INT PRIMARY KEY IDENTITY,
    Fecha DATETIME NOT NULL,
    Usuario NVARCHAR(100),
    Accion NVARCHAR(100),
    Tabla NVARCHAR(50),
    IdRegistro INT
);
