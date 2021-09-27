using Common.Enums;
using Common.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using static Odoo.Callbacks.CallbackDelegates;

namespace Odoo.Repositories
{
    public class SupplierDataRepository : AbstractRepository
    {
        public SupplierDataRepository(ILogger logger) : base(logger)
        {
        }

        public override void GetData<T>(DbConnectionStringBuilder connectionString, string path, ProcessDataDelegate<T> callback)
        {
            try
            {
                var response = this.GetData<SupplierModel>(connectionString);
                if (response != null)              
                {
                   response = response.GroupBy(p => p.name[0]).Select(g => g.First()).ToArray();
                }                

                this._logger.Log(LogRecordType.info, "Successfully retrieved purchase order data ..........");
                callback(response.ToArray() as T[], path, this._logger);

            }
            catch (Exception e)
            {
                _logger.Log(LogRecordType.info, $"Failed fetching {this.GetModelName()} data. {e.Message}");
                throw e;
            }
        }

        protected override string[] GetFieldsList()
        {
            var fields = new string[] { "id", "name", "delay" };
            return fields;
        }

        protected override string GetModelName()
        {
            return "product.supplierinfo";
        }

    }

}