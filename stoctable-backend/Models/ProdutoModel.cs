namespace stoctable_backend.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public string Fornecedor { get; set; }
        public string Fabricante { get; set; }
        public string Setor { get; set; }
        public double PrecoCusto { get; set; }
        public double PrecoVenda { get; set; }
        public int MargemLucro { get; set; }
        public double CustoMedio { get; set; }
        public int Quantidade { get; set; }
        public int QtMinima { get; set; }
        public string Observacao { get; set; }
        public double AlicotaICMS { get; set; }
        public double BaseCalcICMS { get; set; }
        public double PesoBruto { get; set; }
        public double PesoLiquido { get; set; }
        public string CodigoInterno { get; set; }

    }
}
