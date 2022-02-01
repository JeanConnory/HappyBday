using System.Threading.Tasks;
using HappyBday.Domain;

namespace HappyBday.Persistence.Contratos
{
    public interface IAniversarioPersistence
    {
        Task<Aniversario[]> GetAllAniversariosByNomeAsync(string nome, bool includeParentesco = false);
        Task<Aniversario[]> GetAllAniversariosAsync(bool includeParentesco = false);
        Task<Aniversario> GetAniversarioByIdAsync(int aniversarioId, bool includeParentesco = false);
    }
}