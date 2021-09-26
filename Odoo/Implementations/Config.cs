using Models;
using Odoo.Interfaces;
using System.Configuration;
using System.Data.Common;
using System.IO;

namespace Odoo
{
    public class Config: IConfig
    {  
        DbConnectionStringBuilder IConfig.GetConnectionString()
        {
            StartStruct startStruct = new StartStruct();  /*Make call to Start*/

            string connectionString = $"user={startStruct.user};password={startStruct.password};host={startStruct.host};database={startStruct.database}";

            DbConnectionStringBuilder conStringBuilder = new DbConnectionStringBuilder();
            conStringBuilder.ConnectionString = connectionString;

            return conStringBuilder;
        }
    }
}
