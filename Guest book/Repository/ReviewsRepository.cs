using Guest_book.NewFolder;
using Microsoft.EntityFrameworkCore;
using Guest_book.Models;

namespace Guest_book.Repository
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
        public async Task<List<MessegesModel>> GetMessegesList()
        {
            var reviewsContext = _context.Messeges.Include(p => p.User);
            return await reviewsContext.ToListAsync();
        }
        public IQueryable<UserModel> UserWhere(string login)
        {
            return _context.Users.Where(a => a.Login == login);
        }
        public async Task<UserModel> GetUser(string login)
        {
            return await _context.Users.FirstOrDefaultAsync(m => m.Login == login);
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
