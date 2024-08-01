namespace BBMS1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePatientGender : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "Gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Gender", c => c.String(nullable:true));
        }
    }
}
