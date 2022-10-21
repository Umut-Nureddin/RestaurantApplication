namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GoPOS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Birims",
                c => new
                    {
                        BirimID = c.Int(nullable: false, identity: true),
                        BirimCins = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.BirimID);
            
            CreateTable(
                "dbo.Gorevlers",
                c => new
                    {
                        JobID = c.Int(nullable: false, identity: true),
                        JobType = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.JobID);
            
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        KategoriID = c.Int(nullable: false, identity: true),
                        KategoriAD = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.KategoriID);
            
            CreateTable(
                "dbo.Kullanicilars",
                c => new
                    {
                        KullaniciID = c.Int(nullable: false, identity: true),
                        KullaniciAdSoyad = c.String(maxLength: 60),
                        Telefon = c.String(maxLength: 20),
                        Email = c.String(maxLength: 40),
                        Yetki = c.Boolean(nullable: false),
                        GorevAd = c.String(maxLength: 50),
                        KullaniciPassword = c.String(maxLength: 30),
                        KullaniciPin = c.Int(nullable: false),
                        KullaniciDurum = c.Boolean(),
                        Aciklama = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.KullaniciID);
            
            CreateTable(
                "dbo.Siparislers",
                c => new
                    {
                        SipID = c.Int(nullable: false, identity: true),
                        MasaAD = c.String(maxLength: 50),
                        UrunAd = c.String(maxLength: 100),
                        UrunFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UrunAdet = c.Int(nullable: false),
                        SipDurum = c.Boolean(nullable: false),
                        SatirTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SiparisTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tarih = c.DateTime(),
                        KDVTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AraTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SipNo = c.Int(nullable: false),
                        OdemeBicimi = c.String(maxLength: 30),
                        TarihKasa = c.DateTime(storeType: "date"),
                        UrunID = c.Int(nullable: false),
                        MasaID = c.Int(nullable: false),
                        KullaniciID = c.Int(),
                    })
                .PrimaryKey(t => t.SipID)
                .ForeignKey("dbo.Kullanicilars", t => t.KullaniciID)
                .ForeignKey("dbo.Masalars", t => t.MasaID, cascadeDelete: true)
                .ForeignKey("dbo.Urunlers", t => t.UrunID, cascadeDelete: true)
                .Index(t => t.UrunID)
                .Index(t => t.MasaID)
                .Index(t => t.KullaniciID);
            
            CreateTable(
                "dbo.Masalars",
                c => new
                    {
                        MasaID = c.Int(nullable: false, identity: true),
                        MasaAd = c.String(maxLength: 50),
                        MasaDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MasaID);
            
            CreateTable(
                "dbo.Urunlers",
                c => new
                    {
                        UrunID = c.Int(nullable: false, identity: true),
                        UrunAD = c.String(maxLength: 100),
                        UrunKategoriID = c.Int(nullable: false),
                        UrunFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UrunResmi = c.String(maxLength: 200),
                        StokDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UrunID);
            
            CreateTable(
                "dbo.Recetelers",
                c => new
                    {
                        ReceteID = c.Int(nullable: false, identity: true),
                        StokUrun = c.String(maxLength: 50),
                        Birim = c.String(maxLength: 50),
                        Miktar = c.Int(nullable: false),
                        ReceteNo = c.Int(nullable: false),
                        UrunID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReceteID)
                .ForeignKey("dbo.Urunlers", t => t.UrunID, cascadeDelete: true)
                .Index(t => t.UrunID);
            
            CreateTable(
                "dbo.Stoklars",
                c => new
                    {
                        StokID = c.Int(nullable: false, identity: true),
                        UrunAd = c.String(maxLength: 100),
                        Birim = c.String(maxLength: 30),
                        StokMiktari = c.Int(nullable: false),
                        KritikStokMiktari = c.Int(nullable: false),
                        UrunID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StokID)
                .ForeignKey("dbo.Urunlers", t => t.UrunID, cascadeDelete: true)
                .Index(t => t.UrunID);
            
            CreateTable(
                "dbo.Odemelers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SipNo = c.Int(nullable: false),
                        Nakit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        KrediKarti = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sodexo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Multinet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SipTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        KalanTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OdemeDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SiparisLogs",
                c => new
                    {
                        SipID = c.Int(nullable: false, identity: true),
                        MasaAD = c.String(maxLength: 50),
                        Tarih = c.DateTime(nullable: false),
                        SiparisTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        KDVTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AraTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MasaID = c.Int(nullable: false),
                        SipDurum = c.Boolean(nullable: false),
                        KullaniciID = c.Int(),
                        SipNo = c.Int(nullable: false),
                        UrunAd = c.String(maxLength: 100),
                        UrunFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UrunAdet = c.Int(nullable: false),
                        EskiUrunAdet = c.Int(),
                        EskiKullaniciID = c.Int(),
                        EskiMasaAD = c.String(maxLength: 50),
                        EskiUrunAd = c.String(maxLength: 100),
                        EskiSipDurum = c.Boolean(),
                        EskiSiparisTutar = c.Decimal(precision: 18, scale: 2),
                        TransactionID = c.Int(),
                    })
                .PrimaryKey(t => t.SipID);
            
            CreateTable(
                "dbo.SonSiparis",
                c => new
                    {
                        SipNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SipNo);
            
            CreateTable(
                "dbo.StokHareketleris",
                c => new
                    {
                        HareketID = c.Int(nullable: false, identity: true),
                        UrunID = c.Int(nullable: false),
                        UrunAD = c.String(maxLength: 100),
                        EklenenMiktar = c.Int(),
                        CikanMiktar = c.Int(),
                        KayitNotu = c.String(maxLength: 500),
                        Zaman = c.DateTime(nullable: false),
                        ToplamTutar = c.Decimal(precision: 18, scale: 2),
                        BirimFiyat = c.Decimal(precision: 18, scale: 2),
                        ZamanB = c.DateTime(storeType: "date"),
                        CikanTutar = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.HareketID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stoklars", "UrunID", "dbo.Urunlers");
            DropForeignKey("dbo.Siparislers", "UrunID", "dbo.Urunlers");
            DropForeignKey("dbo.Recetelers", "UrunID", "dbo.Urunlers");
            DropForeignKey("dbo.Siparislers", "MasaID", "dbo.Masalars");
            DropForeignKey("dbo.Siparislers", "KullaniciID", "dbo.Kullanicilars");
            DropIndex("dbo.Stoklars", new[] { "UrunID" });
            DropIndex("dbo.Recetelers", new[] { "UrunID" });
            DropIndex("dbo.Siparislers", new[] { "KullaniciID" });
            DropIndex("dbo.Siparislers", new[] { "MasaID" });
            DropIndex("dbo.Siparislers", new[] { "UrunID" });
            DropTable("dbo.StokHareketleris");
            DropTable("dbo.SonSiparis");
            DropTable("dbo.SiparisLogs");
            DropTable("dbo.Odemelers");
            DropTable("dbo.Stoklars");
            DropTable("dbo.Recetelers");
            DropTable("dbo.Urunlers");
            DropTable("dbo.Masalars");
            DropTable("dbo.Siparislers");
            DropTable("dbo.Kullanicilars");
            DropTable("dbo.Kategoris");
            DropTable("dbo.Gorevlers");
            DropTable("dbo.Birims");
        }
    }
}
