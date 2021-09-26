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
}
