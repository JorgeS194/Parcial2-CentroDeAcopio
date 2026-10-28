using System;
namespace CentroAcopio.Entidades
{
    public class Donacion
    {
        public int IdDonacion { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public string TipoDonacion { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
    public class DonacionRopa : Donacion
    {
        public string Talla { get; set; }
        public string GrupoEdad { get; set; }
        public string Sexo { get; set; }
    }
}
