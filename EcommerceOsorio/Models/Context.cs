using System.Data.Entity;

namespace EcommerceOsorio.Models
{
    public class Context : DbContext
    {
        //Mapear as classes que vão virar tabela no banco
        public Context() : base("DbEcommerce") { }


        public DbSet<Produto> Produtos { get; set; }

    }
}