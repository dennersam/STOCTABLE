namespace stoctable_backend.Models
{
    public class Funcionarios
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string RG { get; set; }
        public string Ocupacao { get; set; }
        public double Salario { get; set; }
        public DateTime Admissao { get; set; }

    }
}
