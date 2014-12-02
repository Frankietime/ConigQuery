namespace ConigQuery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteRegular : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Regulars");
        }
        
        public override void Down()
        {
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
    }
}
