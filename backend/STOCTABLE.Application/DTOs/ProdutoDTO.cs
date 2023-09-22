using STOCTABLE.Domain.Enums;
using STOCTABLE.Domain.Models;

namespace STOCTABLE.Application.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual Unidade Unidades { get; set; }
        public int FabricanteId {get; set; }
        public virtual Fabricante? Fabricante { get; set; }
        public decimal? PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal? MargemLucro { get; set; }
        public decimal? CustoMedio { get; set; }
        public int Quantidade { get; set; }
        public int? QtMinima { get; set; } = 1;
        public string? Observacao { get; set; }
        public decimal? AlicotaICMS { get; set; }
        public decimal? BaseCalcICMS { get; set; }
        public decimal? PesoBruto { get; set; }
        public decimal? PesoLiquido { get; set; }
    }
}
