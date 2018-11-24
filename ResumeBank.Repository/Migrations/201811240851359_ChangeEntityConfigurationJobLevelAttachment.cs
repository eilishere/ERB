namespace ResumeBank.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEntityConfigurationJobLevelAttachment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobLevels", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Attachments", "OriginalName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Attachments", "OriginalName", c => c.String());
            AlterColumn("dbo.JobLevels", "Name", c => c.String());
        }
    }
}
