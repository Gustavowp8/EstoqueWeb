using System.ComponentModel.DataAnnotations;

namespace EstoqueWeb.Models
{
    public class CategoriaModel
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "Nome da categoria e obrigatorio"), MaxLength(50)]
        public string Nome { get; set; }
    }
}
