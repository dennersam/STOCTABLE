namespace STOCTABLE.Domain.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int? ProdutoId { get; set; }
        public virtual IEnumerable<Produto>? Produtos { get; set; }

    }
}
