namespace ExamSkillProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLogointoIconinCompanytable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Icon", c => c.String());
            DropColumn("dbo.Companies", "Logo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "Logo", c => c.String());
            DropColumn("dbo.Companies", "Icon");
        }
    }
}
