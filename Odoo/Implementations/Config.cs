using Models;
using Odoo.Interfaces;
using System.Data.Common;

namespace Odoo
{
    public class Config: IConfig
    {
        private readonly IRepository _repository;

        public Config(IRepository repository)
        {
            this._repository = repository;
        }

        DbConnectionStringBuilder IConfig.GetConnectionString()
        {
            StartStruct startStruct = _repository.GetStartConfig();

            string connectionString = $"user={startStruct.user};password={startStruct.password};host={startStruct.host};database={startStruct.database}";

            DbConnectionStringBuilder conStringBuilder = new DbConnectionStringBuilder();
            conStringBuilder.ConnectionString = connectionString;

            return conStringBuilder;
        }
    }
}
