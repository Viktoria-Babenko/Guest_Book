using System.ComponentModel.DataAnnotations;

namespace Guest_Book.Models
{
    public class Messege
    {
        [Required]
        public string? Messeges { get; set; }
        public string? MessegeDate { get; set; }
        public string? User { get; set; }
    }
}
