using System;
using System.ComponentModel.DataAnnotations;

namespace HappyBday.Application.Dtos
{
    public class AniversarioDto
    {
        public int Id { get; set; }
         
        [Required(ErrorMessage = "O campo {0} é obrigatório!"),
         StringLength(255, MinimumLength = 3, ErrorMessage = "Intervalo permitido de 3 a 255 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string DataAniversario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Phone(ErrorMessage = "O campo {0} está com número inválido")]
        public string Telefone { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "O campo {0} precisa ser um e-mail válido!")]
        public string Email { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png|)$", ErrorMessage = "Não é uma imagem válida. (gif, jpg, jpeg, bmp ou png)")]
        public string ImagemUrl { get; set; }
        
        public ParentescoDto Parentesco { get; set; }
    }
}