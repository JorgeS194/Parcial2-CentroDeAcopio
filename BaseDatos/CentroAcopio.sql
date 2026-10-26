/* Ejecutar completo en SSMS. Requiere SQL Server 2012 o posterior.
   Instalacion inicial: no elimina ni reemplaza tablas existentes.
   La aplicacion debe acceder mediante los procedimientos almacenados.
*/
USE master;
GO
IF DB_ID(N'CentroAcopio') IS NULL
    EXEC(N'CREATE DATABASE CentroAcopio');
GO
USE CentroAcopio;
GO
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO
IF OBJECT_ID(N'dbo.Donacion', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Donacion
    (
        IdDonacion INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Donacion PRIMARY KEY,
        NombreProducto NVARCHAR(150) NOT NULL,
        Descripcion NVARCHAR(500) NOT NULL,
        TipoDonacion NVARCHAR(20) NOT NULL,
        Cantidad INT NOT NULL,
        FechaRegistro DATETIME2(0) NOT NULL
            CONSTRAINT DF_Donacion_FechaRegistro DEFAULT SYSDATETIME(),
        CONSTRAINT CK_Donacion_Nombre CHECK (LEN(LTRIM(RTRIM(NombreProducto))) > 0),
        CONSTRAINT CK_Donacion_Descripcion CHECK (LEN(LTRIM(RTRIM(Descripcion))) > 0),
        CONSTRAINT CK_Donacion_Tipo CHECK (TipoDonacion IN (N'Alimentos', N'Ropa', N'Insumos')),
        CONSTRAINT CK_Donacion_Cantidad CHECK (Cantidad > 0),
        CONSTRAINT UQ_Donacion_IdTipo UNIQUE (IdDonacion, TipoDonacion)
    );
    CREATE INDEX IX_Donacion_Tipo ON dbo.Donacion(TipoDonacion);
END;
GO
IF OBJECT_ID(N'dbo.DonacionRopa', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.DonacionRopa
    (
        IdDonacion INT NOT NULL CONSTRAINT PK_DonacionRopa PRIMARY KEY,
        -- La FK compuesta impide asociar detalles de ropa a alimentos o insumos.
        TipoDonacion NVARCHAR(20) NOT NULL
            CONSTRAINT DF_DonacionRopa_Tipo DEFAULT N'Ropa',
        Talla NVARCHAR(2) NOT NULL,
        GrupoEdad NVARCHAR(10) NOT NULL,
        Sexo NVARCHAR(10) NOT NULL,
        CONSTRAINT FK_DonacionRopa_Donacion FOREIGN KEY (IdDonacion, TipoDonacion)
            REFERENCES dbo.Donacion(IdDonacion, TipoDonacion),
        CONSTRAINT CK_DonacionRopa_Tipo CHECK (TipoDonacion = N'Ropa'),
        CONSTRAINT CK_DonacionRopa_Talla CHECK (Talla IN (N'XS', N'S', N'M', N'L', N'XL')),
        CONSTRAINT CK_DonacionRopa_GrupoEdad CHECK (GrupoEdad IN (N'Niño', N'Adulto')),
        CONSTRAINT CK_DonacionRopa_Sexo CHECK (Sexo IN (N'Hombre', N'Mujer', N'Unisex'))
    );
    CREATE INDEX IX_DonacionRopa_TallaSexo ON dbo.DonacionRopa(Talla, Sexo);
END;
GO
-- Estos bloques permiten volver a instalar los procedimientos sin borrar datos.
IF OBJECT_ID(N'dbo.usp_Donacion_Registrar', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.usp_Donacion_Registrar AS RETURN 0;');
GO
ALTER PROCEDURE dbo.usp_Donacion_Registrar
    @NombreProducto NVARCHAR(150),
    @Descripcion NVARCHAR(500),
    @TipoDonacion NVARCHAR(20),
    @Cantidad INT,
    @Talla NVARCHAR(2) = NULL,
    @GrupoEdad NVARCHAR(10) = NULL,
    @Sexo NVARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    SET @NombreProducto = LTRIM(RTRIM(@NombreProducto));
    SET @Descripcion = LTRIM(RTRIM(@Descripcion));
    SET @TipoDonacion = LTRIM(RTRIM(@TipoDonacion));
    SET @Talla = NULLIF(LTRIM(RTRIM(@Talla)), N'');
    SET @GrupoEdad = NULLIF(LTRIM(RTRIM(@GrupoEdad)), N'');
    SET @Sexo = NULLIF(LTRIM(RTRIM(@Sexo)), N'');

    IF @NombreProducto IS NULL OR @NombreProducto = N''
        THROW 50001, N'El nombre del producto es obligatorio.', 1;
    IF @Descripcion IS NULL OR @Descripcion = N''
        THROW 50002, N'La descripción es obligatoria.', 1;
    IF @TipoDonacion IS NULL OR @TipoDonacion NOT IN (N'Alimentos', N'Ropa', N'Insumos')
        THROW 50003, N'El tipo debe ser Alimentos, Ropa o Insumos.', 1;
    IF @Cantidad IS NULL OR @Cantidad <= 0
        THROW 50004, N'La cantidad debe ser un entero mayor que cero.', 1;

    IF @TipoDonacion = N'Ropa'
    BEGIN
        IF @Talla IS NULL OR @Talla NOT IN (N'XS', N'S', N'M', N'L', N'XL')
            THROW 50005, N'Seleccione una talla válida: XS, S, M, L o XL.', 1;
        IF @GrupoEdad IS NULL OR @GrupoEdad NOT IN (N'Niño', N'Adulto')
            THROW 50006, N'Indique si la prenda es para Niño o Adulto.', 1;
        IF @Sexo IS NULL OR @Sexo NOT IN (N'Hombre', N'Mujer', N'Unisex')
            THROW 50007, N'Seleccione Hombre, Mujer o Unisex.', 1;
    END
    ELSE IF @Talla IS NOT NULL OR @GrupoEdad IS NOT NULL OR @Sexo IS NOT NULL
        THROW 50008, N'Los datos de ropa solo corresponden a donaciones de tipo Ropa.', 1;

    BEGIN TRY
        BEGIN TRANSACTION;
        INSERT dbo.Donacion (NombreProducto, Descripcion, TipoDonacion, Cantidad)
        VALUES (@NombreProducto, @Descripcion, @TipoDonacion, @Cantidad);

        DECLARE @IdDonacion INT = CONVERT(INT, SCOPE_IDENTITY());
        IF @TipoDonacion = N'Ropa'
            INSERT dbo.DonacionRopa (IdDonacion, Talla, GrupoEdad, Sexo)
            VALUES (@IdDonacion, @Talla, @GrupoEdad, @Sexo);
        COMMIT TRANSACTION;

        -- Un resultado compatible con SqlDataReader.
        SELECT @IdDonacion AS IdDonacion;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO
IF OBJECT_ID(N'dbo.usp_Donacion_TotalPorTipo', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.usp_Donacion_TotalPorTipo AS RETURN 0;');
GO
ALTER PROCEDURE dbo.usp_Donacion_TotalPorTipo
AS
BEGIN
    SET NOCOUNT ON;
    SELECT t.TipoDonacion, COALESCE(SUM(CONVERT(BIGINT, d.Cantidad)), 0) AS TotalUnidades
    FROM (VALUES (N'Alimentos'), (N'Ropa'), (N'Insumos')) AS t(TipoDonacion)
    LEFT JOIN dbo.Donacion AS d ON d.TipoDonacion = t.TipoDonacion
    GROUP BY t.TipoDonacion
    ORDER BY t.TipoDonacion;
END;
GO
IF OBJECT_ID(N'dbo.usp_Donacion_ListarPorTipo', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.usp_Donacion_ListarPorTipo AS RETURN 0;');
GO
ALTER PROCEDURE dbo.usp_Donacion_ListarPorTipo
    @TipoDonacion NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SET @TipoDonacion = LTRIM(RTRIM(@TipoDonacion));
    IF @TipoDonacion IS NULL OR @TipoDonacion NOT IN (N'Alimentos', N'Ropa', N'Insumos')
        THROW 50003, N'El tipo debe ser Alimentos, Ropa o Insumos.', 1;

    SELECT d.IdDonacion, d.NombreProducto, d.Descripcion, d.TipoDonacion,
           d.Cantidad, d.FechaRegistro, r.Talla, r.GrupoEdad, r.Sexo
    FROM dbo.Donacion AS d
    LEFT JOIN dbo.DonacionRopa AS r ON r.IdDonacion = d.IdDonacion
    WHERE d.TipoDonacion = @TipoDonacion
    ORDER BY d.IdDonacion DESC;
END;
GO
IF OBJECT_ID(N'dbo.usp_DonacionRopa_Filtrar', N'P') IS NULL
    EXEC(N'CREATE PROCEDURE dbo.usp_DonacionRopa_Filtrar AS RETURN 0;');
GO
ALTER PROCEDURE dbo.usp_DonacionRopa_Filtrar
    @Talla NVARCHAR(5) = NULL,
    @Sexo NVARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    -- NULL, vacio y Todos significan que no se aplica ese filtro.
    SET @Talla = NULLIF(NULLIF(LTRIM(RTRIM(@Talla)), N''), N'Todos');
    SET @Sexo = NULLIF(NULLIF(LTRIM(RTRIM(@Sexo)), N''), N'Todos');
    IF @Talla IS NOT NULL AND @Talla NOT IN (N'XS', N'S', N'M', N'L', N'XL')
        THROW 50005, N'Seleccione una talla válida: XS, S, M, L o XL.', 1;
    IF @Sexo IS NOT NULL AND @Sexo NOT IN (N'Hombre', N'Mujer', N'Unisex')
        THROW 50007, N'Seleccione Hombre, Mujer o Unisex.', 1;

    SELECT d.IdDonacion, d.NombreProducto, d.Descripcion, d.TipoDonacion,
           d.Cantidad, d.FechaRegistro, r.Talla, r.GrupoEdad, r.Sexo
    FROM dbo.Donacion AS d
    INNER JOIN dbo.DonacionRopa AS r ON r.IdDonacion = d.IdDonacion
    WHERE (@Talla IS NULL OR r.Talla = @Talla)
      AND (@Sexo IS NULL OR r.Sexo = @Sexo)
    ORDER BY d.IdDonacion DESC;
END;
GO
