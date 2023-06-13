namespace WEBAPIFLUENT.Models
{
    public class Identity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        
        public int RId { get; set; }
        public Rivision Rivision { get; set; }

        public ICollection<BareBoardDetails> BareBoardDetails { get; set;}

    }
}
