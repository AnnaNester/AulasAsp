namespace EcommerceOsorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        idProduto = c.Int(nullable: false, identity: true),
                        NomeProduto = c.String(),
                        DescricaoProduto = c.String(),
                        PrecoProduto = c.Double(nullable: false),
                        CategoriaProduto = c.String(),
                        ImagemProduto = c.String(),
                    })
                .PrimaryKey(t => t.idProduto);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produtos");
        }
    }
}
