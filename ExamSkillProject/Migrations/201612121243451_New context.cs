namespace ExamSkillProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newcontext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Address = c.String(),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Passwrod = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillsId = c.Int(nullable: false, identity: true),
                        SkillsName = c.String(),
                        SkillsPoints = c.Int(nullable: false),
                        SkillsDescription = c.String(),
                    })
                .PrimaryKey(t => t.SkillsId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Skills");
            DropTable("dbo.Employees");
            DropTable("dbo.Companies");
        }
    }
}
