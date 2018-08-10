namespace EcommerceOsorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriaTableProduto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        NomeCategoria = c.String(nullable: false),
                        DescricaoCategoria = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        NomeProduto = c.String(nullable: false, maxLength: 50),
                        DescricaoProduto = c.String(),
                        PrecoProduto = c.Double(nullable: false),
                        ImagemProduto = c.String(),
                        CategoriaProduto_CategoriaId = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Categoria", t => t.CategoriaProduto_CategoriaId)
                .Index(t => t.CategoriaProduto_CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "CategoriaProduto_CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Produtos", new[] { "CategoriaProduto_CategoriaId" });
            DropTable("dbo.Produtos");
            DropTable("dbo.Categoria");
        }
    }
}
