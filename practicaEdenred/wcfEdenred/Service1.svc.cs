using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using wcfEdenred.BusinessEntities;
using wcfEdenred.BusinessLogic;

namespace wcfEdenred
{
    public class Service1 : IService1
    {
        public List<FacturaDetalleBE> getInvoiceById(int Id)
        {
            using (var logic = new InvoiceBl())
            {
                return logic.getInvoiceById(Id);
            }
        }

        public List<FacturaBE> getInvoiceList(Filters filters)
        {
            using (var logic = new InvoiceBl())
            {
                return logic.getInvoiceList(filters);
            }
        }

        public void Dispose()
        {
            GC.Collect();
        }
    }
}
