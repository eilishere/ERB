namespace ResumeBank.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeattachmentcandidate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attachments", "Id", "dbo.Candidates");
            DropForeignKey("dbo.Candidates", "ModifiedResumeId", "dbo.Attachments");
            DropIndex("dbo.Attachments", new[] { "Id" });
            DropPrimaryKey("dbo.Attachments");
            AddColumn("dbo.Attachments", "Url", c => c.String());
            AlterColumn("dbo.Attachments", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Attachments", "Id");
            CreateIndex("dbo.Candidates", "OriginalResumeId");
            AddForeignKey("dbo.Candidates", "OriginalResumeId", "dbo.Attachments", "Id");
            AddForeignKey("dbo.Candidates", "ModifiedResumeId", "dbo.Attachments", "Id");
            DropColumn("dbo.Attachments", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attachments", "ImageUrl", c => c.String());
            DropForeignKey("dbo.Candidates", "ModifiedResumeId", "dbo.Attachments");
            DropForeignKey("dbo.Candidates", "OriginalResumeId", "dbo.Attachments");
            DropIndex("dbo.Candidates", new[] { "OriginalResumeId" });
            DropPrimaryKey("dbo.Attachments");
            AlterColumn("dbo.Attachments", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Attachments", "Url");
            AddPrimaryKey("dbo.Attachments", "Id");
            CreateIndex("dbo.Attachments", "Id");
            AddForeignKey("dbo.Candidates", "ModifiedResumeId", "dbo.Attachments", "Id");
            AddForeignKey("dbo.Attachments", "Id", "dbo.Candidates", "Id");
        }
    }
}
