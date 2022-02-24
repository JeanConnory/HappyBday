using System;

namespace HappyBday.Domain
{
    public class Aniversario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataAniversario { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; } 

        public string ImagemUrl { get; set; }

        public int? ParentescoId { get; set; }

        public Parentesco Parentesco { get; set; }
    }
}