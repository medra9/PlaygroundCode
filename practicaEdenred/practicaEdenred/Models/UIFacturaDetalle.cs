using System;

namespace practicaEdenred.Models
{
    public class UIFacturaDetalle
    {
        public int id_facturaDetalle { get; set; }
        public int id_factura { get; set; }
        public DateTime fecha_creacion { get; set; }
        public decimal precio_venta { get; set; }
        public int cod_articulo { get; set; }
        public string detalle_articulo { get; set; }

    }
}