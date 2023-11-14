using System.ComponentModel.DataAnnotations;

namespace EstoqueWeb.Models
{
    public class UsuarioModel
    { 
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Nome e obrigatorio"), MaxLength(20)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Nome para login e obrigatorio"), MaxLength(11)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Criar uma senha e obrigatorio"), MaxLength(10)]
        public string Senha { get; set; }
    }
}
