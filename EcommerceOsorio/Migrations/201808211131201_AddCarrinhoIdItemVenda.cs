namespace EcommerceOsorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarrinhoIdItemVenda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemVenda", "CarrinhoId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ItemVenda", "CarrinhoId");
        }
    }
}
