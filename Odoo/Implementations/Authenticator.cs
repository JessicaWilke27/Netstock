using Odoo.Interfaces;
using System.Data.Common;

namespace Odoo
{
    public class Authenticator : IAuthenticator
    {
        DbConnectionStringBuilder IAuthenticator.Authenticate(DbConnectionStringBuilder conStringBuilder)
        {
            int response =  2; // Make call to authenticate against Odoo API
            DbConnectionStringBuilder newconStringBuilder = new DbConnectionStringBuilder();
            newconStringBuilder.ConnectionString = conStringBuilder.ConnectionString + $";uid={response}";
            return newconStringBuilder;
        }

        
    }
}
