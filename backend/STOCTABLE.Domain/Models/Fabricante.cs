namespace STOCTABLE.Domain.Models
{
    public class Fabricante
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public int? ProdutoId { get; set; }
        public virtual IEnumerable<Produto>? Produto { get; set; }    
    }
}
