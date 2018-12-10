namespace ResumeBank.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCategoryCandidatesProperty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Candidates", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Candidates", new[] { "Category_Id" });
            DropColumn("dbo.Candidates", "Category_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidates", "Category_Id", c => c.Int());
            CreateIndex("dbo.Candidates", "Category_Id");
            AddForeignKey("dbo.Candidates", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
