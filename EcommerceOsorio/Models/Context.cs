using System.Data.Entity;

namespace EcommerceOsorio.Models
{
    public class Context : DbContext
    {
        //Mapear as classes que vão virar tabela no banco
        public Context() : base("DbEcommerce") { }


        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<ItemVenda> ItensVenda { get; set; }
        
        public DbSet<Venda> Vendas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}