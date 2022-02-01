using System.Linq;
using System.Threading.Tasks;
using HappyBday.Domain;
using HappyBday.Persistence.Contexto;
using HappyBday.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace HappyBday.Persistence
{
    public class ParentescoPersistence : IParentescoPersistence
    {
        private readonly HappyBdayContext _context;

        public ParentescoPersistence(HappyBdayContext context)
        {
            _context = context;
        }
        
        public async Task<Parentesco[]> GetAllParentescosAsync()
        {
            IQueryable<Parentesco> query = _context.Parentescos;
                      
            query = query.AsNoTracking().OrderBy(p => p.Descricao);

            return await query.ToArrayAsync();
        }

        public async Task<Parentesco[]> GetAllParentescosByDescricaoAsync(string descricao)
        {
            IQueryable<Parentesco> query = _context.Parentescos;
             
            query = query.AsNoTracking().OrderBy(p => p.Descricao)
                         .Where(p => p.Descricao.ToLower().Contains(descricao.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Parentesco> GetParentescoByIdAsync(int parentescoId)
        {
            IQueryable<Parentesco> query = _context.Parentescos;
                      
            query = query.AsNoTracking().OrderBy(p => p.Descricao)
                         .Where(p => p.Id == parentescoId);

            return await query.FirstOrDefaultAsync();
        }
    }
}