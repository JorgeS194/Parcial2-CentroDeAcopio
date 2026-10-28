using System;
using System.Data;
using System.Data.SqlClient;
namespace CentroAcopio.Datos
{
    public class DonacionRopaDatos
    {
        public DataTable FiltrarRopa(string talla, string sexo)
        {
            return DonacionDatos.Consultar("dbo.usp_DonacionRopa_Filtrar",
                new SqlParameter("@Talla", SqlDbType.NVarChar, 5) { Value = (object)talla ?? DBNull.Value },
                new SqlParameter("@Sexo", SqlDbType.NVarChar, 10) { Value = (object)sexo ?? DBNull.Value });
        }
    }
}
