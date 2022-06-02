namespace stoctable_backend.Models
{
    public class ClientePF : Pessoa
    {
        public int Id;
        public string CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public string Codigo { get; set; }
        public double LimiteCredito { get; set; }

    }
}
