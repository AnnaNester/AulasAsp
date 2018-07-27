using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EcommerceOsorio.Models
{
    public class Context : DbContext
    {
        //Mapear as classes que vão virar tabela no banco
        public Context() : base("DbEcommerce") { }


        public DbSet<Produto> Produtos { get; set; }

    }
}