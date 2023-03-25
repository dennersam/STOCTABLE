using STOCTABLE.Domain.Enums;
using System.Diagnostics.Contracts;

namespace STOCTABLE.Domain.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public int ProdutoId { get; set; }
        public IEnumerable<Produto> Produto { get; set; }
        public double ValorTotal { get; set; }
        public TipoPagamento TipoPagamento { get; set;}
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set;}

    }
}
