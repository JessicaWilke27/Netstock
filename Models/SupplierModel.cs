using CookComputing.XmlRpc;

namespace Models
{
    public struct SupplierModel
    {
        public dynamic[] name { get; set; }

        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string type { get; set; }
        public int delay { get; set; }

        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public int id {
            get
            {
                return name != null && name.Length > 0 ? name[0] : 0;
            }
            set { }
        }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string supplier
        {
            get
            {
                return name != null && name.Length > 0 ? name[1] : "";
            }
            set { }
        }
    }
}
