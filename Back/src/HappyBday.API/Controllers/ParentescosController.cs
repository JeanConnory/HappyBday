using System;
using System.Collections.Generic;
using System.Linq;
using HappyBday.API.Data;
using HappyBday.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace HappyBday.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParentescosController : ControllerBase
    {
        private readonly DataContext _context;

        public ParentescosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Parentesco> Get()
        {
            return _context.Parentescos;
        }

        [HttpGet("{id}")]
        public Parentesco GetById(int id)
        {
            return _context.Parentescos.Where(p => p.Id == id).FirstOrDefault();
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
