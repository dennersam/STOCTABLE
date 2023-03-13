using STOCTABLE.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace STOCTABLE.Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Login { get; set; }
        [MaxLength(100)]
        public string Senha { get; set; }
        public Funcao Funcao { get; set; }

    }
}
