using CookComputing.XmlRpc;

namespace Models
{
    public struct LocationModel
    {
        public int id { get; set; }
        public string complete_name { get; set; }
        public bool active { get; set; }
        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public string group { get; set; }
        public string usage { get; set; }

        [XmlRpcMissingMapping(MappingAction.Ignore)]
        public int activeInt
        {
            get
            {
                return active?1:0;
            }
            set { }
        }
    }
}
