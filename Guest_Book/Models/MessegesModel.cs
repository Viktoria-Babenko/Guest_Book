using System.ComponentModel.DataAnnotations;

namespace Guest_Book.Models
{
    public class MessegesModel
    {
        public int Id { get; set; }
        [Required]
        public string? Messeges { get; set; }
        public DateTime? MessegeDate { get; set; }
        public int UserId { get; set; }
        public UserModel? User { get; set; }
    }
}
