using System.Configuration;
using System.Data.SqlClient;
namespace CentroAcopio.Datos
{
    public static class Conexion
    {
        public static SqlConnection Crear()
        {
            var configuracion = ConfigurationManager.ConnectionStrings["CentroAcopio"];
            if (configuracion == null)
                throw new System.InvalidOperationException("Configure la conexión CentroAcopio en App.config.");
            return new SqlConnection(configuracion.ConnectionString);
        }
    }
}
