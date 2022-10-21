using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hangfire.Common;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        public Context(): base(@"data source=.; initial catalog=GoPOS; integrated security=true;")
        {

        }
        public DbSet<Birim> Birims { get; set; }
        public DbSet<Gorevler> Jobs { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Kullanicilar> Kullanicilars { get; set; }
        public DbSet<Masalar> Masalars { get; set; }
        public DbSet<Odemeler> Odemelers { get; set; }
        public DbSet<Receteler> Recetelers { get; set; }
        public DbSet<Siparisler> Siparislers { get; set; }
        public DbSet<SiparisLog> SiparisLogs { get; set; }
        public DbSet<SonSiparis> SonSipariss { get; set; }
        public DbSet<StokHareketleri> StokHareketleris { get; set; }
        public DbSet<Stoklar> Stoklars { get; set; }
        public DbSet<Urunler> Urunlers { get; set; }
       
    }
}
