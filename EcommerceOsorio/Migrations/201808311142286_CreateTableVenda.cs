namespace EcommerceOsorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableVenda : DbMigration
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
                "dbo.ItemVenda",
                c => new
                    {
                        idVenda = c.Int(nullable: false, identity: true),
                        QtdeVenda = c.Int(nullable: false),
                        PrecoVenda = c.Double(nullable: false),
                        DataVenda = c.DateTime(nullable: false),
                        CarrinhoId = c.String(),
                        ProdutoVenda_ProdutoId = c.Int(),
                        Venda_VendaId = c.Int(),
                    })
                .PrimaryKey(t => t.idVenda)
                .ForeignKey("dbo.Produtos", t => t.ProdutoVenda_ProdutoId)
                .ForeignKey("dbo.Vendas", t => t.Venda_VendaId)
                .Index(t => t.ProdutoVenda_ProdutoId)
                .Index(t => t.Venda_VendaId);
            
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
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        VendaId = c.Int(nullable: false, identity: true),
                        CarrinhoId = c.Int(nullable: false),
                        Nome = c.String(),
                        Telefone = c.String(),
                        Endereco = c.String(),
                    })
                .PrimaryKey(t => t.VendaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemVenda", "Venda_VendaId", "dbo.Vendas");
            DropForeignKey("dbo.ItemVenda", "ProdutoVenda_ProdutoId", "dbo.Produtos");
            DropForeignKey("dbo.Produtos", "CategoriaProduto_CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Produtos", new[] { "CategoriaProduto_CategoriaId" });
            DropIndex("dbo.ItemVenda", new[] { "Venda_VendaId" });
            DropIndex("dbo.ItemVenda", new[] { "ProdutoVenda_ProdutoId" });
            DropTable("dbo.Vendas");
            DropTable("dbo.Produtos");
            DropTable("dbo.ItemVenda");
            DropTable("dbo.Categoria");
        }
    }
}
