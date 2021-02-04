namespace Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDesignation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designation",
                c => new
                    {
                        DesigID = c.Int(nullable: false, identity: true),
                        DesigCode = c.String(),
                        DesigName = c.String(),
                        DesigLocalName = c.String(),
                        DesigDesc = c.String(),
                    })
                .PrimaryKey(t => t.DesigID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Designation");
        }
    }
}
