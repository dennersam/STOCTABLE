using System.ComponentModel.DataAnnotations;

namespace STOCTABLE.Domain.Models
{
    public class ClientePF : Pessoa
    {
        public int Id { get; set; }
        [MaxLength(11)]
        public string CPF { get; set; }
        public DateTime? Nascimento { get; set; }
        public DateTime? DataCadastro { get; set; }
        public decimal? LimiteCredito { get; set; }
        

    }
}
