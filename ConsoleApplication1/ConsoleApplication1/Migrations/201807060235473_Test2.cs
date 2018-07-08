namespace ConsoleApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.lsFiles", "Path", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.lsFiles", "Path");
        }
    }
}
