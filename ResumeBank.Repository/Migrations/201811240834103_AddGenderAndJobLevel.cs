namespace ResumeBank.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenderAndJobLevel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Candidates", "GenderId", c => c.Int(nullable: false));
            AddColumn("dbo.Candidates", "JobLevelId", c => c.Int());
            CreateIndex("dbo.Candidates", "GenderId");
            CreateIndex("dbo.Candidates", "JobLevelId");
            AddForeignKey("dbo.Candidates", "GenderId", "dbo.Genders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Candidates", "JobLevelId", "dbo.JobLevels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidates", "JobLevelId", "dbo.JobLevels");
            DropForeignKey("dbo.Candidates", "GenderId", "dbo.Genders");
            DropIndex("dbo.Candidates", new[] { "JobLevelId" });
            DropIndex("dbo.Candidates", new[] { "GenderId" });
            DropColumn("dbo.Candidates", "JobLevelId");
            DropColumn("dbo.Candidates", "GenderId");
            DropTable("dbo.JobLevels");
            DropTable("dbo.Genders");
        }
    }
}
