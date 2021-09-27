namespace Models
{
    public struct PoModel
    {
        public string priority { get; set; }
        public string date_planned { get; set; }
        public int[] order_line { get; set; }
    }
}
