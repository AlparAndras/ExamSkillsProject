namespace ExamSkillProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHasPasswordpropertytoUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "HasPassword", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "HasPassword");
        }
    }
}
