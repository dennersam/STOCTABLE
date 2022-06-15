using System.ComponentModel.DataAnnotations;

namespace stoctable_backend.DTO
{
    public class ProdutosDTO
    {
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public string Fornecedor { get; set; }
        public string Fabricante { get; set; }
        public string Setor { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal MargemLucro { get; set; }
        public decimal CustoMedio { get; set; }
        public int Quantidade { get; set; }
        public int QtMinima { get; set; }
        public string Observacao { get; set; }
        public decimal AlicotaICMS { get; set; }
        public decimal BaseCalcICMS { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal PesoLiquido { get; set; }
        public string CodigoInterno { get; set; }
    }
}
