using stoctable_backend.Enums;
using System.ComponentModel.DataAnnotations;

namespace stoctable_backend.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Usuario { get; set; }
        [MaxLength(100)]
        public string Senha { get; set; }
        public Grupo Grupo { get; set; }

        public Usuarios(string Usuario, string senha, Grupo grupo)
        {

        }
    }
}
