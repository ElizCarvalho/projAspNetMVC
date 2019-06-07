namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teste0706 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PessoaViewModels", "Captch", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PessoaViewModels", "Captch");
        }
    }
}
