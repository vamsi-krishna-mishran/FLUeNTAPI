using System.ComponentModel.DataAnnotations;

namespace WEBAPIFLUENT.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="UserName Is required.")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
