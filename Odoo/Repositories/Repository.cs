using CookComputing.XmlRpc;
using Models;
using Odoo.Interfaces;
using System;
using System.Data.Common;
using Common.Interfaces;
using Common.Enums;
using System.Configuration;

namespace Odoo.Repositories
{
    public class Repository : XmlRpcClientProtocol, IRepository
    {
        private static IOdooProxy proxy = XmlRpcProxyGen.Create<IOdooProxy>();
        protected ILogger _logger;
        public Repository(ILogger logger) 
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
            catch(Exception e)
            {
                _logger.Log(LogRecordType.error,$"Failed fetching config. {e.Message}");
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
            catch(Exception e)
            {
                _logger.Log(LogRecordType.error, $"Failed authenticating. {e.Message}");
                throw e;
            }
        }        
    }

}