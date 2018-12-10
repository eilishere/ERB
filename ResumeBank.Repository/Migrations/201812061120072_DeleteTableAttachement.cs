namespace ResumeBank.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTableAttachement : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Candidates", "ModifiedResumeId", "dbo.Attachments");
            DropForeignKey("dbo.Candidates", "OriginalResumeId", "dbo.Attachments");
            DropIndex("dbo.Candidates", new[] { "OriginalResumeId" });
            DropIndex("dbo.Candidates", new[] { "ModifiedResumeId" });
            DropTable("dbo.Attachments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                        Url = c.String(),
                        OriginalName = c.String(nullable: false, maxLength: 255),
                        CurrentName = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Candidates", "ModifiedResumeId");
            CreateIndex("dbo.Candidates", "OriginalResumeId");
            AddForeignKey("dbo.Candidates", "OriginalResumeId", "dbo.Attachments", "Id");
            AddForeignKey("dbo.Candidates", "ModifiedResumeId", "dbo.Attachments", "Id");
        }
    }
}
