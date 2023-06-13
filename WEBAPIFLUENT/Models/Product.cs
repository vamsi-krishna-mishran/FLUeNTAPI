namespace WEBAPIFLUENT.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 

        public ICollection<Varient> Varients { get; set; }
    }
}
