using Common.Interfaces;

namespace Odoo.Repositories
{
    public class MasterDataRepository : AbstractRepository
    {

        public MasterDataRepository(ILogger logger) : base(logger)
        {
  
        }

        protected override string[] GetFieldsList()
        {
            var fields = new string[] { "code", "description", "uom_name", "volume", "weight", "id" };
            return fields;
        }
        protected override string GetModelName()
        {
            return "product.product";
        }
    }

}