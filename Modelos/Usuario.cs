using System.ComponentModel.DataAnnotations;

namespace Universidad2.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public bool genero { get; set; }
        public int edad { get; set; }
    }
}
