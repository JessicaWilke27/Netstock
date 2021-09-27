using CsvHelper.Configuration;
using Models;

namespace Odoo.Models
{
    public class CsvLocationModel : ClassMap<LocationModel>
    {
        public CsvLocationModel()
        {            
            Map(ti => ti.id);
            Map(ti => ti.complete_name);
            Map(ti => ti.activeInt);
            Map(ti => ti.group);
            Map(ti => ti.usage);
        }
    }
}
