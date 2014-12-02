namespace ConigQuery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNoEnConig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NoEnConigs",
                c => new
                    {
                        NoEnConigId = c.Int(nullable: false, identity: true),
                        Cuil = c.String(),
                        Estado = c.String(),
                        Nombre = c.String(),
                        Curso = c.String(),
                    })
                .PrimaryKey(t => t.NoEnConigId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NoEnConigs");
        }
    }
}
