namespace WEBAPIFLUENT.Models
{
    public class SubHeadingImages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageData { get; set; }
        public int SHId { get; set; }
        public SubHeading subHeading {  get; set; }

    }
}
