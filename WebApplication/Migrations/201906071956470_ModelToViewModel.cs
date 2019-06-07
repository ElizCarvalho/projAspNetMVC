namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelToViewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PessoaViewModels",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Cpf = c.String(nullable: false, maxLength: 11),
                        Nome = c.String(nullable: false, maxLength: 20),
                        Sobrenome = c.String(maxLength: 20),
                        DataNascimento = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        Telefone = c.String(),
                        NomeMae = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Codigo);
            
            AlterColumn("dbo.Pessoas", "Cpf", c => c.String());
            AlterColumn("dbo.Pessoas", "Nome", c => c.String());
            AlterColumn("dbo.Pessoas", "Sobrenome", c => c.String());
            AlterColumn("dbo.Pessoas", "Email", c => c.String());
            AlterColumn("dbo.Pessoas", "NomeMae", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pessoas", "NomeMae", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Pessoas", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Pessoas", "Sobrenome", c => c.String(maxLength: 20));
            AlterColumn("dbo.Pessoas", "Nome", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Pessoas", "Cpf", c => c.String(nullable: false, maxLength: 11));
            DropTable("dbo.PessoaViewModels");
        }
    }
}
