namespace ExamSkillProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assignmentId : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        AssignmentId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        SkillId = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.AssignmentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Assignments");
        }
    }
}
