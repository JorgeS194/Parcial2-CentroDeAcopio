using System.Data;
using System.Data.SqlClient;
using CentroAcopio.Entidades;
namespace CentroAcopio.Datos
{
    public class DonacionDatos
    {
        public int Registrar(Donacion donacion)
        {
            using (SqlConnection conexion = Conexion.Crear())
            using (SqlCommand comando = new SqlCommand("dbo.usp_Donacion_Registrar", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@NombreProducto", SqlDbType.NVarChar, 150).Value = donacion.NombreProducto;
                comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 500).Value = donacion.Descripcion;
                comando.Parameters.Add("@TipoDonacion", SqlDbType.NVarChar, 20).Value = donacion.TipoDonacion;
                comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = donacion.Cantidad;
                DonacionRopa ropa = donacion as DonacionRopa;
                if (ropa != null)
                {
                    comando.Parameters.Add("@Talla", SqlDbType.NVarChar, 2).Value = ropa.Talla;
                    comando.Parameters.Add("@GrupoEdad", SqlDbType.NVarChar, 10).Value = ropa.GrupoEdad;
                    comando.Parameters.Add("@Sexo", SqlDbType.NVarChar, 10).Value = ropa.Sexo;
                }
                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    if (!lector.Read()) throw new System.InvalidOperationException("No se recibió el código de la donación.");
                    return lector.GetInt32(0);
                }
            }
        }
        public DataTable ObtenerTotalPorTipo()
        {
            return Consultar("dbo.usp_Donacion_TotalPorTipo");
        }
        public DataTable ListarPorTipo(string tipo)
        {
            return Consultar("dbo.usp_Donacion_ListarPorTipo",
                new SqlParameter("@TipoDonacion", SqlDbType.NVarChar, 20) { Value = tipo });
        }
        internal static DataTable Consultar(string procedimiento, params SqlParameter[] parametros)
        {
            using (SqlConnection conexion = Conexion.Crear())
            using (SqlCommand comando = new SqlCommand(procedimiento, conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddRange(parametros);
                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    DataTable tabla = new DataTable();
                    tabla.Load(lector);
                    return tabla;
                }
            }
        }
    }
}
