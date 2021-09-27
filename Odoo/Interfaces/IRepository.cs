using Models;
using System.Data.Common;
using static Odoo.Callbacks.CallbackDelegates;

namespace Odoo.Interfaces
{
    public interface IRepository
    {
        StartStruct GetStartConfig();
        int Authenticate(DbConnectionStringBuilder dbConnectionStringBuilder);
        void GetData<T>(DbConnectionStringBuilder connectionString, string path, ProcessDataDelegate<T> processDataDelegate);
    }
}
