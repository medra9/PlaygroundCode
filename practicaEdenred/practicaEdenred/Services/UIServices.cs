using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using practicaEdenred.Models;
using practicaEdenred.wcfService;

namespace practicaEdenred.Services
{
    public class UIServices
    {
        public List<UIFactura> getInvoiceList(Filters filters)
        {
            var InvoiceListService = new List<FacturaBE>();
            using (Service1Client service = new Service1Client())
            {
                InvoiceListService = service.getInvoiceList(new Filters()
                {
                    Page = filters.Page,
                    RowsPerPage = filters.RowsPerPage
                });
            }
            var invoiceList = (from invoice in InvoiceListService
                               select new UIFactura
                               {
                                   cod_cliente = invoice.cod_cliente,
                                   fecha_creacion = invoice.fecha_creacion,
                                   id_factura = invoice.id_factura,
                                   total = invoice.total
                               }).ToList();
        
            return invoiceList;
        }

        public List<UIFacturaDetalle> getInvoiceById(int Id)
        {
            var invoiceListService = new List<FacturaDetalleBE>();
            using (Service1Client service = new Service1Client())
            {
                invoiceListService = service.getInvoiceById(Id);
            }
            var invoiceList = (from invoice in invoiceListService
                               select new UIFacturaDetalle
                               {
                                   cod_articulo = invoice.cod_articulo,
                                   detalle_articulo = invoice.detalle_articulo,
                                   fecha_creacion = invoice.fecha_creacion,
                                   id_factura = invoice.id_factura,
                                   id_facturaDetalle = invoice.id_facturaDetalle,
                                   precio_venta = invoice.precio_venta
                               }).ToList();
            return invoiceList;
        }
    }
}