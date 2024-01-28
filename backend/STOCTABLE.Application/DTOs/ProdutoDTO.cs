using STOCTABLE.Domain.Enums;
using STOCTABLE.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace STOCTABLE.Application.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        [MaxLength(300)]
        [Required(ErrorMessage = "Camop {0} precisa ser preenchido")]
        public string Descricao { get; set; }
        public virtual Unidade Unidade { get; set; }
        public int FabricanteId {get; set; }
        public virtual Fabricante? Fabricante { get; set; }
        public decimal? PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal? MargemLucro { get; set; }
        public decimal? CustoMedio { get; set; }
        public int Quantidade { get; set; }
        public int? QtMinima { get; set; } = 1;
        [MaxLength(1000, ErrorMessage = "A quantidade maxima de caracteres sâo 1000.")]
        public string? Observacao { get; set; }
        public decimal? AlicotaICMS { get; set; }
        public decimal? BaseCalcICMS { get; set; }
        public decimal? PesoBruto { get; set; }
        public decimal? PesoLiquido { get; set; }
        public string? Foto { get; set; }
    }
}
