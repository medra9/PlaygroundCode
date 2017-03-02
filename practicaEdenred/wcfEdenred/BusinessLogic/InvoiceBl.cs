using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wcfEdenred.BusinessEntities;
using wcfEdenred.DataAccess;

namespace wcfEdenred.BusinessLogic
{
    public class InvoiceBl: IDisposable
    {
        internal DataInvoice dataInvoice = new DataInvoice();
        public List<FacturaBE> getInvoiceList(Filters filters)
        {
            using (var logic = new DataInvoice())
            {
                return logic.getInvoiceList(filters);
            }
        }

        public List<FacturaDetalleBE> getInvoiceById(int Id)
        {
            using (var logic = new DataInvoice())
            {
                return logic.getInvoiceById(Id);
            }
        }

        public void Dispose()
        {
            GC.Collect();
        }
    }
}