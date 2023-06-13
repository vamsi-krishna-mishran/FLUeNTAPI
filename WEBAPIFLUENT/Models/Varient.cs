namespace WEBAPIFLUENT.Models
{
    public class Varient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Board> Boards { get; set; }
        
        public int PId { get; set; }
        public Product Product { get; set; }
    }
}
