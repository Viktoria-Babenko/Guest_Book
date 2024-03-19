using System.ComponentModel.DataAnnotations;

namespace Guest_book.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string? Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string? Password { get; set; }
    }
}
