using System.Linq;
using System.Threading.Tasks;
using HappyBday.Domain;
using HappyBday.Persistence.Contexto;
using HappyBday.Persistence.Contratos;
using HappyBday.Persistence.Pagination;
using Microsoft.EntityFrameworkCore;

namespace HappyBday.Persistence
{
    public class AniversarioPersistence : IAniversarioPersistence
    {
        private readonly HappyBdayContext _context;

        public AniversarioPersistence(HappyBdayContext context)
        {
            _context = context;
        }

        public async Task<PageList<Aniversario>> GetAllAniversariosAsync(int userId, PageParams pageParams, bool includeParentesco = false)
        {
            IQueryable<Aniversario> query = _context.Aniversarios;
             
            if(includeParentesco)
            {
                query = query.Include(a => a.Parentesco);
            }            
            query = query.AsNoTracking()
                            .Where(a => (a.Nome.ToLower().Contains(pageParams.Term .ToLower()) || 
                                         a.Email.ToLower().Contains(pageParams.Term .ToLower())) && 
                                     a.UserId == userId)
                            .OrderBy(a => a.DataAniversario);

            return await PageList<Aniversario>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }

        public async Task<Aniversario> GetAniversarioByIdAsync(int userId, int aniversarioId, bool includeParentesco = false)
        {
            IQueryable<Aniversario> query = _context.Aniversarios;
                      
            query = query.AsNoTracking().OrderBy(a => a.DataAniversario)
                         .Where(a => a.Id == aniversarioId && a.UserId == userId);
            
            if(includeParentesco)
            {
                query = query
                            .Include(p => p.Parentesco);
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}