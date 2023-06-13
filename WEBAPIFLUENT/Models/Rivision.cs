namespace WEBAPIFLUENT.Models
{
    public class Rivision
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Identity> Identity { get; set; }
        
        public int BId { get; set; }
        public Board Board { get; set; }
    }
}
