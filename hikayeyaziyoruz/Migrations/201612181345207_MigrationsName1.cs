namespace hikayeyaziyoruz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Yorums", "metin_metinId", "dbo.metins");
            DropIndex("dbo.Yorums", new[] { "metin_metinId" });
            DropColumn("dbo.Yorums", "metin_metinId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Yorums", "metin_metinId", c => c.Int());
            CreateIndex("dbo.Yorums", "metin_metinId");
            AddForeignKey("dbo.Yorums", "metin_metinId", "dbo.metins", "metinId");
        }
    }
}
