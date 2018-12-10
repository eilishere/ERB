namespace ResumeBank.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCandidateAttachmentForeignKey : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attachments", "Url", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Attachments", "OriginalName", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Candidates", "OriginalResumeId");
            CreateIndex("dbo.Candidates", "ModifiedResumeId");
            AddForeignKey("dbo.Candidates", "ModifiedResumeId", "dbo.Attachments", "Id");
            AddForeignKey("dbo.Candidates", "OriginalResumeId", "dbo.Attachments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidates", "OriginalResumeId", "dbo.Attachments");
            DropForeignKey("dbo.Candidates", "ModifiedResumeId", "dbo.Attachments");
            DropIndex("dbo.Candidates", new[] { "ModifiedResumeId" });
            DropIndex("dbo.Candidates", new[] { "OriginalResumeId" });
            AlterColumn("dbo.Attachments", "OriginalName", c => c.String());
            AlterColumn("dbo.Attachments", "Url", c => c.String());
        }
    }
}
