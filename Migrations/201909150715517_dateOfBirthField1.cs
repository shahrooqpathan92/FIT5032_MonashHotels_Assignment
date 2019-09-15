namespace FIT5032_MonashHotels_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateOfBirthField1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "dateOfBirth", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "dateOfBirth", c => c.String());
        }
    }
}
