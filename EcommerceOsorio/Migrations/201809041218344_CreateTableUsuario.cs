namespace EcommerceOsorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            AlterColumn("dbo.Vendas", "CarrinhoId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendas", "CarrinhoId", c => c.Int(nullable: false));
            DropTable("dbo.Usuarios");
        }
    }
}
