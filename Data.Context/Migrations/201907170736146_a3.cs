namespace Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdjReason",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustAdjExt",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdjNo = c.String(),
                        CustId = c.Int(nullable: false),
                        InvoiceNo = c.String(),
                        AdjReason = c.Int(nullable: false),
                        AdjAmt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AdjType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustAdjustment",
                c => new
                    {
                        CustAdjId = c.Int(nullable: false, identity: true),
                        AdjNo = c.String(),
                        AdjDate = c.DateTime(),
                        CustId = c.Int(nullable: false),
                        AdjAmt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AdjReason = c.Int(nullable: false),
                        ProjCode = c.String(),
                        BranchCode = c.String(),
                        RefNo = c.String(),
                        RefDate = c.DateTime(),
                        DrCr = c.String(),
                        ApprBy = c.String(),
                        ApprDate = c.DateTime(),
                        Posted = c.Boolean(nullable: false),
                        VchrNo = c.String(),
                        FinYear = c.String(),
                        EntryDateTime = c.DateTime(),
                        VATType = c.String(),
                    })
                .PrimaryKey(t => t.CustAdjId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustAdjustment");
            DropTable("dbo.CustAdjExt");
            DropTable("dbo.AdjReason");
        }
    }
}
