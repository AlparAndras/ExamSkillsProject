namespace ExamSkillProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skillcompanyId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Skills", "CompanyId");
            AddForeignKey("dbo.Skills", "CompanyId", "dbo.Companies", "CompanyId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Skills", new[] { "CompanyId" });
            DropColumn("dbo.Skills", "CompanyId");
        }
    }
}
