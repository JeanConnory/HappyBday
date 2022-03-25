using System.Threading.Tasks;
using HappyBday.Application.Dtos;

namespace HappyBday.Application.Contratos
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserUpdateDto userUpdateDto);
    }
}