using Odoo.Interfaces;
using System.Data.Common;

namespace Odoo
{
    public class Authenticator : IAuthenticator
    {
        private IRepository repository;

        public Authenticator(IRepository repository)
        {
            this.repository = repository;
        }

        DbConnectionStringBuilder IAuthenticator.Authenticate(DbConnectionStringBuilder conStringBuilder)
        {
            int response = repository.Authenticate(conStringBuilder);
            DbConnectionStringBuilder newconStringBuilder = new DbConnectionStringBuilder();
            newconStringBuilder.ConnectionString = conStringBuilder.ConnectionString + $";uid={response}";
            return newconStringBuilder;
        }
    }
}
