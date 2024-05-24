namespace ClienteApp.API.DTOs.Response
{
    public class EditarClienteResponseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataHoraUltimaAtualizacao  { get; set; }
    }
}
