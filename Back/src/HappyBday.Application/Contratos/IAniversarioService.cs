using System.Threading.Tasks;
using HappyBday.Application.Dtos;
using HappyBday.Persistence.Pagination;

namespace HappyBday.Application.Contratos
{
    public interface IAniversarioService
    {
        Task<AniversarioDto> AddAniversario(int userId, AniversarioDto model);
        Task<AniversarioDto> UpdateAniversario(int userId, int aniversarioId, AniversarioDto model);
        Task<bool> DeleteAniversario(int userId, int aniversarioId);
        Task<PageList<AniversarioDto>> GetAllAniversariosAsync(int userId, PageParams pageParams, bool includeParentesco = false);
        Task<AniversarioDto> GetAniversarioByIdAsync(int userId, int aniversarioId, bool includeParentesco = false);
    }
}