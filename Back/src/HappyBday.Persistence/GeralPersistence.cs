using System.Threading.Tasks;
using HappyBday.Persistence.Contexto;
using HappyBday.Persistence.Contratos;

namespace HappyBday.Persistence
{
    public class GeralPersistence : IGeralPersistence
    {
        private readonly HappyBdayContext _context;

        public GeralPersistence(HappyBdayContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}