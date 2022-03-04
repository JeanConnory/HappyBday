using System.Threading.Tasks;
using HappyBday.Application.Dtos;

namespace HappyBday.Application.Contratos
{
    public interface IParentescoService
    {
        Task<ParentescoDto> AddParentesco(ParentescoDto model);
        Task<ParentescoDto> UpdateParentesco(int parentescoId, ParentescoDto model);
        Task<bool> DeleteParentesco(int parentescoId);
        Task<ParentescoDto[]> GetAllParentescosAsync();
        Task<ParentescoDto[]> GetAllParentescosByDescricaoAsync(string descricao);
        Task<ParentescoDto> GetParentescoByIdAsync(int parentescoId);
    }
}