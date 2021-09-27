using CsvHelper.Configuration;
using Models;

namespace Odoo.Models
{
    public class CsvSupplierModel : ClassMap<SupplierModel>
    {
        public CsvSupplierModel()
        {            
            Map(ti => ti.id);
            Map(ti => ti.supplier);
            Map(ti => ti.type);
            Map(ti => ti.delay);
        }
    }
}
