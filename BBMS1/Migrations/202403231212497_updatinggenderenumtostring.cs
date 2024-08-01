namespace BBMS1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatinggenderenumtostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Gender", c => c.Int(nullable: false));
        }
    }
}
