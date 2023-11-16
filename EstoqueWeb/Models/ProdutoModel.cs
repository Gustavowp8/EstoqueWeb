using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstoqueWeb.Models
{
    public class ProdutoModel
    {
        [Key]
        public int IdProduto { get; set; }

        [Required, MaxLength(20)]
        public string Nome { get; set; }

        [Required, MaxLength(150)]
        public string Descricao { get; set; }

        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        //Tabela relacionada
        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }

        public CategoriaModel Categoria { get; set; }  
    }
}
