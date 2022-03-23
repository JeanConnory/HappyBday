using System.Collections.Generic;
using System.Threading.Tasks;
using HappyBday.Domain.Identity;

namespace HappyBday.Persistence.Contratos
{
    public interface IUserPersist : IGeralPersistence
    {
        Task<IEnumerable<User>> GetUserAsync();

        Task<User> GetUserAsyncByIdAsync(int id);

        Task<User> GetUserByUserNameAsync(string userName);
    }
}