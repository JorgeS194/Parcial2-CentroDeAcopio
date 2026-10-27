-- Ejecutar despues de CentroAcopio.sql. Los datos de prueba se revierten.
USE CentroAcopio;
GO
SET NOCOUNT ON;
SET XACT_ABORT ON;
BEGIN TRY
    BEGIN TRANSACTION;
    EXEC dbo.usp_Donacion_Registrar N'Prueba arroz', N'Prueba temporal', N'Alimentos', 10;
    EXEC dbo.usp_Donacion_Registrar N'Prueba insumos', N'Prueba temporal', N'Insumos', 3;
    EXEC dbo.usp_Donacion_Registrar N'Prueba camiseta', N'Prueba temporal', N'Ropa', 5, N'M', N'Adulto', N'Unisex';
    EXEC dbo.usp_Donacion_Registrar N'Prueba pantalon', N'Prueba temporal', N'Ropa', 2, N'S', N'Niño', N'Hombre';

    CREATE TABLE #Totales (TipoDonacion NVARCHAR(20), TotalUnidades BIGINT);
    INSERT #Totales EXEC dbo.usp_Donacion_TotalPorTipo;
    IF (SELECT COUNT(*) FROM #Totales) <> 3
        THROW 51000, N'El reporte debe devolver tres tipos.', 1;
    IF EXISTS (SELECT 1 FROM #Totales t WHERE t.TotalUnidades <
        CASE t.TipoDonacion WHEN N'Alimentos' THEN 10 WHEN N'Ropa' THEN 7 ELSE 3 END)
        THROW 51001, N'Los totales no incluyen las unidades de prueba.', 1;

    CREATE TABLE #Listado (
        IdDonacion INT, NombreProducto NVARCHAR(150), Descripcion NVARCHAR(500),
        TipoDonacion NVARCHAR(20), Cantidad INT, FechaRegistro DATETIME2(0),
        Talla NVARCHAR(2), GrupoEdad NVARCHAR(10), Sexo NVARCHAR(10));
    INSERT #Listado EXEC dbo.usp_Donacion_ListarPorTipo N'Alimentos';
    IF EXISTS (SELECT 1 FROM #Listado WHERE TipoDonacion <> N'Alimentos')
        OR NOT EXISTS (SELECT 1 FROM #Listado WHERE NombreProducto = N'Prueba arroz')
        THROW 51002, N'Fallo del listado por tipo.', 1;
    TRUNCATE TABLE #Listado;
    INSERT #Listado EXEC dbo.usp_DonacionRopa_Filtrar N'M', N'Unisex';
    IF EXISTS (SELECT 1 FROM #Listado WHERE Talla <> N'M' OR Sexo <> N'Unisex' OR TipoDonacion <> N'Ropa')
        OR NOT EXISTS (SELECT 1 FROM #Listado WHERE NombreProducto = N'Prueba camiseta')
        THROW 51003, N'Fallo de filtros simultaneos.', 1;
    TRUNCATE TABLE #Listado;
    INSERT #Listado EXEC dbo.usp_DonacionRopa_Filtrar N'Todos', N'Todos';
    IF NOT EXISTS (SELECT 1 FROM #Listado WHERE NombreProducto = N'Prueba pantalon')
        THROW 51004, N'Fallo de la opcion Todos.', 1;
    TRUNCATE TABLE #Listado;
    INSERT #Listado EXEC dbo.usp_DonacionRopa_Filtrar @Talla = N'M';
    IF EXISTS (SELECT 1 FROM #Listado WHERE Talla <> N'M')
        THROW 51005, N'Fallo del filtro opcional por talla.', 1;
    TRUNCATE TABLE #Listado;
    INSERT #Listado EXEC dbo.usp_DonacionRopa_Filtrar @Sexo = N'Hombre';
    IF EXISTS (SELECT 1 FROM #Listado WHERE Sexo <> N'Hombre')
        OR NOT EXISTS (SELECT 1 FROM #Listado WHERE NombreProducto = N'Prueba pantalon')
        THROW 51006, N'Fallo del filtro opcional por sexo.', 1;
    ROLLBACK TRANSACTION;
    PRINT N'OK: registros y reportes. Datos temporales revertidos.';
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
    THROW;
END CATCH;
GO
DECLARE @Antes INT = (SELECT COUNT(*) FROM dbo.Donacion);
BEGIN TRY
    EXEC dbo.usp_Donacion_Registrar N'Prueba', N'Cantidad invalida', N'Alimentos', 0;
    THROW 51007, N'Se acepto una cantidad invalida.', 1;
END TRY
BEGIN CATCH
    IF ERROR_NUMBER() <> 50004 THROW;
END CATCH;
BEGIN TRY
    EXEC dbo.usp_Donacion_Registrar N'Prueba', N'Ropa incompleta', N'Ropa', 1;
    THROW 51008, N'Se acepto ropa incompleta.', 1;
END TRY
BEGIN CATCH
    IF ERROR_NUMBER() <> 50005 THROW;
END CATCH;
IF (SELECT COUNT(*) FROM dbo.Donacion) <> @Antes
    THROW 51009, N'Las validaciones dejaron registros parciales.', 1;
PRINT N'OK: cantidad invalida y ropa incompleta rechazadas sin registros parciales.';
GO
