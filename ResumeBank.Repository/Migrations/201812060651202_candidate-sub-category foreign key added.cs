namespace ResumeBank.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class candidatesubcategoryforeignkeyadded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CandidateSubCategories", "CandidateId", "dbo.Candidates");
            AddForeignKey("dbo.CandidateSubCategories", "CandidateId", "dbo.Candidates", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CandidateSubCategories", "CandidateId", "dbo.Candidates");
            AddForeignKey("dbo.CandidateSubCategories", "CandidateId", "dbo.Candidates", "Id", cascadeDelete: true);
        }
    }
}
