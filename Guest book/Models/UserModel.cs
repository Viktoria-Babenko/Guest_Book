using System.ComponentModel.DataAnnotations;

namespace Guest_book.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Имя")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Фамилия")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Логин")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public ICollection<MessegesModel>? Messeges { get; set; }
        public UserModel()
        {
            this.Messeges = new HashSet<MessegesModel>();
        }
    }
