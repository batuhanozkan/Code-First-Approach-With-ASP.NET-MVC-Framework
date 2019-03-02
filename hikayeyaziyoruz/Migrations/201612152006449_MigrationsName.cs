namespace hikayeyaziyoruz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Uyes", "ResimYol");
            DropColumn("dbo.Uyes", "dogumTarih");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Uyes", "dogumTarih", c => c.DateTime(nullable: false));
            AddColumn("dbo.Uyes", "ResimYol", c => c.String());
        }
    }
}
