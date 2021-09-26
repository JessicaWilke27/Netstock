using System.Data.Common;

namespace Odoo.Interfaces
{
    public interface IAuthenticator
    {
         DbConnectionStringBuilder Authenticate(DbConnectionStringBuilder conStringBuilder);
    }
}
