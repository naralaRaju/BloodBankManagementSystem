namespace BBMS1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPatientsTodatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        PhoneNo = c.String(),
                        Gender = c.String(),
                        BloodGroup = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patients");
        }
    }
}
