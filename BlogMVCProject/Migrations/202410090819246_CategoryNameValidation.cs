namespace BlogMVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryNameValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Articles", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Articles", "Content", c => c.String());
            AlterColumn("dbo.Articles", "Title", c => c.String());
        }
    }
}
