using System.ComponentModel.DataAnnotations;

namespace ClienteApp.API.DTOs.Request
{
    public class CriarClienteRequestDto
    {
        [MinLength(8, ErrorMessage ="Por favor, informe um nome com no minímo 8 caracteres. ")]
        [MaxLength(50, ErrorMessage ="Por favor, informe um nome com no máximo 50 caracteres. ")]
        [Required(ErrorMessage ="Por favor, informe o nome do cliente. ")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage ="Por favor, informe um endereço de email válido. ")]
        [Required(ErrorMessage ="Por favor, informe o email do cliente. ")]
        public string Email { get; set; }


        [Required(ErrorMessage ="Por favor, informe o cpf do cliente. ")]
        public string Cpf { get; set; }



    }
}
