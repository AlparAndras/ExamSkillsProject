namespace ExamSkillProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newemployeecompanyrelationshio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "company_CompanyId", c => c.Int());
            CreateIndex("dbo.Employees", "company_CompanyId");
            AddForeignKey("dbo.Employees", "company_CompanyId", "dbo.Companies", "CompanyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "company_CompanyId", "dbo.Companies");
            DropIndex("dbo.Employees", new[] { "company_CompanyId" });
            DropColumn("dbo.Employees", "company_CompanyId");
        }
    }
}
