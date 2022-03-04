using System;
using System.Threading.Tasks;
using AutoMapper;
using HappyBday.Application.Contratos;
using HappyBday.Application.Dtos;
using HappyBday.Domain;
using HappyBday.Persistence.Contratos;

namespace HappyBday.Application
{
    public class ParentescoService : IParentescoService
    {
        private readonly IGeralPersistence _geralPersist;
        private readonly IParentescoPersistence _parentescoPersist;
        private readonly IMapper _mapper;

        public ParentescoService(IGeralPersistence geralPersist, IParentescoPersistence parentescoPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _parentescoPersist = parentescoPersist;
            _mapper = mapper;
        }

        public async Task<ParentescoDto> AddParentesco(ParentescoDto model)
        {
            try
            {
                var parentesco = _mapper.Map<Parentesco>(model);
                _geralPersist.Add<Parentesco>(parentesco);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var parentescoRetorno = await _parentescoPersist.GetParentescoByIdAsync(parentesco.Id);
                    return _mapper.Map<ParentescoDto>(parentescoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ParentescoDto> UpdateParentesco(int parentescoId, ParentescoDto model)
        {
            try
            {
                var parentesco = await _parentescoPersist.GetParentescoByIdAsync(parentescoId);
                if (parentesco == null) return null;

                model.Id = parentescoId;

                _mapper.Map(model, parentesco);

                _geralPersist.Update<Parentesco>(parentesco);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var parentescoRetorno = await _parentescoPersist.GetParentescoByIdAsync(parentesco.Id);
                    return _mapper.Map<ParentescoDto>(parentescoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteParentesco(int parentescoId)
        {
            try
            {
                var parentesco = await _parentescoPersist.GetParentescoByIdAsync(parentescoId);
                if (parentesco == null) throw new Exception("Parentesco não foi encontrado!");

                _geralPersist.Delete<Parentesco>(parentesco);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ParentescoDto[]> GetAllParentescosAsync()
        {
            try
            {
                var parentescos = await _parentescoPersist.GetAllParentescosAsync();
                if(parentescos == null) return null;

                var resultado = _mapper.Map<ParentescoDto[]>(parentescos);
                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<ParentescoDto[]> GetAllParentescosByDescricaoAsync(string descricao)
        {
            try
            {
                var parentescos = await _parentescoPersist.GetAllParentescosByDescricaoAsync(descricao);
                if(parentescos == null) return null;

                var resultado = _mapper.Map<ParentescoDto[]>(parentescos);
                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<ParentescoDto> GetParentescoByIdAsync(int parentescoId)
        {
            try
            {
                var parentesco = await _parentescoPersist.GetParentescoByIdAsync(parentescoId);
                if(parentesco == null) return null;

                var resultado = _mapper.Map<ParentescoDto>(parentesco);
                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

    }
}