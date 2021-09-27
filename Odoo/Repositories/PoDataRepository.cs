using Common.Interfaces;

namespace Odoo.Repositories
{
    public class PoDataRepository : AbstractRepository
    {

        public PoDataRepository(ILogger logger) : base(logger)
        {
  
        }

        protected override string[] GetFieldsList()
        {
            var fields = new string[] { "priority", "date_planned", "order_line" };
            return fields;
        }
        protected override string GetModelName()
        {
            return "purchase.order";
        }
    }

}