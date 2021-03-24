namespace Project4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themBangLuuKhiXoaQuanNguc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BanGiaoCongViecCuaQuanNgucNghis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuanNgucNhanID = c.Guid(nullable: false),
                        PhongID = c.Int(nullable: false),
                        NgayNhan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BanGiaoCongViecCuaQuanNgucNghis");
        }
    }
}
