using STOCTABLE.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace STOCTABLE.Domain.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [MaxLength(300)]
        [Required]
        public string Descricao { get; set; }
        [MaxLength(50)]
        public Unidade? Unidade { get; set; }
        [MaxLength(100)]
        public int? FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
        [MaxLength(300)]
        public int? FabricanteId { get; set; }
        public Fabricante Fabricante { get; set; }
        public string? Categoria { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal? MargemLucro { get; set; }
        public decimal? CustoMedio { get; set; }
        public int? Quantidade { get; set; }
        public int? QtMinima { get; set; }
        [MaxLength(1000)]
        public string? Observacao { get; set; }
        public decimal? AlicotaICMS { get; set; }
        public decimal? BaseCalcICMS { get; set; }
        public decimal? PesoBruto { get; set; }
        public decimal? PesoLiquido { get; set; }

    }
}
