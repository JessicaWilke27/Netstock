using CookComputing.XmlRpc;
using Models;

namespace Odoo.Interfaces
{
    public interface IOdooProxy : IXmlRpcProxy
    {
        [XmlRpcMethod("start")]
        StartStruct GetStartConfig();

        [XmlRpcMethod("authenticate")]
        int Authenticate(string db, string username, string pwd, object[] arr);
    }

    public interface IOdooProxy2<T> : IXmlRpcProxy
    {

        [XmlRpcMethod("execute_kw")]
        T[] GetData(string db, int uid, string pwd, string model, string func, object[] arr, FilterStruct limit);

    }
}
