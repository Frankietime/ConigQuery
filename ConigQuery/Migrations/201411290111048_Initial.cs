namespace ConigQuery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Irregulars",
                c => new
                    {
                        IrregularId = c.Int(nullable: false, identity: true),
                        Cuil = c.String(),
                        Estado = c.String(),
                        Nombre = c.String(),
                        Curso = c.String(),
                    })
                .PrimaryKey(t => t.IrregularId);
            
            CreateTable(
                "dbo.Regulars",
                c => new
                    {
                        RegularId = c.Int(nullable: false, identity: true),
                        Cuil = c.String(),
                        Nombre = c.String(),
                        Curso = c.String(),
                    })
                .PrimaryKey(t => t.RegularId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Regulars");
            DropTable("dbo.Irregulars");
        }
    }
}
