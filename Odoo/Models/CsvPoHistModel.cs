using CsvHelper.Configuration;
using Models;

namespace Odoo.Models
{
    public class CsvPoHistModel : ClassMap<PoHistModel>
    {
        public CsvPoHistModel()
        {
            Map(ti => ti.ItemCode);
            Map(ti => ti.Location);
            Map(ti => ti.SupplierCode);
            Map(ti => ti.OrderNumber);
            Map(ti => ti.LineNumber);
            Map(ti => ti.OrderDate);
            Map(ti => ti.OrderQuantity);
            Map(ti => ti.ExpectedDate);
            Map(ti => ti.Urgency);
            Map(ti => ti.QuantityReceived);
            Map(ti => ti.DateOfReceipt);
            Map(ti => ti.UnitCost);
        }
    }
}
