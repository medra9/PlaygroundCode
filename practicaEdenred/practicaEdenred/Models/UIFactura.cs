using System;

namespace practicaEdenred.Models
{
    public class UIFactura
    {
        public int id_factura { get; set; }
        public DateTime fecha_creacion { get; set; }
        public int cod_cliente { get; set; }
        public int total { get; set; }
    }
}