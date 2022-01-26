using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyBday.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HappyBday.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProximidadeController : ControllerBase
    {
        public ProximidadeController()
        {
        }

        public IEnumerable<Proximidade> _proximidades = new Proximidade[] 
        {
            new Proximidade() 
                {
                    Id = 1,
                    Descricao = "Mãe",
                    Ativo = true,
                    DataCriado = DateTime.Now
                },
                new Proximidade() 
                {
                    Id = 2,
                    Descricao = "Pai",
                    Ativo = true,
                    DataCriado = DateTime.Now
                }
        };

        [HttpGet]
        public IEnumerable<Proximidade> Get()
        {
            return _proximidades;
        }

        [HttpGet("{id}")]
        public Proximidade Get(int id)
        {
            return _proximidades.Where(p => p.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public string Post()
        {
            return "Exemplo de Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Delete com id = {id}";
        }
    }
}
