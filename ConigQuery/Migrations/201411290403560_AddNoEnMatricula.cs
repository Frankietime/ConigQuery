namespace ConigQuery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNoEnMatricula : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NoEnMatriculas",
                c => new
                    {
                        NoEnMatriculaId = c.Int(nullable: false, identity: true),
                        Cuil = c.String(),
                        Estado = c.String(),
                        Nombre = c.String(),
                        Curso = c.String(),
                    })
                .PrimaryKey(t => t.NoEnMatriculaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NoEnMatriculas");
        }
    }
}
