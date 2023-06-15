namespace WEBAPIFLUENT.Models
{
    public class SubHeading
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int HId { get; set; }
        public Heading Heading { get; set; }
    }
}
