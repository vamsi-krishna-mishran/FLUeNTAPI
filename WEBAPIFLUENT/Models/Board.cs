namespace WEBAPIFLUENT.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Rivision> Rivisions { get; set;}
        
        public int VId { get; set; }
        public Varient Varient { get; set; }

    }
}
