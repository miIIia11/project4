using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project4.Models
{
    public class NhaTu : DbContext
    {
        public NhaTu() : base("name=NhaTu")
        {
        }

        public virtual DbSet<AnXa> AnXa { get; set; }
        public virtual DbSet<Benh> Benh { get; set; }
        public virtual DbSet<CheDoNghiPhepCuaQuanNguc> CheDoNghiPhepCuaQuanNguc { get; set; }
        public virtual DbSet<Khu> Khu { get; set; }
        public virtual DbSet<LaoDongCongIch> LaoDongCongIch { get; set; }
        public virtual DbSet<PhamNhan> PhamNhan { get; set; }
        public virtual DbSet<PhongGiam> PhongGiam { get; set; }
        public virtual DbSet<QuanLyBenhTat> QuanLyBenhTat { get; set; }
        public virtual DbSet<QuanNguc> QuanNguc { get; set; }
        public virtual DbSet<ThamGui> ThamGui { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }


    }
}