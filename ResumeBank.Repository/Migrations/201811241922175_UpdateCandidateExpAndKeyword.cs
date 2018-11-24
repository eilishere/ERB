namespace ResumeBank.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCandidateExpAndKeyword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidates", "TotalExperience", c => c.Double());
            AddColumn("dbo.Candidates", "Keywords", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidates", "Keywords");
            DropColumn("dbo.Candidates", "TotalExperience");
        }
    }
}
