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
    public class PoHistDataRepository : AbstractRepository
    {

        public PoHistDataRepository(ILogger logger) : base(logger)
        {
  
        }

        protected override string[] GetFieldsList()
        {
            var fields = new string[] { "priority", "date_planned", "order_line" };
            return fields;
        }
        protected override string GetModelName()
        {
            return "purchase.order";
        }

        public override void GetData<T>(DbConnectionStringBuilder connectionString, string path, ProcessDataDelegate<T> callback)
        {
            try 
            { 
                var poResponse = this.GetData<PoModel>(connectionString);
                var poLineResponse = base.GetData<PoLineModel>(connectionString, PoLineDataRepository.FieldsList(), PoLineDataRepository.ModelName());
                List<PoHistModel> poHistModel = new List<PoHistModel>();
                foreach (var pl in poLineResponse)
                {
                    var orderDate = DateTime.Parse(pl.date_order).Date;
                    if (orderDate < DateTime.Today.Date.AddMonths(-12))
                    {
                        continue;
                    }
                    var orderLine = pl.id;
                    var match = poResponse.FirstOrDefault(a => a.order_line[0] == orderLine);
                    var item = (string)pl.product_id[1];
                    var lower = item.IndexOf('[')+1;
                    var upper = item.IndexOf(']');
                    var code = lower == -1 || upper == -1?item: item.Substring(lower, upper - lower);
                    poHistModel.Add(new PoHistModel()
                    {
                        ItemCode = code,
                        Location = pl.orderpoint_id is bool ? "" : (string)pl.orderpoint_id[0],
                        SupplierCode = ((int)pl.partner_id[0]).ToString(),
                        OrderNumber = pl.order_id is bool ? "" : (string)pl.order_id[1],
                        LineNumber = orderLine,
                        OrderDate = orderDate,
                        OrderQuantity = pl.product_qty,
                        ExpectedDate = DateTime.Parse(pl.date_planned),
                        Urgency = match.priority == null ? "" : match.priority,
                        QuantityReceived = pl.qty_received,
                        DateOfReceipt = match.date_planned == null ? DateTime.MinValue : DateTime.Parse(match.date_planned),
                        UnitCost = pl.price_total
                    });
                }

                this._logger.Log(LogRecordType.info, "Successfully retrieved purchase order data ..........");
                callback(poHistModel.ToArray() as T[], path, this._logger);
                //callback(poResponse , path, _logger);

            }
            catch (Exception e)
            {
                _logger.Log(LogRecordType.info, $"Failed fetching {this.GetModelName()} data. {e.Message}");
                throw e;
            }
        }
    }

}