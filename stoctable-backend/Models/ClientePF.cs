using System.ComponentModel.DataAnnotations;

namespace stoctable_backend.Models
{
    public class ClientePF : Pessoas
    {
        public int Id;
        public string Codigo { get; set; }
        [MaxLength(7)]
        public string CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal LimiteCredito { get; set; }
        [MaxLength(300)]
        public string Observacao { get; set; }
        

    }
}
