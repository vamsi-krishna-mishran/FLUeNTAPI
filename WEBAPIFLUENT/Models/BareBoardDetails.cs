using Org.BouncyCastle.Math;
using WEBAPIFLUENT.Enums;

namespace WEBAPIFLUENT.Models
{
    public class BareBoardDetails
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; } 
        public string ImageData { get; set; }

        public BoardType BoardType { get; set; } 

        public int IId { get; set; }
        public Identity Identity { get; set; }
    }
}
