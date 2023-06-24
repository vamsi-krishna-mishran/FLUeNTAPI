using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPIFLUENT.Models
{
    public class XLTamplate 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SHId { get; set; }
        public SubHeading SubHeading { get; set; }

        public ICollection<XLSheet> Sheets { get; set; }
    }
}
