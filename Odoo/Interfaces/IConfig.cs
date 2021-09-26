using System.Data.Common;

namespace Odoo.Interfaces
{
    public interface IConfig
    {
        DbConnectionStringBuilder GetConnectionString();
        
    }
}
