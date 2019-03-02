namespace hikayeyaziyoruz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Uyesifre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uyes", "sifre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Uyes", "sifre");
        }
    }
}
