using System;
using System.ComponentModel.DataAnnotations;

namespace HappyBday.Application.Dtos
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string Profissao { get; set; }
        public string UserName { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Funcao { get; set; }
        public string Descricao { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}