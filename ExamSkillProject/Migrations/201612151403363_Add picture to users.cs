namespace ExamSkillProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addpicturetousers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Picture");
        }
    }
}
