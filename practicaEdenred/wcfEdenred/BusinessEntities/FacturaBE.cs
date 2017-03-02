using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wcfEdenred.BusinessEntities
{
    public class FacturaBE
    {
        public int id_factura { get; set; }
        public DateTime fecha_creacion { get; set; }
        public int cod_cliente { get; set; }
        public int total { get; set; }
    }
}