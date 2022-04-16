using System.Threading.Tasks;
using HappyBday.Domain;
using HappyBday.Persistence.Pagination;

namespace HappyBday.Persistence.Contratos
{
    public interface IAniversarioPersistence
    {
        Task<PageList<Aniversario>> GetAllAniversariosAsync(int userId, PageParams pageParams, bool includeParentesco = false);
        Task<Aniversario> GetAniversarioByIdAsync(int userId, int aniversarioId, bool includeParentesco = false);
    }
}