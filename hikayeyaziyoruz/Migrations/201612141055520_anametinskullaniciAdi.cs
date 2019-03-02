namespace hikayeyaziyoruz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anametinskullaniciAdi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uyes", "kullaniciAdi", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Uyes", "kullaniciAdi");
        }
    }
}
