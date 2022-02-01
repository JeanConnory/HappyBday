using System.Threading.Tasks;
using HappyBday.Domain;

namespace HappyBday.Persistence.Contratos
{
    public interface IParentescoPersistence
    {
         Task<Parentesco[]> GetAllParentescosByDescricaoAsync(string descricao);
         Task<Parentesco[]> GetAllParentescosAsync();
         Task<Parentesco> GetParentescoByIdAsync(int parentescoId);
    }
}