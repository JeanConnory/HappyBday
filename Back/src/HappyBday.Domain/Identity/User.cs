using System;
using System.Collections.Generic;
using HappyBday.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace HappyBday.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public Profissao Profissao { get; set; }
        public string Descricao{ get; set; }
        public Funcao Funcao { get; set; }
        public string ImagemURL { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }

    }
}