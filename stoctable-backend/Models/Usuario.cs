namespace stoctable_backend.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public string Senha { get; set; }
        public Grupo Grupo { get; set; }

        public Usuario(string Usuario, string senha, Grupo grupo)
        {

        }
    }
}
