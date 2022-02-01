using System;
using System.Threading.Tasks;
using HappyBday.Application.Contratos;
using HappyBday.Domain;
using HappyBday.Persistence.Contratos;

namespace HappyBday.Application
{
    public class AniversarioService : IAniversarioService
    {
        private readonly IGeralPersistence _geralPersist;
        private readonly IAniversarioPersistence _aniversarioPersist;

        public AniversarioService(IGeralPersistence geralPersist, IAniversarioPersistence aniversarioPersist)
        {
            _aniversarioPersist = aniversarioPersist;
            _geralPersist = geralPersist;

        }

        public async Task<Aniversario> AddAniversario(Aniversario model)
        {
            try
            {
                _geralPersist.Add<Aniversario>(model);
                if(await _geralPersist.SaveChangesAsync())
                {
                    return await _aniversarioPersist.GetAniversarioByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Aniversario> UpdateAniversario(int aniversarioId, Aniversario model)
        {
            try
            {
                var aniversario = await _aniversarioPersist.GetAniversarioByIdAsync(aniversarioId, false);
                if(aniversario == null) return null;

                model.Id = aniversarioId;

                _geralPersist.Update(model);
                if(await _geralPersist.SaveChangesAsync())
                {
                    return await _aniversarioPersist.GetAniversarioByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAniversario(int aniversarioId)
        {
            try
            {
                var aniversario = await _aniversarioPersist.GetAniversarioByIdAsync(aniversarioId, false);
                if(aniversario == null) throw new Exception("Aniversario não foi encontrado");

                _geralPersist.Delete<Aniversario>(aniversario);
                return await _geralPersist.SaveChangesAsync(); 
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Aniversario[]> GetAllAniversariosAsync(bool includeParentesco = false)
        {
            try
            {
                var aniversarios = await _aniversarioPersist.GetAllAniversariosAsync(includeParentesco);
                if(aniversarios == null) return null;

                return aniversarios;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Aniversario[]> GetAllAniversariosByNomeAsync(string nome, bool includeParentesco = false)
        {
            try
            {
                var aniversarios = await _aniversarioPersist.GetAllAniversariosByNomeAsync(nome, includeParentesco);
                if(aniversarios == null) return null;

                return aniversarios;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Aniversario> GetAniversarioByIdAsync(int aniversarioId, bool includeParentesco = false)
        {
            try
            {
                var aniversarios = await _aniversarioPersist.GetAniversarioByIdAsync(aniversarioId, includeParentesco);
                if(aniversarios == null) return null;

                return aniversarios;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
    }
}