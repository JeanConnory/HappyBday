using System.Collections.Generic;
using System.Threading.Tasks;
using HappyBday.Domain.Identity;
using HappyBday.Persistence.Contexto;
using HappyBday.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace HappyBday.Persistence
{
    public class UserPersist : GeralPersistence, IUserPersist
    {
        private readonly HappyBdayContext _context;

        public UserPersist(HappyBdayContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUserAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserAsyncByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserName == userName.ToLower());
        }
    }
}