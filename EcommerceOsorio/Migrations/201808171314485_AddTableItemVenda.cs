namespace EcommerceOsorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableItemVenda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemVenda",
                c => new
                    {
                        idVenda = c.Int(nullable: false, identity: true),
                        QtdeVenda = c.Int(nullable: false),
                        PrecoVenda = c.Double(nullable: false),
                        Data = c.DateTime(nullable: false),
                        produtoVenda_ProdutoId = c.Int(),
                    })
                .PrimaryKey(t => t.idVenda)
                .ForeignKey("dbo.Produtos", t => t.produtoVenda_ProdutoId)
                .Index(t => t.produtoVenda_ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemVenda", "produtoVenda_ProdutoId", "dbo.Produtos");
            DropIndex("dbo.ItemVenda", new[] { "produtoVenda_ProdutoId" });
            DropTable("dbo.ItemVenda");
        }
    }
}
