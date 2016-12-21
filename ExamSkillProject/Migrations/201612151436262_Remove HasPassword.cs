namespace ExamSkillProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveHasPassword : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "HasPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "HasPassword", c => c.Boolean(nullable: false));
        }
    }
}
