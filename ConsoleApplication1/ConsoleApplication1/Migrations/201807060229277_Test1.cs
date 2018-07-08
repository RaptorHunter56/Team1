namespace ConsoleApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.lsClasses",
                c => new
                    {
                        lsClassId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        lsNameSpaceID_lsNameSpaceId = c.Int(),
                    })
                .PrimaryKey(t => t.lsClassId)
                .ForeignKey("dbo.lsNameSpaces", t => t.lsNameSpaceID_lsNameSpaceId)
                .Index(t => t.lsNameSpaceID_lsNameSpaceId);
            
            CreateTable(
                "dbo.lsMethods",
                c => new
                    {
                        lsMethodId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        lsClassID_lsClassId = c.Int(),
                    })
                .PrimaryKey(t => t.lsMethodId)
                .ForeignKey("dbo.lsClasses", t => t.lsClassID_lsClassId)
                .Index(t => t.lsClassID_lsClassId);
            
            CreateTable(
                "dbo.lsNameSpaces",
                c => new
                    {
                        lsNameSpaceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        lsFileID_lsFileId = c.Int(),
                    })
                .PrimaryKey(t => t.lsNameSpaceId)
                .ForeignKey("dbo.lsFiles", t => t.lsFileID_lsFileId)
                .Index(t => t.lsFileID_lsFileId);
            
            CreateTable(
                "dbo.lsFiles",
                c => new
                    {
                        lsFileId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.lsFileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.lsNameSpaces", "lsFileID_lsFileId", "dbo.lsFiles");
            DropForeignKey("dbo.lsClasses", "lsNameSpaceID_lsNameSpaceId", "dbo.lsNameSpaces");
            DropForeignKey("dbo.lsMethods", "lsClassID_lsClassId", "dbo.lsClasses");
            DropIndex("dbo.lsNameSpaces", new[] { "lsFileID_lsFileId" });
            DropIndex("dbo.lsMethods", new[] { "lsClassID_lsClassId" });
            DropIndex("dbo.lsClasses", new[] { "lsNameSpaceID_lsNameSpaceId" });
            DropTable("dbo.lsFiles");
            DropTable("dbo.lsNameSpaces");
            DropTable("dbo.lsMethods");
            DropTable("dbo.lsClasses");
        }
    }
}
