namespace Project4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suaLaiFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhongGiams", "BanGiaoCongViecCuaQuanNgucNghi_ID", "dbo.BanGiaoCongViecCuaQuanNgucNghis");
            DropForeignKey("dbo.PhongGiams", "BanGiaoPhamNhan_ID", "dbo.BanGiaoPhamNhans");
            DropIndex("dbo.PhongGiams", new[] { "BanGiaoCongViecCuaQuanNgucNghi_ID" });
            DropIndex("dbo.PhongGiams", new[] { "BanGiaoPhamNhan_ID" });
            DropColumn("dbo.PhongGiams", "BanGiaoCongViecCuaQuanNgucNghi_ID");
            DropColumn("dbo.PhongGiams", "BanGiaoPhamNhan_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhongGiams", "BanGiaoPhamNhan_ID", c => c.Int());
            AddColumn("dbo.PhongGiams", "BanGiaoCongViecCuaQuanNgucNghi_ID", c => c.Int());
            CreateIndex("dbo.PhongGiams", "BanGiaoPhamNhan_ID");
            CreateIndex("dbo.PhongGiams", "BanGiaoCongViecCuaQuanNgucNghi_ID");
            AddForeignKey("dbo.PhongGiams", "BanGiaoPhamNhan_ID", "dbo.BanGiaoPhamNhans", "ID");
            AddForeignKey("dbo.PhongGiams", "BanGiaoCongViecCuaQuanNgucNghi_ID", "dbo.BanGiaoCongViecCuaQuanNgucNghis", "ID");
        }
    }
}
