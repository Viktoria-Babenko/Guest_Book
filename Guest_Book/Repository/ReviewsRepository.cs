using Guest_Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Guest_Book.Repository
{
    public class ReviewsRepository : IRepository
    {
        private readonly ReviewsContext _context;

        public ReviewsRepository(ReviewsContext context)
        {
            _context = context;
        }
        public async Task<List<UserModel>> GetUserList()
        {
            return await _context.Users.ToListAsync();
        }
        public int GetUserCount()
        {
            return _context.Users.ToList().Count;
        }
        public List<MessegesModel> GetMessegesList()
        {
            var reviewsContext = _context.Messeges.Include(p => p.User);
            return reviewsContext.ToList();
        }
        public IQueryable<UserModel> UserWhere(string login)
        {
            return _context.Users.Where(a => a.Login == login);
        }
        public async Task<UserModel> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<MessegesModel> GetMesseges(int id)
        {
            return await _context.Messeges.FindAsync(id);
        }

        public async Task CreateUser(UserModel c)
        {
            await _context.Users.AddAsync(c);
        }
        public async Task CreateMessege(MessegesModel c, UserModel u)
        {
            await _context.Messeges.AddAsync(c);
            await _context.SaveChangesAsync();
            u.Messeges.Add(c);
            _context.Entry(c).State = EntityState.Modified;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
