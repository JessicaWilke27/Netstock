using CsvHelper.Configuration;
using Models;

namespace Odoo.Models
{
    public class CsvPoOutModel : ClassMap<PoLineModel>
    {
        public CsvPoOutModel()
        {            
            Map(ti => ti.product_id).Convert(row => row.Value.product_id is bool ? "" : ((int)row.Value.product_id[0]).ToString());
            Map(ti => ti.orderpoint_id).Convert(row => row.Value.orderpoint_id is bool ? "" : ((int)row.Value.orderpoint_id[0]).ToString());
            Map(ti => ti.partner_id).Convert(row => row.Value.partner_id is bool ? "" : ((int)row.Value.partner_id[0]).ToString());
            Map(ti => ti.order_id).Convert(row => row.Value.order_id is bool ? "" : (string)row.Value.order_id[1]);
            Map(ti => ti.id);
            Map(ti => ti.date_order_format);
            Map(ti => ti.product_qty);
            Map(ti => ti.date_planned_format);
            Map(ti => ti.qty_received);
            Map(ti => ti.state);
            Map(ti => ti.price_total);
        }
    }
}
