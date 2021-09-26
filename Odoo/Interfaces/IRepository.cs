using Models;
using System.Data.Common;

namespace Odoo.Interfaces
{
    public interface IRepository
    {
        StartStruct GetStartConfig();
        int Authenticate(DbConnectionStringBuilder dbConnectionStringBuilder);

    }
}
