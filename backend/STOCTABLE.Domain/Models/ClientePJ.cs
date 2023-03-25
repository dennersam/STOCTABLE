using System.ComponentModel.DataAnnotations;

namespace STOCTABLE.Domain.Models
{
    public class ClientePJ : Pessoa
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Contato { get; set; }
        [MaxLength(14)]
        public string CNPJ { get; set; }
        [MaxLength(9)]
        public string? InscricaoEstadual { get; set; }
        public DateTime? DataCadastro { get; set; }

    }
}
