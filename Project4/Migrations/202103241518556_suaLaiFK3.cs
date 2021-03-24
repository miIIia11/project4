namespace Project4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suaLaiFK3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.BanGiaoCongViecCuaQuanNgucNghis", new[] { "PhongGiam_ID" });
            DropIndex("dbo.BanGiaoPhamNhans", new[] { "PhongGiam_ID" });
            DropColumn("dbo.BanGiaoCongViecCuaQuanNgucNghis", "PhongID");
            DropColumn("dbo.BanGiaoPhamNhans", "PhongID");
            RenameColumn(table: "dbo.BanGiaoCongViecCuaQuanNgucNghis", name: "PhongGiam_ID", newName: "PhongID");
            RenameColumn(table: "dbo.BanGiaoPhamNhans", name: "PhongGiam_ID", newName: "PhongID");
            AlterColumn("dbo.BanGiaoCongViecCuaQuanNgucNghis", "PhongID", c => c.Int());
            AlterColumn("dbo.BanGiaoPhamNhans", "PhongID", c => c.Int());
            CreateIndex("dbo.BanGiaoCongViecCuaQuanNgucNghis", "PhongID");
            CreateIndex("dbo.BanGiaoPhamNhans", "PhongID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.BanGiaoPhamNhans", new[] { "PhongID" });
            DropIndex("dbo.BanGiaoCongViecCuaQuanNgucNghis", new[] { "PhongID" });
            AlterColumn("dbo.BanGiaoPhamNhans", "PhongID", c => c.Int(nullable: false));
            AlterColumn("dbo.BanGiaoCongViecCuaQuanNgucNghis", "PhongID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.BanGiaoPhamNhans", name: "PhongID", newName: "PhongGiam_ID");
            RenameColumn(table: "dbo.BanGiaoCongViecCuaQuanNgucNghis", name: "PhongID", newName: "PhongGiam_ID");
            AddColumn("dbo.BanGiaoPhamNhans", "PhongID", c => c.Int(nullable: false));
            AddColumn("dbo.BanGiaoCongViecCuaQuanNgucNghis", "PhongID", c => c.Int(nullable: false));
            CreateIndex("dbo.BanGiaoPhamNhans", "PhongGiam_ID");
            CreateIndex("dbo.BanGiaoCongViecCuaQuanNgucNghis", "PhongGiam_ID");
        }
    }
}
