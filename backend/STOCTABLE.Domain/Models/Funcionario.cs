namespace STOCTABLE.Domain.Models
{
    public class Funcionario : Pessoa
    {
        public int Id { get; set; }
        public string RG { get; set; }
        public string? Ocupacao { get; set; }
        public double? Salario { get; set; }
        public DateTime? Admissao { get; set; }

    }
}
