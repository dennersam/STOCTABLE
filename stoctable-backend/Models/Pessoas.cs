using System.ComponentModel.DataAnnotations;

namespace stoctable_backend.Models
{
    public abstract class Pessoas
    {
        [MaxLength(100)]
        [Required]
        public string? Nome { get; set; }
        [MaxLength(100)]
        public string? Endereco { get; set; }
        [MaxLength(20)]
        public string? Numero { get; set; }
        [MaxLength(20)]
        public string? Complemento { get; set; }
        [MaxLength(8)]
        public string? CEP { get; set; }
        [MaxLength(50)]
        public string? Bairro { get; set; }
        [MaxLength(50)]
        public string? Cidade { get; set; }
        [MaxLength(50)]
        public string? Estado { get; set; }
        [MaxLength(20)]
        public string? Telefone { get; set; }
        [MaxLength(20)]
        public string? Celular { get; set; }
        [MaxLength(50)]
        public string? Email { get; set; }

    }
}
