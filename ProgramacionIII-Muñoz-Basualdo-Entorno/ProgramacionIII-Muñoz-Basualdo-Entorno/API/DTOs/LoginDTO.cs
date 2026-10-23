using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
   
    public class LoginDTO
    {
        
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no esta bien escrito")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; } = string.Empty;
    }
}
