using CookComputing.XmlRpc;
using System;

namespace Models
{
    public struct PoLineModel
    {
        public dynamic product_id { get; set; }
        public dynamic orderpoint_id { get; set; }
        public dynamic partner_id { get; set; }
        public dynamic order_id { get; set; }
        public int id { get; set; }
        public string date_order { get; set; }
        public double product_qty { get; set; }
        public string date_planned { get; set; }
        public double qty_received { get; set; }
        public double price_total { get; set; }
        public string state { get; set; }

        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public DateTime date_order_format
        {
            get
            {
                return DateTime.Parse(date_order).Date;
            }
            set { }
        }

        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public DateTime date_planned_format
        {
            get
            {
                return DateTime.Parse(date_order).Date;
            }
            set { }
        }

    }
}
