using Guest_book.Models;
namespace Guest_book.NewFolder
{
    public interface IRepository
    {
        Task<List<MessegesModel>> GetMessegesList();
        Task<List<UserModel>> GetUserList();
        IQueryable<UserModel> UserWhere(string login);
        int GetUserCount();
        Task<UserModel> GetUser(string login);
        Task<MessegesModel> GetMesseges(int id);
        Task CreateUser(UserModel item);
        Task CreateMessege(MessegesModel item, UserModel u);
        Task Save();
    }
}
