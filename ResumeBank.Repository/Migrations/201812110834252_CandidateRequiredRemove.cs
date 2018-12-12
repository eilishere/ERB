namespace ResumeBank.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CandidateRequiredRemove : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Candidates", "EducationLevelId", "dbo.EducationLevels");
            DropForeignKey("dbo.Candidates", "InstituteId", "dbo.Institutes");
            DropForeignKey("dbo.Candidates", "JobLevelId", "dbo.JobLevels");
            DropForeignKey("dbo.Candidates", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Candidates", new[] { "EducationLevelId" });
            DropIndex("dbo.Candidates", new[] { "SubjectId" });
            DropIndex("dbo.Candidates", new[] { "InstituteId" });
            DropIndex("dbo.Candidates", new[] { "JobLevelId" });
            AlterColumn("dbo.Candidates", "EducationLevelId", c => c.Int());
            AlterColumn("dbo.Candidates", "SubjectId", c => c.Int());
            AlterColumn("dbo.Candidates", "InstituteId", c => c.Int());
            AlterColumn("dbo.Candidates", "JobLevelId", c => c.Int());
            CreateIndex("dbo.Candidates", "EducationLevelId");
            CreateIndex("dbo.Candidates", "SubjectId");
            CreateIndex("dbo.Candidates", "InstituteId");
            CreateIndex("dbo.Candidates", "JobLevelId");
            AddForeignKey("dbo.Candidates", "EducationLevelId", "dbo.EducationLevels", "Id");
            AddForeignKey("dbo.Candidates", "InstituteId", "dbo.Institutes", "Id");
            AddForeignKey("dbo.Candidates", "JobLevelId", "dbo.JobLevels", "Id");
            AddForeignKey("dbo.Candidates", "SubjectId", "dbo.Subjects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidates", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Candidates", "JobLevelId", "dbo.JobLevels");
            DropForeignKey("dbo.Candidates", "InstituteId", "dbo.Institutes");
            DropForeignKey("dbo.Candidates", "EducationLevelId", "dbo.EducationLevels");
            DropIndex("dbo.Candidates", new[] { "JobLevelId" });
            DropIndex("dbo.Candidates", new[] { "InstituteId" });
            DropIndex("dbo.Candidates", new[] { "SubjectId" });
            DropIndex("dbo.Candidates", new[] { "EducationLevelId" });
            AlterColumn("dbo.Candidates", "JobLevelId", c => c.Int(nullable: false));
            AlterColumn("dbo.Candidates", "InstituteId", c => c.Int(nullable: false));
            AlterColumn("dbo.Candidates", "SubjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Candidates", "EducationLevelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Candidates", "JobLevelId");
            CreateIndex("dbo.Candidates", "InstituteId");
            CreateIndex("dbo.Candidates", "SubjectId");
            CreateIndex("dbo.Candidates", "EducationLevelId");
            AddForeignKey("dbo.Candidates", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Candidates", "JobLevelId", "dbo.JobLevels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Candidates", "InstituteId", "dbo.Institutes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Candidates", "EducationLevelId", "dbo.EducationLevels", "Id", cascadeDelete: true);
        }
    }
}
