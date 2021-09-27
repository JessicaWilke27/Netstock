using CookComputing.XmlRpc;
using Models;
using Odoo.Interfaces;
using System;
using System.Data.Common;
using Common.Interfaces;
using Common.Enums;
using static Odoo.Callbacks.CallbackDelegates;
using System.Configuration;

namespace Odoo.Repositories
{
    public abstract class AbstractRepository : XmlRpcClientProtocol, IRepository
    {
        private static IOdooProxy proxy = XmlRpcProxyGen.Create<IOdooProxy>();
        protected ILogger _logger;
        public AbstractRepository(ILogger logger)
        {
            this._logger = logger;
        }

        public StartStruct GetStartConfig()
        {
            _logger.Log(LogRecordType.info, "Fetching config from Odoo Start ..........");
            try
            {
                proxy.Url = ConfigurationManager.AppSettings["SyncHost"];   
                StartStruct start = proxy.GetStartConfig();

                _logger.Log(LogRecordType.info, "Odoo Start Config successfully retrieved..........");
                return start;
            }
            catch (Exception e)
            {
                _logger.Log(LogRecordType.error, $"Failed fetching config. {e.Message}");
                throw e;
            }
        }

        public int Authenticate(DbConnectionStringBuilder connectionString)
        {
            _logger.Log(LogRecordType.info, "Authenticating ..........");
            try
            {
                proxy.Url = $"{(string)connectionString["host"]}/xmlrpc/2/common";
                var response = proxy.Authenticate((string)connectionString["database"], (string)connectionString["user"], (string)connectionString["password"], new String[] { });
                _logger.Log(LogRecordType.info, "Successfully authenticated ..........");
                return response;
            }
            catch (Exception e)
            {
                _logger.Log(LogRecordType.error, $"Failed authenticating. {e.Message}");
                throw e;
            }
        }

        public virtual void GetData<T>(DbConnectionStringBuilder connectionString, string path, ProcessDataDelegate<T> callback)
        {
            IOdooProxy2<T> proxy2 = XmlRpcProxyGen.Create<IOdooProxy2<T>>();

            _logger.Log(LogRecordType.info, "Fetching data ..........");
            proxy2.Url = $"{(string)connectionString["host"]}/xmlrpc/2/object";
            var filter = new FilterStruct();
            //filter.limit = 1;

            filter.fields = GetFieldsList();
            string modelName = GetModelName();
            try
            {
                var response = proxy2.GetData((string)connectionString["database"], int.Parse((string)connectionString["uid"]), (string)connectionString["password"], modelName, "search_read", new object[] { new string[] { } }, filter);

                _logger.Log(LogRecordType.info, "Successfully retrieved  data .........."); //Master
                callback(response, path, _logger);
            }
            catch (Exception e)
            {
                _logger.Log(LogRecordType.info, $"Failed fetching master data. {e.Message}");
                //throw e;
            }
        }

        public virtual T[] GetData<T>(DbConnectionStringBuilder connectionString)
        {
            IOdooProxy2<T> proxy2 = XmlRpcProxyGen.Create<IOdooProxy2<T>>();
            proxy2.Url = $"{(string)connectionString["host"]}/xmlrpc/2/object";
            var filter = new FilterStruct();
            filter.fields = this.GetFieldsList();
            string modelName = GetModelName();
            try
            {
                var response = proxy2.GetData((string)connectionString["database"], int.Parse((string)connectionString["uid"]), (string)connectionString["password"], modelName, "search_read", new object[] { new string[] { } }, filter);
                return response;
            }
            catch (Exception e)
            {
                _logger.Log(LogRecordType.info, $"Failed fetching {modelName} data. {e.Message}");
                throw e;
            }
        }

        public virtual T[] GetData<T>(DbConnectionStringBuilder connectionString, string[] fields, string modelName)
        {
            IOdooProxy2<T> proxy2 = XmlRpcProxyGen.Create<IOdooProxy2<T>>();
            proxy2.Url = $"{(string)connectionString["host"]}/xmlrpc/2/object";
            var filter = new FilterStruct();
            filter.fields = fields; 
            
            try
            {
                var response = proxy2.GetData((string)connectionString["database"], int.Parse((string)connectionString["uid"]), (string)connectionString["password"], modelName, "search_read", new object[] { new string[] { } }, filter);
                return response;
            }
            catch (Exception e)
            {
                _logger.Log(LogRecordType.info, $"Failed fetching {modelName} data. {e.Message}");
                throw e;
            }
        }

        protected abstract string[] GetFieldsList();
        protected abstract string GetModelName();


    }

}