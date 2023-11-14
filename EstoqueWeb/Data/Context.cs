using EstoqueWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EstoqueWeb.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) 
        {
        
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<CategoriaModel> Categorias { get; set; }

        public DbSet<ProdutoModel> Produtos { get; set; }
    }
}
