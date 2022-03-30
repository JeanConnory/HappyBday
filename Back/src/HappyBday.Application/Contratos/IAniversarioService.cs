using System.Threading.Tasks;
using HappyBday.Application.Dtos;

namespace HappyBday.Application.Contratos
{
    public interface IAniversarioService
    {
        Task<AniversarioDto> AddAniversario(int userId, AniversarioDto model);
        Task<AniversarioDto> UpdateAniversario(int userId, int aniversarioId, AniversarioDto model);
        Task<bool> DeleteAniversario(int userId, int aniversarioId);
        Task<AniversarioDto[]> GetAllAniversariosAsync(int userId, bool includeParentesco = false);
        Task<AniversarioDto[]> GetAllAniversariosByNomeAsync(int userId, string nome, bool includeParentesco = false);
        Task<AniversarioDto> GetAniversarioByIdAsync(int userId, int aniversarioId, bool includeParentesco = false);
    }
}