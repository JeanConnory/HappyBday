using System.Threading.Tasks;
using HappyBday.Domain;

namespace HappyBday.Application.Contratos
{
    public interface IAniversarioService
    {
        Task<Aniversario> AddAniversario(Aniversario model);
        Task<Aniversario> UpdateAniversario(int aniversarioId, Aniversario model);
        Task<bool> DeleteAniversario(int aniversarioId);
        Task<Aniversario[]> GetAllAniversariosAsync(bool includeParentesco = false);
        Task<Aniversario[]> GetAllAniversariosByNomeAsync(string nome, bool includeParentesco = false);
        Task<Aniversario> GetAniversarioByIdAsync(int aniversarioId, bool includeParentesco = false);
    }
}