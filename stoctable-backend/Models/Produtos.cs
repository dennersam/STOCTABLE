using System.ComponentModel.DataAnnotations;

namespace stoctable_backend.Models
{
    public class Produtos
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        [MaxLength(300)]
        [Required]
        public string Descricao { get; set; }
        [MaxLength(50)]
        public string Unidade { get; set; }
        [MaxLength(100)]
        public string Fornecedor { get; set; }
        [MaxLength(300)]
        public string Fabricante { get; set; }
        [MaxLength(100)]
        public string Setor { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal MargemLucro { get; set; }
        public decimal CustoMedio { get; set; }
        public int Quantidade { get; set; }
        public int QtMinima { get; set; }
        [MaxLength(1000)]
        public string Observacao { get; set; }
        public decimal AlicotaICMS { get; set; }
        public decimal BaseCalcICMS { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal PesoLiquido { get; set; }
        [MaxLength(100)]
        public string CodigoInterno { get; set; }

    }
}
