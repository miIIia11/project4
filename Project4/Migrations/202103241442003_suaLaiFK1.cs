namespace Project4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suaLaiFK1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BanGiaoCongViecCuaQuanNgucNghis", "PhongGiam_ID", c => c.Int());
            AddColumn("dbo.BanGiaoPhamNhans", "PhongGiam_ID", c => c.Int());
            CreateIndex("dbo.BanGiaoCongViecCuaQuanNgucNghis", "PhongGiam_ID");
            CreateIndex("dbo.BanGiaoPhamNhans", "PhongGiam_ID");
            AddForeignKey("dbo.BanGiaoCongViecCuaQuanNgucNghis", "PhongGiam_ID", "dbo.PhongGiams", "ID");
            AddForeignKey("dbo.BanGiaoPhamNhans", "PhongGiam_ID", "dbo.PhongGiams", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BanGiaoPhamNhans", "PhongGiam_ID", "dbo.PhongGiams");
            DropForeignKey("dbo.BanGiaoCongViecCuaQuanNgucNghis", "PhongGiam_ID", "dbo.PhongGiams");
            DropIndex("dbo.BanGiaoPhamNhans", new[] { "PhongGiam_ID" });
            DropIndex("dbo.BanGiaoCongViecCuaQuanNgucNghis", new[] { "PhongGiam_ID" });
            DropColumn("dbo.BanGiaoPhamNhans", "PhongGiam_ID");
            DropColumn("dbo.BanGiaoCongViecCuaQuanNgucNghis", "PhongGiam_ID");
        }
    }
}
