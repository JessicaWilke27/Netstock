using Common.Interfaces;

namespace Odoo.Repositories
{
    public class LocationDataRepository : AbstractRepository
    {

        public LocationDataRepository(ILogger logger) : base(logger)
        {
  
        }

        protected override string[] GetFieldsList()
        {
            var fields = new string[] { "id", "complete_name", "active", "usage" };
            return fields;
        }
        protected override string GetModelName()
        {
            return "stock.location";
        }
    }

}