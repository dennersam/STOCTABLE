namespace STOCTABLE.Domain.Models
{
    public class Transportadora : Pessoa
    {
        public int Id { get; set; }
        public string? CNPJ { get; set; }
        public string? InscricaoEstadual { get; set; }
    }
}
