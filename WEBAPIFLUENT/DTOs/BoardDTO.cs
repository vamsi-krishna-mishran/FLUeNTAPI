using Microsoft.AspNetCore.Mvc;

namespace WEBAPIFLUENT.DTOs
{
    public class BoardDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public int VId { get; set; }

    }
}
