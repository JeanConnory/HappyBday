using System;
using System.Threading.Tasks;
using AutoMapper;
using HappyBday.Application.Contratos;
using HappyBday.Application.Dtos;
using HappyBday.Domain;
using HappyBday.Persistence.Contratos;

namespace HappyBday.Application
{
    public class AniversarioService : IAniversarioService
    {
        private readonly IGeralPersistence _geralPersist;
        private readonly IAniversarioPersistence _aniversarioPersist;
        private readonly IMapper _mapper;

        public AniversarioService(IGeralPersistence geralPersist, IAniversarioPersistence aniversarioPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _aniversarioPersist = aniversarioPersist;
            _mapper = mapper;
        }

        public async Task<AniversarioDto> AddAniversario(AniversarioDto model)
        {
            try
            {
                var aniversario = _mapper.Map<Aniversario>(model);

                _geralPersist.Add<Aniversario>(aniversario);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var aniversarioRetorno = await _aniversarioPersist.GetAniversarioByIdAsync(aniversario.Id, false);

                    return _mapper.Map<AniversarioDto>(aniversarioRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AniversarioDto> UpdateAniversario(int aniversarioId, AniversarioDto model)
        {
            try
            {
                var aniversario = await _aniversarioPersist.GetAniversarioByIdAsync(aniversarioId, false);
                if (aniversario == null) return null;

                model.Id = aniversarioId;

                _mapper.Map(model, aniversario);

                _geralPersist.Update<Aniversario>(aniversario);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var aniversarioRetorno = await _aniversarioPersist.GetAniversarioByIdAsync(aniversario.Id, false);

                    return _mapper.Map<AniversarioDto>(aniversarioRetorno);
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
                if (aniversario == null) throw new Exception("Aniversario não foi encontrado");

                _geralPersist.Delete<Aniversario>(aniversario);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AniversarioDto[]> GetAllAniversariosAsync(bool includeParentesco = false)
        {
            try
            {
                var aniversarios = await _aniversarioPersist.GetAllAniversariosAsync(includeParentesco);
                if (aniversarios == null) return null;

                var resultado = _mapper.Map<AniversarioDto[]>(aniversarios);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AniversarioDto[]> GetAllAniversariosByNomeAsync(string nome, bool includeParentesco = false)
        {
            try
            {
                var aniversarios = await _aniversarioPersist.GetAllAniversariosByNomeAsync(nome, includeParentesco);
                if (aniversarios == null) return null;

                var resultado = _mapper.Map<AniversarioDto[]>(aniversarios);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AniversarioDto> GetAniversarioByIdAsync(int aniversarioId, bool includeParentesco = false)
        {
            try
            {
                var aniversario = await _aniversarioPersist.GetAniversarioByIdAsync(aniversarioId, includeParentesco);
                if (aniversario == null) return null;

                var resultado = _mapper.Map<AniversarioDto>(aniversario);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}