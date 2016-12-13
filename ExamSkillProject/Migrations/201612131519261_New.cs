namespace ExamSkillProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Companies");
            DropIndex("dbo.AspNetUsers", new[] { "CompanyId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.AspNetUsers", "CompanyId");
            AddForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Companies", "CompanyId", cascadeDelete: true);
        }
    }
}
