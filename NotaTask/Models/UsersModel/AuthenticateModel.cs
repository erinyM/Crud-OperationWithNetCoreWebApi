using System.ComponentModel.DataAnnotations;

namespace NotaTask.Models.UsersModel
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}