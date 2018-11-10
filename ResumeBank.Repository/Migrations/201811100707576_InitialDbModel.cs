namespace ResumeBank.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDbModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 255),
                        Phone = c.String(nullable: false, maxLength: 14),
                        Address = c.String(),
                        DateOfBirth = c.DateTime(),
                        CurrentSalary = c.Double(),
                        ExpectedSalary = c.Double(),
                        Training = c.String(),
                        PrimaryCategoryId = c.Int(nullable: false),
                        EducationLevelId = c.Int(),
                        SubjectId = c.Int(),
                        InstituteId = c.Int(),
                        OriginalResumeId = c.Int(),
                        ModifiedResumeId = c.Int(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EducationLevels", t => t.EducationLevelId)
                .ForeignKey("dbo.Institutes", t => t.InstituteId)
                .ForeignKey("dbo.Attachments", t => t.ModifiedResumeId)
                .ForeignKey("dbo.Categories", t => t.PrimaryCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.PrimaryCategoryId)
                .Index(t => t.EducationLevelId)
                .Index(t => t.SubjectId)
                .Index(t => t.InstituteId)
                .Index(t => t.ModifiedResumeId);
            
            CreateTable(
                "dbo.EducationLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Institutes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        InstituteTypeId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InstituteTypes", t => t.InstituteTypeId, cascadeDelete: true)
                .Index(t => t.InstituteTypeId);
            
            CreateTable(
                "dbo.InstituteTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Caption = c.String(),
                        ImageUrl = c.String(),
                        OriginalName = c.String(),
                        CurrentName = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidates", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        ParentId = c.Int(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CandidateSubCategories",
                c => new
                    {
                        CandidateId = c.Int(nullable: false),
                        SubCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CandidateId, t.SubCategoryId })
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: false)
                .ForeignKey("dbo.Categories", t => t.SubCategoryId, cascadeDelete: false)
                .Index(t => t.CandidateId)
                .Index(t => t.SubCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidates", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.CandidateSubCategories", "SubCategoryId", "dbo.Categories");
            DropForeignKey("dbo.CandidateSubCategories", "CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.Candidates", "PrimaryCategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentId", "dbo.Categories");
            DropForeignKey("dbo.Attachments", "Id", "dbo.Candidates");
            DropForeignKey("dbo.Candidates", "ModifiedResumeId", "dbo.Attachments");
            DropForeignKey("dbo.Candidates", "InstituteId", "dbo.Institutes");
            DropForeignKey("dbo.Institutes", "InstituteTypeId", "dbo.InstituteTypes");
            DropForeignKey("dbo.Candidates", "EducationLevelId", "dbo.EducationLevels");
            DropIndex("dbo.CandidateSubCategories", new[] { "SubCategoryId" });
            DropIndex("dbo.CandidateSubCategories", new[] { "CandidateId" });
            DropIndex("dbo.Categories", new[] { "ParentId" });
            DropIndex("dbo.Attachments", new[] { "Id" });
            DropIndex("dbo.Institutes", new[] { "InstituteTypeId" });
            DropIndex("dbo.Candidates", new[] { "ModifiedResumeId" });
            DropIndex("dbo.Candidates", new[] { "InstituteId" });
            DropIndex("dbo.Candidates", new[] { "SubjectId" });
            DropIndex("dbo.Candidates", new[] { "EducationLevelId" });
            DropIndex("dbo.Candidates", new[] { "PrimaryCategoryId" });
            DropTable("dbo.CandidateSubCategories");
            DropTable("dbo.Subjects");
            DropTable("dbo.Categories");
            DropTable("dbo.Attachments");
            DropTable("dbo.InstituteTypes");
            DropTable("dbo.Institutes");
            DropTable("dbo.EducationLevels");
            DropTable("dbo.Candidates");
        }
    }
}
