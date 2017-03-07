using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using wcfEdenred.BusinessEntities;

namespace wcfEdenred.DataAccess
{
    public class DataInvoice: BaseData, IDisposable
    {
        internal SqlCommand command;
        public List<FacturaBE> getInvoiceList(Filters request)
        {
            List<FacturaBE> facturaList = null;
            FacturaBE factura = null;
            if (!base.Connect())
            {
                Console.Error.WriteLine("Error en la conexion");
            }
            try
            {
                using (command = base.CreateCommand())
                {
                    command.CommandText = "sp_lee_factura";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Page_number", SqlDbType.Int).Value = request.Page;
                    command.Parameters.Add("@Page_size", SqlDbType.Int).Value = request.RowsPerPage;
                }
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    facturaList = new List<FacturaBE>();
                    while (dr.Read())
                    {
                        factura = new FacturaBE()
                        {
                            id_factura = Convert.ToInt32(dr["id_factura"].ToString()),
                            cod_cliente = Convert.ToInt32(dr["cod_cliente"].ToString()),
                            fecha_creacion = Convert.IsDBNull(dr["fecha_creacion"]) ? new DateTime().AddYears(-200) : Convert.ToDateTime(dr["fecha_creacion"].ToString()),
                            total = Convert.ToInt32(dr["total"])
                        };
                        facturaList.Add(factura);
                    }
                }
            }
            catch(SqlException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return facturaList;
        }

        public List<FacturaDetalleBE> getInvoiceById(int Id)
        {
            List<FacturaDetalleBE> facturaList = null;
            FacturaDetalleBE details = null;
            if (!base.Connect())
            {
                Console.Error.WriteLine("Error en la conexion");
            }
            try
            {
                using (command = base.CreateCommand())
                {
                    command.CommandText = "sp_lee_detalle";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
                }
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    facturaList = new List<FacturaDetalleBE>();
                    while (dr.Read())
                    {
                        details = new FacturaDetalleBE()
                        {
                            cod_articulo = Convert.ToInt32(dr["cod_articulo"].ToString()),
                            detalle_articulo = (dr["detalle_articulo"].ToString()),
                            fecha_creacion = Convert.IsDBNull(dr["fecha_creacion"]) ? new DateTime().AddYears(-200) : Convert.ToDateTime(dr["fecha_creacion"].ToString()),
                            id_factura = Convert.ToInt32(dr["id_factura"].ToString()),
                            id_facturaDetalle = Convert.ToInt32(dr["id_facDetalle"].ToString()),
                            precio_venta = Convert.IsDBNull(dr["precio_venta"]) ? 0 : Convert.ToDecimal(dr["precio_venta"])
                        };
                        facturaList.Add(details);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return facturaList;
        }
        
    }
}