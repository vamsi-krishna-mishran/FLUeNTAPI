namespace WEBAPIFLUENT.Models
{
    public class XLSheet
    {
        public int Id { get; set; }
        public string Col1 { get; set; }
        public string Col2 { get; set; }
        public string Col3 { get; set; }
        public string Col4 { get; set; }

        public int XId { get; set; }
        public XLTamplate XLTamplate { get; set; }

    }
}
