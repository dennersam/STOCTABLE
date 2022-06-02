namespace stoctable_backend.Models
{
    public class Fornecedores : Pessoa
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string RefBancarias { get; set; }

    }
}
