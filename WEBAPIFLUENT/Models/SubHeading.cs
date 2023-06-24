namespace WEBAPIFLUENT.Models
{
    public class SubHeading
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
        //public bool IsEo { get; set; }

        public int HId { get; set; }
        public Heading Heading { get; set; }

        public ICollection<SubHeadingImages> SubHeadingImages { get; set; }

        public ICollection<XLTamplate> XLTamplate { get; set; }
    }
}
