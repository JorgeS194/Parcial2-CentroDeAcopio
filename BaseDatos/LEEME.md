# Base de datos CentroAcopio

Ejecutar `CentroAcopio.sql` completo en SQL Server Management Studio (SSMS).
Requiere SQL Server 2012 o posterior y permisos para crear la base de datos.
El script crea la base CentroAcopio y sus tablas si no existen; al repetirlo,
actualiza los procedimientos sin eliminar registros. No migra tablas preexistentes
con otro diseño.

## Tablas

- `dbo.Donacion`: producto, descripción, tipo, cantidad y fecha de registro.
- `dbo.DonacionRopa`: talla, grupo de edad y sexo. Su llave primaria es también
  llave foránea de Donacion, por lo que cada donación admite un solo detalle de ropa.
  La relación comprueba además que el tipo sea Ropa.

## Contrato para las capas Datos y Negocio

Usar `CommandType.StoredProcedure` y parámetros tipados con las longitudes
indicadas en el script. La capa Negocio debe validar los textos antes de enviarlos
para evitar que parámetros demasiado cortos los trunquen. Los textos son Unicode
(`SqlDbType.NVarChar`), la cantidad es `SqlDbType.Int` y TotalUnidades se lee como
`Int64`. Los errores se propagan como `SqlException` con mensajes en español.

| Procedimiento | Parámetros | Resultado |
| --- | --- | --- |
| `dbo.usp_Donacion_Registrar` | `@NombreProducto`, `@Descripcion`, `@TipoDonacion`, `@Cantidad`; para ropa también `@Talla`, `@GrupoEdad`, `@Sexo` | Una fila con `IdDonacion` generado |
| `dbo.usp_Donacion_TotalPorTipo` | Ninguno | `TipoDonacion`, `TotalUnidades`; incluye tipos sin donaciones con total cero |
| `dbo.usp_Donacion_ListarPorTipo` | `@TipoDonacion` | Donaciones del tipo y detalles de ropa cuando corresponda |
| `dbo.usp_DonacionRopa_Filtrar` | `@Talla` y `@Sexo`, opcionales | Solo ropa; aplica ambos filtros simultáneamente |

Tipos: Alimentos, Ropa, Insumos. Tallas: XS, S, M, L, XL.
GrupoEdad: Niño, Adulto. Sexo: Hombre, Mujer, Unisex.
Para los filtros, enviar `DBNull.Value`, omitir el parámetro o usar `Todos`
para consultar todos los valores de ese filtro. Para registrar alimentos o insumos,
omitir los tres parámetros de ropa o enviarlos como `DBNull.Value`.

El registro de ropa usa un único procedimiento con transacción y reversión ante
errores. Realizar las inserciones a través de este procedimiento para garantizar
que una donación de ropa tenga su detalle; no insertar directamente en las tablas.

## Ejemplos de uso

```sql
USE CentroAcopio;
EXEC dbo.usp_Donacion_Registrar
    @NombreProducto = N'Arroz', @Descripcion = N'Paquetes de arroz',
    @TipoDonacion = N'Alimentos', @Cantidad = 10;

EXEC dbo.usp_Donacion_Registrar
    @NombreProducto = N'Camiseta', @Descripcion = N'Camisetas nuevas',
    @TipoDonacion = N'Ropa', @Cantidad = 5,
    @Talla = N'M', @GrupoEdad = N'Adulto', @Sexo = N'Unisex';

EXEC dbo.usp_Donacion_TotalPorTipo;
EXEC dbo.usp_Donacion_ListarPorTipo @TipoDonacion = N'Alimentos';
EXEC dbo.usp_DonacionRopa_Filtrar @Talla = N'M', @Sexo = N'Todos';
EXEC dbo.usp_DonacionRopa_Filtrar @Sexo = N'Unisex';
```

Los ejemplos insertan datos solamente si se ejecutan manualmente.

## Backup solicitado en el enunciado

Después de instalar la base, en SSMS seleccionar CentroAcopio → Tareas →
Copia de seguridad → Completa, y elegir una ruta accesible al servicio SQL Server.
El archivo `.bak` resultante incluye las tablas, los datos y los procedimientos.
El script `.sql` no sustituye ese backup. El backup queda pendiente de generar.

## Verificación realizada

Base instalada y probada en el servidor `Abrahan` con autenticación de Windows.
Se comprobaron registros de los tres tipos, ropa para Niño y Adulto, totales,
listado por tipo, filtros simultáneos y opcionales, opción Todos y rechazo de
cantidad cero y ropa incompleta. Un fallo forzado en la segunda tabla confirmó
que se revierten ambas inserciones. La base quedó sin datos de prueba.

`Verificar.sql` permite repetir las pruebas básicas con reversión de los datos.
Si se usa sqlcmd, indicar UTF-8 para conservar la ñ y los acentos:

```powershell
sqlcmd -S Abrahan -E -C -b -f 65001 -i BaseDatos\CentroAcopio.sql
sqlcmd -S Abrahan -E -C -b -f 65001 -i BaseDatos\Verificar.sql
```
