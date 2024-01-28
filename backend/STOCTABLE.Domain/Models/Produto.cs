using STOCTABLE.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STOCTABLE.Domain.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual Unidade Unidade { get; set; }
        public decimal? PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal? MargemLucro { get; set; }
        public decimal? CustoMedio { get; set; }
        public int Quantidade { get; set; }
        public int? QtMinima { get; set; } = 1;
        public string? Foto { get; set; }
        public string? Observacao { get; set; }
        public decimal? AlicotaICMS { get; set; }
        public decimal? BaseCalcICMS { get; set; }
        public decimal? PesoBruto { get; set; }
        public decimal? PesoLiquido { get; set; }
        public int? FornecedorId { get; set; }
        public virtual Fornecedor? Fornecedor { get; set; }
        public int? FabricanteId { get; set; }
        public virtual Fabricante? Fabricante { get; set; }
        public int? CategoriaId { get; set; }
        public virtual Categoria? Categoria { get; set; }

    }
}
