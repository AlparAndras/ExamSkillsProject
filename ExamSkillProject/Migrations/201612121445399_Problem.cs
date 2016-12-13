namespace ExamSkillProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Problem : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Skills");
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        SkillIcon = c.String(),
                        SkillName = c.String(),
                        SkillPoints = c.Int(nullable: false),
                        SkillDescription = c.String(),
                    })
                .PrimaryKey(t => t.SkillId);
            
           
        }
        
        public override void Down()
        {
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
            
            DropTable("dbo.Skills");
        }
    }
}
