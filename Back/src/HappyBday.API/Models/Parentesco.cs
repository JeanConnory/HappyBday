using System;

namespace HappyBday.API.Models
{
    public class Parentesco
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCriado { get; set; }
    }
}