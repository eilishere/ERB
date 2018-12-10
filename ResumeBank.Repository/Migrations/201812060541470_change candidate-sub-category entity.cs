namespace ResumeBank.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecandidatesubcategoryentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CandidateSubCategories", "CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.CandidateSubCategories", "SubCategoryId", "dbo.Categories");
            DropIndex("dbo.CandidateSubCategories", new[] { "CandidateId" });
            DropIndex("dbo.CandidateSubCategories", new[] { "SubCategoryId" });
            AddColumn("dbo.Candidates", "Category_Id", c => c.Int());
            CreateIndex("dbo.Candidates", "Category_Id");
            AddForeignKey("dbo.Candidates", "Category_Id", "dbo.Categories", "Id");
            DropTable("dbo.CandidateSubCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CandidateSubCategories",
                c => new
                    {
                        CandidateId = c.Int(nullable: false),
                        SubCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CandidateId, t.SubCategoryId });
            
            DropForeignKey("dbo.Candidates", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Candidates", new[] { "Category_Id" });
            DropColumn("dbo.Candidates", "Category_Id");
            CreateIndex("dbo.CandidateSubCategories", "SubCategoryId");
            CreateIndex("dbo.CandidateSubCategories", "CandidateId");
            AddForeignKey("dbo.CandidateSubCategories", "SubCategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CandidateSubCategories", "CandidateId", "dbo.Candidates", "Id", cascadeDelete: true);
        }
    }
}
