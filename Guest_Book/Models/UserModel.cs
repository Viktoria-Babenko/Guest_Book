namespace Guest_Book.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Login { get; set; }

        public string? Password { get; set; }

        public string? Salt { get; set; }
        public ICollection<MessegesModel>? Messeges { get; set; }
        public UserModel()
        {
            this.Messeges = new HashSet<MessegesModel>();
        }
    }
}
