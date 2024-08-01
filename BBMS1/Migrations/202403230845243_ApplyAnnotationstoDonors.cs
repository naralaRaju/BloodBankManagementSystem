namespace BBMS1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationstoDonors : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donors", "Name", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Donors", "BloodGroup", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donors", "BloodGroup", c => c.String());
            AlterColumn("dbo.Donors", "Name", c => c.String());
        }
    }
}
