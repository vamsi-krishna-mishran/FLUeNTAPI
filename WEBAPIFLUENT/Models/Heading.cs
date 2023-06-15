namespace WEBAPIFLUENT.Models
{
    public class Heading
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int IId { get; set; }
        public Identity Identity { get; set; }
        public ICollection<SubHeading> SubHeading { get; set; }


    }
}
