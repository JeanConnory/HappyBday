using System.Threading.Tasks;
using HappyBday.Domain;

namespace HappyBday.Persistence.Contratos
{
    public interface IAniversarioPersistence
    {
        Task<Aniversario[]> GetAllAniversariosByNomeAsync(int userId, string nome, bool includeParentesco = false);
        Task<Aniversario[]> GetAllAniversariosAsync(int userId, bool includeParentesco = false);
        Task<Aniversario> GetAniversarioByIdAsync(int userId, int aniversarioId, bool includeParentesco = false);
    }
}