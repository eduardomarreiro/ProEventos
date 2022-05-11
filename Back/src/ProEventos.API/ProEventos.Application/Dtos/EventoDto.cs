using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; } 
        public string Local { get; set; }
        public DateTime DataDoEvento { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório"),
        /*MinLength(3, ErrorMessage = "{0} deve ter no mínimo 4 caracteres"),
        MaxLength(50, ErrorMessage = "{0} deve ter no máximo 50 caracteres")*/
        StringLength(50, MinimumLength = 3, ErrorMessage = "{0} deve ter entre 3 e 4 caracteres.")]
        public string Tema { get; set; }

        [Range(1, 120000, ErrorMessage ="A quantidade máxima permitida é 120000")]
        [Display(Name ="Quantidade de pessoas")]
        public int QuantidadeDePessoas { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage ="Não é uma imagem válida")]
        public string ImagemURL { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [Phone(ErrorMessage = "O campo {0} está com número inválido")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "O campo {0} deve ser um e-mail válido"),
         Display(Name ="e-email"),
         Required]
        public string Email { get; set; }
        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> Palestrantes { get; set; }
    }
}
