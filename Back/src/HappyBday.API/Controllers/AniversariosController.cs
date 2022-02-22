using Microsoft.AspNetCore.Mvc;
using HappyBday.Application.Contratos;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using HappyBday.Application.Dtos;

namespace HappyBday.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AniversariosController : ControllerBase
    {
        private readonly IAniversarioService _aniversarioService;

        public AniversariosController(IAniversarioService aniversarioService)
        {
            _aniversarioService = aniversarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var aniversarios = await _aniversarioService.GetAllAniversariosAsync(true);
                if(aniversarios == null) return NoContent();

                return Ok(aniversarios);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar aniversários. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var aniversario = await _aniversarioService.GetAniversarioByIdAsync(id, true);
                if(aniversario == null) return NoContent();

                return Ok(aniversario);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar aniversário. Erro: {ex.Message}");
            }
        }

        [HttpGet("{nome}/nome")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                var aniversario = await _aniversarioService.GetAllAniversariosByNomeAsync(nome, true);
                if(aniversario == null) return NoContent();

                return Ok(aniversario);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar aniversário. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(AniversarioDto model)
        {
            try
            {
                var aniversario = await _aniversarioService.AddAniversario(model);
                if(aniversario == null) return NoContent();

                return Ok(aniversario);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar aniversário. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, AniversarioDto model)
        {
            try
            {
                var aniversario = await _aniversarioService.UpdateAniversario(id, model);
                if(aniversario == null) return NoContent();

                return Ok(aniversario);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar aniversário. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var aniversario = await _aniversarioService.GetAniversarioByIdAsync(id, true);
                if(aniversario == null) return NoContent();

                return await _aniversarioService.DeleteAniversario(id) ? 
                            Ok("Deletado") : 
                            throw new Exception("Ocorreu um problema não específico ao tentar deletar o aniversário");
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar aniversário. Erro: {ex.Message}");
            }
        }
    }
}
