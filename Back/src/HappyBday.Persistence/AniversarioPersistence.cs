using System.Linq;
using System.Threading.Tasks;
using HappyBday.Domain;
using HappyBday.Persistence.Contexto;
using HappyBday.Persistence.Contratos;
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

        public async Task<Aniversario[]> GetAllAniversariosAsync(bool includeParentesco = false)
        {
            IQueryable<Aniversario> query = _context.Aniversarios;
            
            if(includeParentesco)
            {
                query = query.Include(a => a.Parentesco);
            }            
            query = query.AsNoTracking().OrderBy(a => a.DataAniversario);

            return await query.ToArrayAsync();
        }

        public async Task<Aniversario[]> GetAllAniversariosByNomeAsync(string nome, bool includeParentesco = false)
        {
            IQueryable<Aniversario> query = _context.Aniversarios;
            
            if(includeParentesco)
            {
                query = query.Include(a => a.Parentesco);
            }            
            query = query.AsNoTracking().OrderBy(a => a.DataAniversario)
                         .Where(a => a.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Aniversario> GetAniversarioByIdAsync(int aniversarioId, bool includeParentesco = false)
        {
            IQueryable<Aniversario> query = _context.Aniversarios;
                      
            query = query.AsNoTracking().OrderBy(a => a.DataAniversario)
                         .Where(a => a.Id == aniversarioId);

            return await query.FirstOrDefaultAsync();
        }
    }
}