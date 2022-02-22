using System.Threading.Tasks;
using HappyBday.Application.Dtos;

namespace HappyBday.Application.Contratos
{
    public interface IAniversarioService
    {
        Task<AniversarioDto> AddAniversario(AniversarioDto model);
        Task<AniversarioDto> UpdateAniversario(int aniversarioId, AniversarioDto model);
        Task<bool> DeleteAniversario(int aniversarioId);
        Task<AniversarioDto[]> GetAllAniversariosAsync(bool includeParentesco = false);
        Task<AniversarioDto[]> GetAllAniversariosByNomeAsync(string nome, bool includeParentesco = false);
        Task<AniversarioDto> GetAniversarioByIdAsync(int aniversarioId, bool includeParentesco = false);
    }
}