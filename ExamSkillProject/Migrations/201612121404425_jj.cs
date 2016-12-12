namespace ExamSkillProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jj : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "company_CompanyId", "dbo.Companies");
            DropIndex("dbo.Employees", new[] { "company_CompanyId" });
            RenameColumn(table: "dbo.Employees", name: "company_CompanyId", newName: "CompanyId");
            AlterColumn("dbo.Employees", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "CompanyId");
            AddForeignKey("dbo.Employees", "CompanyId", "dbo.Companies", "CompanyId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Employees", new[] { "CompanyId" });
            AlterColumn("dbo.Employees", "CompanyId", c => c.Int());
            RenameColumn(table: "dbo.Employees", name: "CompanyId", newName: "company_CompanyId");
            CreateIndex("dbo.Employees", "company_CompanyId");
            AddForeignKey("dbo.Employees", "company_CompanyId", "dbo.Companies", "CompanyId");
        }
    }
}
