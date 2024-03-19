using System.ComponentModel.DataAnnotations;

namespace Guest_book.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Имя")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string? LastName { get; set; }

        [Required]
        [Display(Name = "Логин")]
        public string? Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пороль")]
        public string? Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Пороль потверждение")]
        public string? PasswordConfirm { get; set; }
    }
}
