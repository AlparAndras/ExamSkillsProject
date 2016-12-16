namespace ExamSkillProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Userstartdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "StartDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "StartDate");
        }
    }
}
