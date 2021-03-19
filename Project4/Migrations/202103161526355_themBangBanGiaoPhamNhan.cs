namespace Project4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themBangBanGiaoPhamNhan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BanGiaoPhamNhans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuanNgucNghiID = c.Guid(nullable: false),
                        QuanNgucNhanID = c.Guid(nullable: false),
                        PhongID = c.Int(nullable: false),
                        NgayNhan = c.DateTime(nullable: false),
                        SoNgayBanGiao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BanGiaoPhamNhans");
        }
    }
}
