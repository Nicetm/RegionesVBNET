-- Crear base de datos
CREATE DATABASE BDRegiones;
GO
USE BDRegiones;
GO

-- Tabla Region
CREATE TABLE Region (
    IdRegion INT IDENTITY(1,1) PRIMARY KEY,
    Region NVARCHAR(128) NOT NULL
);

-- Tabla Comuna
CREATE TABLE Comuna (
    IdComuna INT IDENTITY(1,1) PRIMARY KEY,
    IdRegion INT NOT NULL,
    Comuna NVARCHAR(128) NOT NULL,
    InformacionAdicional XML,
    FOREIGN KEY (IdRegion) REFERENCES Region(IdRegion)
);
GO

-- Insert de ejemplo
INSERT INTO Region (Region) VALUES ('Metropolitana');
INSERT INTO Comuna (IdRegion, Comuna, InformacionAdicional)
VALUES (
    1,
    'Santiago',
    '<Info><Superficie>4799.4</Superficie><Poblacion Densidad="51.6">247552</Poblacion></Info>'
);
GO

-- SP: Obtener todas las regiones
CREATE PROCEDURE sp_GetAllRegiones
AS
BEGIN
    SELECT IdRegion, Region FROM Region
END
GO

-- SP: Obtener comunas por región
CREATE PROCEDURE sp_GetComunasByRegion
    @IdRegion INT
AS
BEGIN
    SELECT IdComuna, IdRegion, Comuna, InformacionAdicional
    FROM Comuna
    WHERE IdRegion = @IdRegion
END
GO

-- SP: Obtener comuna por ID
CREATE PROCEDURE sp_GetComunaById
    @IdRegion INT,
    @IdComuna INT
AS
BEGIN
    SELECT IdComuna, IdRegion, Comuna, InformacionAdicional
    FROM Comuna
    WHERE IdRegion = @IdRegion AND IdComuna = @IdComuna
END
GO

-- SP: Insertar o actualizar comuna (MERGE)
CREATE PROCEDURE sp_MergeComuna
    @IdComuna INT,
    @IdRegion INT,
    @Comuna NVARCHAR(128),
    @InformacionAdicional XML
AS
BEGIN
    MERGE Comuna AS target
    USING (SELECT @IdComuna AS IdComuna) AS source
    ON (target.IdComuna = source.IdComuna)
    WHEN MATCHED THEN
        UPDATE SET
            IdRegion = @IdRegion,
            Comuna = @Comuna,
            InformacionAdicional = @InformacionAdicional
    WHEN NOT MATCHED THEN
        INSERT (IdRegion, Comuna, InformacionAdicional)
        VALUES (@IdRegion, @Comuna, @InformacionAdicional);
END
GO