using Guest_Book.Models;

namespace Guest_Book.Repository
{
    public interface IRepository
    {
        List<MessegesModel> GetMessegesList();
        Task<List<UserModel>> GetUserList();
        IQueryable<UserModel> UserWhere(string login);
        int GetUserCount();
        Task<UserModel> GetUser(int id);
        Task<MessegesModel> GetMesseges(int id);
        Task CreateUser(UserModel item);
        Task CreateMessege(MessegesModel item, UserModel u);
        Task Save();
    }
}
