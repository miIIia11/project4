namespace Project4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suaLaiFK : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PhongGiams", new[] { "BanGiaoCongViecCuaQuanNgucNghi_ID" });
            DropIndex("dbo.PhongGiams", new[] { "BanGiaoPhamNhan_ID" });
            RenameColumn(table: "dbo.BanGiaoCongViecCuaQuanNgucNghis", name: "BanGiaoCongViecCuaQuanNgucNghi_ID", newName: "PhongGiam_ID");
            RenameColumn(table: "dbo.BanGiaoPhamNhans", name: "BanGiaoPhamNhan_ID", newName: "PhongGiam_ID");
            CreateIndex("dbo.BanGiaoCongViecCuaQuanNgucNghis", "PhongGiam_ID");
            CreateIndex("dbo.BanGiaoPhamNhans", "PhongGiam_ID");
            DropColumn("dbo.PhongGiams", "BanGiaoCongViecCuaQuanNgucNghi_ID");
            DropColumn("dbo.PhongGiams", "BanGiaoPhamNhan_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhongGiams", "BanGiaoPhamNhan_ID", c => c.Int());
            AddColumn("dbo.PhongGiams", "BanGiaoCongViecCuaQuanNgucNghi_ID", c => c.Int());
            DropIndex("dbo.BanGiaoPhamNhans", new[] { "PhongGiam_ID" });
            DropIndex("dbo.BanGiaoCongViecCuaQuanNgucNghis", new[] { "PhongGiam_ID" });
            RenameColumn(table: "dbo.BanGiaoPhamNhans", name: "PhongGiam_ID", newName: "BanGiaoPhamNhan_ID");
            RenameColumn(table: "dbo.BanGiaoCongViecCuaQuanNgucNghis", name: "PhongGiam_ID", newName: "BanGiaoCongViecCuaQuanNgucNghi_ID");
            CreateIndex("dbo.PhongGiams", "BanGiaoPhamNhan_ID");
            CreateIndex("dbo.PhongGiams", "BanGiaoCongViecCuaQuanNgucNghi_ID");
        }
    }
}
