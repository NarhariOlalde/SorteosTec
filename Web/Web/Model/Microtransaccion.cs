using System;
namespace Web.Model
{
    public class Microtransaccion
    {
        public int id_usuario { get; set; } = 0;
        public int id_transaccion { get; set; } = 0;
        public string compra { get; set; } = string.Empty;
        public int costo { get; set; } = 0;

        public Microtransaccion()
        {
        }
    }
}

