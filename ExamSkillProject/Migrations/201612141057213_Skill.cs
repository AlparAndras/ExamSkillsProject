namespace ExamSkillProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Skill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "CompanyId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skills", "CompanyId");
        }
    }
}
