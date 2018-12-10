namespace ResumeBank.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcandidatesubcategoryentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CandidateSubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CandidateId = c.Int(nullable: false),
                        SubCategoryId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.SubCategoryId, cascadeDelete: false)
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: false)
                .Index(t => t.CandidateId)
                .Index(t => t.SubCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CandidateSubCategories", "CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.CandidateSubCategories", "SubCategoryId", "dbo.Categories");
            DropIndex("dbo.CandidateSubCategories", new[] { "SubCategoryId" });
            DropIndex("dbo.CandidateSubCategories", new[] { "CandidateId" });
            DropTable("dbo.CandidateSubCategories");
        }
    }
}
