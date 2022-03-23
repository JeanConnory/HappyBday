using System;
using System.ComponentModel.DataAnnotations;

namespace HappyBday.Application.Dtos
{
    public class UserLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}