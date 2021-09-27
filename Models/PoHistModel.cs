using System;

namespace Models
{
    public struct PoHistModel
    {
        public string ItemCode { get; set; }
        public string Location { get; set; }
        public string SupplierCode { get; set; }
        public string OrderNumber { get; set; }
        public int LineNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderQuantity { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string Urgency { get; set; }
        public double QuantityReceived { get; set; }
        public DateTime DateOfReceipt { get; set; }
        public double UnitCost { get; set; }

    }
}
