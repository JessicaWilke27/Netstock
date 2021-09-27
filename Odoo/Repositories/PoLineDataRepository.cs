using Common.Interfaces;

namespace Odoo.Repositories
{
    public class PoLineDataRepository : AbstractRepository
    {

        public PoLineDataRepository(ILogger logger) : base(logger)
        {
  
        }

        protected override string[] GetFieldsList()
        {
            var fields = new string[] { "product_id", "orderpoint_id", "partner_id", "order_id", "id", "date_order", "product_qty", "date_planned", "qty_received", "price_total", "state" };
            return fields;
        }
        protected override string GetModelName()
        {
            return "purchase.order.line";
        }

        public static string[] FieldsList()
        {
            var fields = new string[] { "product_id", "orderpoint_id", "partner_id", "order_id", "id", "date_order", "product_qty", "date_planned", "qty_received", "price_total", "state" };
            return fields;
        }

        public static string ModelName()
        {
            return "purchase.order.line";
        }
    }

}