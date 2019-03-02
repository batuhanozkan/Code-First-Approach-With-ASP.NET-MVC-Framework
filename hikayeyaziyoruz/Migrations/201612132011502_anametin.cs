namespace hikayeyaziyoruz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anametin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.anametins",
                c => new
                    {
                        anametinId = c.Int(nullable: false, identity: true),
                        hikayeAdi = c.String(nullable: false, maxLength: 50),
                        anaMetin = c.String(nullable: false),
                        hikayeTuru = c.String(nullable: false),
                        anaFikir = c.String(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                        Uye_UyeId = c.Int(),
                    })
                .PrimaryKey(t => t.anametinId)
                .ForeignKey("dbo.Uyes", t => t.Uye_UyeId)
                .Index(t => t.Uye_UyeId);
            
            CreateTable(
                "dbo.metins",
                c => new
                    {
                        metinId = c.Int(nullable: false, identity: true),
                        Metin = c.String(nullable: false),
                        Uye_UyeId = c.Int(),
                        anametin_anametinId = c.Int(),
                    })
                .PrimaryKey(t => t.metinId)
                .ForeignKey("dbo.Uyes", t => t.Uye_UyeId)
                .ForeignKey("dbo.anametins", t => t.anametin_anametinId)
                .Index(t => t.Uye_UyeId)
                .Index(t => t.anametin_anametinId);
            
            CreateTable(
                "dbo.Uyes",
                c => new
                    {
                        UyeId = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 50),
                        Soyad = c.String(nullable: false, maxLength: 50),
                        EPosta = c.String(nullable: false),
                        ResimYol = c.String(),
                        dogumTarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UyeId);
            
            CreateTable(
                "dbo.Yorums",
                c => new
                    {
                        YorumId = c.Int(nullable: false, identity: true),
                        Icerik = c.String(nullable: false),
                        anametin_anametinId = c.Int(),
                        Uye_UyeId = c.Int(),
                        metin_metinId = c.Int(),
                    })
                .PrimaryKey(t => t.YorumId)
                .ForeignKey("dbo.anametins", t => t.anametin_anametinId)
                .ForeignKey("dbo.Uyes", t => t.Uye_UyeId)
                .ForeignKey("dbo.metins", t => t.metin_metinId)
                .Index(t => t.anametin_anametinId)
                .Index(t => t.Uye_UyeId)
                .Index(t => t.metin_metinId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.metins", "anametin_anametinId", "dbo.anametins");
            DropForeignKey("dbo.Yorums", "metin_metinId", "dbo.metins");
            DropForeignKey("dbo.Yorums", "Uye_UyeId", "dbo.Uyes");
            DropForeignKey("dbo.Yorums", "anametin_anametinId", "dbo.anametins");
            DropForeignKey("dbo.metins", "Uye_UyeId", "dbo.Uyes");
            DropForeignKey("dbo.anametins", "Uye_UyeId", "dbo.Uyes");
            DropIndex("dbo.Yorums", new[] { "metin_metinId" });
            DropIndex("dbo.Yorums", new[] { "Uye_UyeId" });
            DropIndex("dbo.Yorums", new[] { "anametin_anametinId" });
            DropIndex("dbo.metins", new[] { "anametin_anametinId" });
            DropIndex("dbo.metins", new[] { "Uye_UyeId" });
            DropIndex("dbo.anametins", new[] { "Uye_UyeId" });
            DropTable("dbo.Yorums");
            DropTable("dbo.Uyes");
            DropTable("dbo.metins");
            DropTable("dbo.anametins");
        }
    }
}
