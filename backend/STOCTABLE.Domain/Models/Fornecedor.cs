namespace STOCTABLE.Domain.Models
{
    public class Fornecedor : Pessoa
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? RefBancarias { get; set; }

    }
}
