namespace EcommerceOsorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableCategorias : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ItemVenda", new[] { "produtoVenda_ProdutoId" });
            AddColumn("dbo.ItemVenda", "DataVenda", c => c.DateTime(nullable: false));
            CreateIndex("dbo.ItemVenda", "ProdutoVenda_ProdutoId");
            DropColumn("dbo.ItemVenda", "Data");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemVenda", "Data", c => c.DateTime(nullable: false));
            DropIndex("dbo.ItemVenda", new[] { "ProdutoVenda_ProdutoId" });
            DropColumn("dbo.ItemVenda", "DataVenda");
            CreateIndex("dbo.ItemVenda", "produtoVenda_ProdutoId");
        }
    }
}
