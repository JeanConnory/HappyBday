using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using HappyBday.Application.Dtos;
using HappyBday.Application.Contratos;

namespace HappyBday.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParentescosController : ControllerBase
    {
        private readonly IParentescoService _parentescoService;

        public ParentescosController(IParentescoService parentescoService)
        {
            _parentescoService = parentescoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var parentescos = await _parentescoService.GetAllParentescosAsync();
                if(parentescos == null) return NoContent();

                return Ok(parentescos);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar parentesco. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var parentesco = await _parentescoService.GetParentescoByIdAsync(id);
                if(parentesco == null) return NoContent();

                return Ok(parentesco);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar parentesco. Erro: {ex.Message}");
            }
        }

        [HttpGet("{descricao}/descricao")]
        public async Task<IActionResult> GetByNome(string descricao)
        {
            try
            {
                var parentesco = await _parentescoService.GetAllParentescosByDescricaoAsync(descricao);
                if(parentesco == null) return NoContent();

                return Ok(parentesco);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar parentesco. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ParentescoDto model)
        {
            try
            {
                var parentesco = await _parentescoService.AddParentesco(model);
                if(parentesco == null) return NoContent();

                return Ok(parentesco);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar parentesco. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ParentescoDto model)
        {
            try
            {
                var parentesco = await _parentescoService.UpdateParentesco(id, model);
                if(parentesco == null) return NoContent();

                return Ok(parentesco);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar parentesco. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var parentesco = await _parentescoService.GetParentescoByIdAsync(id);
                if(parentesco == null) return NoContent();

                return await _parentescoService.DeleteParentesco(id) 
                            ? Ok( new { message = "Deletado" }) 
                            : throw new Exception("Ocorreu um problema não específico ao tentar deletar o parentesco");
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar parentesco. Erro: {ex.Message}");
            }
        }
    }
}
