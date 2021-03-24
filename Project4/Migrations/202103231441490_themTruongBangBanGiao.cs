namespace Project4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themTruongBangBanGiao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhongGiams", "BanGiaoCongViecCuaQuanNgucNghi_ID", c => c.Int());
            AddColumn("dbo.PhongGiams", "BanGiaoPhamNhan_ID", c => c.Int());
            CreateIndex("dbo.PhongGiams", "BanGiaoCongViecCuaQuanNgucNghi_ID");
            CreateIndex("dbo.PhongGiams", "BanGiaoPhamNhan_ID");
            AddForeignKey("dbo.PhongGiams", "BanGiaoCongViecCuaQuanNgucNghi_ID", "dbo.BanGiaoCongViecCuaQuanNgucNghis", "ID");
            AddForeignKey("dbo.PhongGiams", "BanGiaoPhamNhan_ID", "dbo.BanGiaoPhamNhans", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhongGiams", "BanGiaoPhamNhan_ID", "dbo.BanGiaoPhamNhans");
            DropForeignKey("dbo.PhongGiams", "BanGiaoCongViecCuaQuanNgucNghi_ID", "dbo.BanGiaoCongViecCuaQuanNgucNghis");
            DropIndex("dbo.PhongGiams", new[] { "BanGiaoPhamNhan_ID" });
            DropIndex("dbo.PhongGiams", new[] { "BanGiaoCongViecCuaQuanNgucNghi_ID" });
            DropColumn("dbo.PhongGiams", "BanGiaoPhamNhan_ID");
            DropColumn("dbo.PhongGiams", "BanGiaoCongViecCuaQuanNgucNghi_ID");
        }
    }
}
