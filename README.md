# Centro de Acopio — Sistema de Registro y Control de Donaciones

Parcial #2 de Desarrollo de Software IV

## Información General

- **Universidad:** Universidad Tecnológica de Panamá
- **Facultad:** Facultad de Ingeniería de Sistemas Computacionales
- **Curso:** Desarrollo de Software IV
- **Profesor:** Rodrigo Yángüez
- **Estudiantes:**
  - Jorge Sarmiento
  - Abrahan Tuñon
  - Moisés Murgas
- **Fecha de realización:** 26 de Octubre de 2026

## Introducción

Este proyecto académico es una aplicación de escritorio para llevar el control de las donaciones que recibe un centro de acopio. Fue desarrollada en C# con Windows Forms y SQL Server, bajo una arquitectura en capas y con acceso a datos mediante ADO.NET en modo conectado.

La aplicación tiene dos pantallas:

- **Registro de donaciones:** captura el nombre del producto, su descripción, el tipo de donación (Alimentos, Ropa o Insumos) y la cantidad. Cuando el tipo es Ropa, el formulario muestra campos adicionales: talla, grupo de edad (Niño o Adulto) y sexo (Hombre, Mujer o Unisex).
- **Consulta de donaciones:** ofrece tres reportes mostrados en un `DataGridView`: total de unidades por tipo, listado de donaciones de un tipo seleccionado y listado de ropa filtrada por talla y sexo, con la opción "Todos" en cada filtro.

A lo largo del desarrollo se aplicaron los siguientes principios:

- **Arquitectura en capas:** Entidades, Datos, Negocio y Presentación, separadas por carpetas y espacios de nombres. La capa de Negocio es el único intermediario entre la presentación y los datos.
- **Doble validación:** los formularios validan con sus propios eventos y `ErrorProvider`, y la capa de Negocio vuelve a validar y lanza excepciones propias.
- **Procedimientos almacenados:** todo el acceso a la base de datos se hace con `SqlConnection`, `SqlCommand` y `SqlDataReader`, llamando procedimientos con parámetros.
- **Integridad de datos:** el registro de una donación de ropa se hace en una transacción que inserta en ambas tablas, de modo que si una inserción falla no queda ningún registro parcial.
- **Programación Orientada a Objetos:** una clase `Donacion` y una clase `DonacionRopa` que hereda de ella, con una clase de datos por cada tabla.

## Importancia y Valor del Proyecto

Un centro de acopio recibe donaciones de naturaleza muy distinta y necesita saber con exactitud qué tiene, en qué cantidad y de qué tipo. Llevar ese control en papel o en hojas sueltas facilita errores, duplicados y pérdida de información. Este sistema aporta valor porque:

- **Centraliza la información:** cada donación queda registrada con su fecha, tipo y cantidad en una base de datos única.
- **Reduce los errores de captura:** las validaciones en dos capas impiden registrar cantidades inválidas, campos vacíos o datos de ropa incompletos.
- **Facilita la toma de decisiones:** los reportes por tipo permiten conocer rápidamente cuántas unidades hay de alimentos, ropa e insumos.
- **Agiliza la distribución de la ayuda:** el filtro de ropa por talla y sexo permite encontrar las prendas adecuadas para quien las necesita.
- **Garantiza la consistencia de los datos:** la transacción en el registro de ropa evita registros incompletos.
- **Es mantenible y ampliable:** la separación en capas permite cambiar la interfaz, las reglas de negocio o la base de datos sin reescribir todo el sistema.

## Estructura del Proyecto

```
CentroAcopio/                      → Raíz del repositorio
│
├── BaseDatos/                     → Scripts de SQL Server
│   ├── CentroAcopio.sql           → Crea la base de datos, las tablas y los procedimientos almacenados
│   ├── Verificar.sql              → Pruebas de los procedimientos con datos temporales que se revierten
│   └── LEEME.md                   → Notas de instalación de la base de datos
│
├── Parcial2/                      → Proyecto de Windows Forms
│   ├── Datos/                     → Capa de datos (ADO.NET en modo conectado)
│   │   ├── Conexion.cs            → Crea la conexión a partir del App.config
│   │   ├── DonacionDatos.cs       → Registro, total por tipo y listado por tipo
│   │   └── DonacionRopaDatos.cs   → Filtro de ropa por talla y sexo
│   │
│   ├── Entidades/                 → Clases del dominio
│   │   └── Entidades.cs           → Donacion y DonacionRopa
│   │
│   ├── Negocio/                   → Validaciones y reglas del sistema
│   │   └── DonacionNegocio.cs
│   │
│   ├── Presentacion/              → Formularios
│   │   ├── FormRegistro.cs        → Registro de donaciones (con Designer y resx)
│   │   └── FormConsultas.cs       → Reportes en DataGridView (con Designer y resx)
│   │
│   ├── Properties/                → Propiedades del ensamblado
│   ├── App.config                 → Cadena de conexión "CentroAcopio"
│   ├── Parcial2.csproj            → Archivo del proyecto
│   └── Program.cs                 → Punto de entrada (inicia en FormRegistro)
│
├── .gitignore
├── Parcial #2.docx                → Enunciado del parcial
└── Parcial2.slnx                  → Solución de Visual Studio
```

## Requisitos y Ejecución

**Requisitos:**

- Windows 10 u 11
- Visual Studio con soporte para el formato de solución `.slnx` (Visual Studio 2022 actualizado o Visual Studio 2026) y la carga de trabajo "Desarrollo de escritorio con .NET"
- SQL Server 2012 o posterior (se puede usar la edición Express)
- SQL Server Management Studio (SSMS)

**Ejecución local:**

1. Clonar el repositorio:

   ```
   git clone https://github.com/JorgeS194/Parcial2-CentroDeAcopio.git
   ```

2. Abrir `BaseDatos/CentroAcopio.sql` en SSMS y ejecutarlo completo. Esto crea la base de datos `CentroAcopio`, sus tablas y los procedimientos almacenados. Opcionalmente, ejecutar después `BaseDatos/Verificar.sql` para comprobar que todo funciona; sus datos de prueba se revierten.

3. Configurar la cadena de conexión en `Parcial2/App.config`, dentro de la sección `connectionStrings`. El nombre debe ser `CentroAcopio`. Ajustar el valor de `Data Source` al nombre de la instancia de SQL Server de cada equipo:

   ```xml
   <connectionStrings>
     <add name="CentroAcopio"
          connectionString="Data Source=localhost\SQLEXPRESS;Initial Catalog=CentroAcopio;Integrated Security=True;TrustServerCertificate=True"
          providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

4. Abrir `Parcial2.slnx` en Visual Studio, compilar con `Ctrl + Shift + B` y ejecutar con `F5`. La aplicación inicia en la pantalla de registro de donaciones.

## Tecnologías Utilizadas

- **C#** como lenguaje de programación
- **Windows Forms (.NET Framework)** para la interfaz de usuario, con `ErrorProvider` y `DataGridView`
- **SQL Server** con T-SQL, procedimientos almacenados y transacciones
- **ADO.NET en modo conectado:** `SqlConnection`, `SqlCommand` y `SqlDataReader`
- **Visual Studio** y **SQL Server Management Studio** como herramientas de desarrollo
- **Git** y **GitHub** para el control de versiones y el trabajo en equipo
