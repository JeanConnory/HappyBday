using Microsoft.AspNetCore.Mvc;
using HappyBday.Application.Contratos;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using HappyBday.Application.Dtos;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;
using HappyBday.Application;
using HappyBday.API.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace HappyBday.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AniversariosController : ControllerBase
    {
        private readonly IAniversarioService _aniversarioService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IAccountService _accountService;

        public AniversariosController(IAniversarioService aniversarioService,
                                        IAccountService accountService,
                                        IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _accountService = accountService;
            _aniversarioService = aniversarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var aniversarios = await _aniversarioService.GetAllAniversariosAsync(User.GetUserId(), true);
                if (aniversarios == null) return NoContent();

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
                var aniversario = await _aniversarioService.GetAniversarioByIdAsync(User.GetUserId(), id, true);
                if (aniversario == null) return NoContent();

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
                var aniversario = await _aniversarioService.GetAllAniversariosByNomeAsync(User.GetUserId(), nome, true);
                if (aniversario == null) return NoContent();

                return Ok(aniversario);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar aniversário. Erro: {ex.Message}");
            }
        }

        [HttpPost("upload-image/{aniversarioId}")]
        public async Task<IActionResult> UploadImage(int aniversarioId)
        {
            try
            {
                var aniversario = await _aniversarioService.GetAniversarioByIdAsync(User.GetUserId(), aniversarioId, true);
                if (aniversario == null) return NoContent();

                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                    DeleteImage(aniversario.ImagemUrl);
                    aniversario.ImagemUrl = await SaveImage(file);
                }

                var aniversarioRetorno = await _aniversarioService.UpdateAniversario(User.GetUserId(), aniversarioId, aniversario);

                return Ok(aniversarioRetorno);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar aniversário. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(AniversarioDto model)
        {
            try
            {
                var aniversario = await _aniversarioService.AddAniversario(User.GetUserId(), model);
                if (aniversario == null) return NoContent();

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
                var aniversario = await _aniversarioService.UpdateAniversario(User.GetUserId(), id, model);
                if (aniversario == null) return NoContent();

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
                var aniversario = await _aniversarioService.GetAniversarioByIdAsync(User.GetUserId(), id, true);
                if (aniversario == null) return NoContent();

                if (await _aniversarioService.DeleteAniversario(User.GetUserId(), id))
                {
                    DeleteImage(aniversario.ImagemUrl);
                    return Ok(new { message = "Deletado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problema não específico ao tentar deletar o aniversário");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar aniversário. Erro: {ex.Message}");
            }
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName)
                                              .Take(10)
                                              .ToArray()
                                              ).Replace(' ', '-');

            imageName = $"{imageName}{DateTime.UtcNow.ToString("yymmssfff")}{Path.GetExtension(imageFile.FileName)}";

            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, @"Resources/images", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return imageName;
        }

        [NonAction]
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, @"Resources/images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
    }
}
