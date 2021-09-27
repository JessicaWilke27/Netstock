using CsvHelper.Configuration;
using Models;

namespace Odoo.Models
{
    public class CsvMasterModel : ClassMap<MasterModel>
    {
        public CsvMasterModel()
        {
            Map(ti => ti.code).Convert(row => row.Value.code is bool ? "" : (string)row.Value.code);
            Map(ti => ti.description).Convert(row => row.Value.description is bool ? "" : row.Value.description);
            Map(ti => ti.uom_name).Convert(row => row.Value.uom_name is bool ? "" : row.Value.uom_name);
            Map(ti => ti.volume);
            Map(ti => ti.weight);
            Map(ti => ti.supersededItemCode).Convert(row => row.Value.supersededItemCode is bool ? "" : row.Value.supersededItemCode);
            Map(ti => ti.supersededItemFactor);
            Map(ti => ti.notUsed);
            Map(ti => ti.id);
        }
    }
}
