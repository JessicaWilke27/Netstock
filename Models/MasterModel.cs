using CookComputing.XmlRpc;
using System.Collections.Generic;

namespace Models
{
    public struct MasterModel
    {
        //Due to XML-RPC library constraints standard naming conventions not used
        public int id { get; set; }
        public dynamic code { get; set; }
        public dynamic description { get; set; }
        public dynamic uom_name { get; set; }
        public double volume { get; set; }
        public double weight { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public dynamic supersededItemCode { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public double supersededItemFactor { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string notUsed { get; set; }
    }
}
