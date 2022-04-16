using System;
using System.Threading.Tasks;
using AutoMapper;
using HappyBday.Application.Contratos;
using HappyBday.Application.Dtos;
using HappyBday.Domain;
using HappyBday.Persistence.Contratos;
using HappyBday.Persistence.Pagination;

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

        public async Task<AniversarioDto> AddAniversario(int userId, AniversarioDto model)
        {
            try
            {
                var aniversario = _mapper.Map<Aniversario>(model);
                aniversario.UserId = userId;

                _geralPersist.Add<Aniversario>(aniversario);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var aniversarioRetorno = await _aniversarioPersist.GetAniversarioByIdAsync(userId, aniversario.Id, false);

                    return _mapper.Map<AniversarioDto>(aniversarioRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AniversarioDto> UpdateAniversario(int userId, int aniversarioId, AniversarioDto model)
        {
            try
            {
                var aniversario = await _aniversarioPersist.GetAniversarioByIdAsync(userId, aniversarioId, false);
                if (aniversario == null) return null;

                model.Id = aniversarioId;
                model.UserId = userId;

                _mapper.Map(model, aniversario);

                _geralPersist.Update<Aniversario>(aniversario);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var aniversarioRetorno = await _aniversarioPersist.GetAniversarioByIdAsync(userId, aniversario.Id, false);

                    return _mapper.Map<AniversarioDto>(aniversarioRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAniversario(int userId, int aniversarioId)
        {
            try
            {
                var aniversario = await _aniversarioPersist.GetAniversarioByIdAsync(userId, aniversarioId, false);
                if (aniversario == null) throw new Exception("Aniversario não foi encontrado");

                _geralPersist.Delete<Aniversario>(aniversario);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PageList<AniversarioDto>> GetAllAniversariosAsync(int userId, PageParams pageParams, bool includeParentesco = false)
        {
            try
            {
                var aniversarios = await _aniversarioPersist.GetAllAniversariosAsync(userId, pageParams, includeParentesco);
                if (aniversarios == null) return null;

                var resultado = _mapper.Map<PageList<AniversarioDto>>(aniversarios);

                resultado.CurrentPage = aniversarios.CurrentPage;
                resultado.TotalPages = aniversarios.TotalPages;
                resultado.PageSize = aniversarios.PageSize;
                resultado.TotalCount = aniversarios.TotalCount;

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AniversarioDto> GetAniversarioByIdAsync(int userId, int aniversarioId, bool includeParentesco = false)
        {
            try
            {
                var aniversario = await _aniversarioPersist.GetAniversarioByIdAsync(userId, aniversarioId, includeParentesco);
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