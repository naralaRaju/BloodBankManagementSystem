namespace BBMS1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBloosStockControllerAndBloodStockModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodStocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BloodType = c.String(),
                        PacketCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BloodStocks");
        }
    }
}
