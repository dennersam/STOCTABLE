namespace stoctable_backend.Models
{
    public abstract class Pessoa
    {
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public int Numero { get; set; }
        public string? Complemento { get; set; }
        public string? CEP { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Telefone { get; set; }
        public string? Celular { get; set; }
        public string? Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public string? Observacao { get; set; }

    }
}
