namespace FIT5032_MonashHotels_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateOfBirthField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "dateOfBirth", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "dateOfBirth");
        }
    }
}
