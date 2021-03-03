namespace Project4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnXas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PhamNhanID = c.Guid(nullable: false),
                        MucDoAnXa = c.Int(nullable: false),
                        MucDoCaiTao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Benhs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenBenh = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CheDoNghiPhepCuaQuanNgucs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuanNgucID = c.Guid(nullable: false),
                        SoNgayNghi = c.Int(nullable: false),
                        LyDoNghi = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Khus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuanNgucID = c.Guid(nullable: false),
                        PhongID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LaoDongCongIches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PhamNhanID = c.Guid(nullable: false),
                        QuanNgucID = c.Guid(nullable: false),
                        KhuVucLamViec = c.Int(nullable: false),
                        BieuHien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PhamNhans",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        TenPhamNhan = c.String(),
                        BiDanh = c.String(),
                        AnhNhanDien = c.String(),
                        QueQuan = c.String(),
                        NgaySinh = c.DateTime(nullable: false),
                        GioiTinh = c.Int(nullable: false),
                        IDKhu = c.Int(nullable: false),
                        ToiDanh = c.Int(nullable: false),
                        MucDoNguyHiem = c.Int(nullable: false),
                        SoNgayGiamGiu = c.Int(nullable: false),
                        CMND = c.String(),
                        QuaTrinhGayAn = c.String(),
                        DiaDiemGayAn = c.String(),
                        PhongGiamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PhongGiams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KhuID = c.Int(nullable: false),
                        SoLuongPhamNhanMax = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.QuanLyBenhTats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PhamNhanID = c.Guid(nullable: false),
                        BenhID = c.Int(nullable: false),
                        ThoiGianDieuTri = c.Int(nullable: false),
                        NoiDieuTri = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.QuanNgucs",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        TenQuanNguc = c.String(),
                        NgaySinh = c.DateTime(nullable: false),
                        QueQuan = c.String(),
                        GioiTinh = c.Int(nullable: false),
                        KhuID = c.Int(nullable: false),
                        NamCongTac = c.Int(nullable: false),
                        ThoiHanCongTac = c.Int(nullable: false),
                        CMND = c.String(),
                        ChucVu = c.Int(nullable: false),
                        QuanHam = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ThamGuis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PhamNhanID = c.Guid(nullable: false),
                        QuanNgucID = c.Guid(nullable: false),
                        KeHoachThamGui = c.Int(nullable: false),
                        NgayThamGui = c.DateTime(nullable: false),
                        ThongTinNguoiThamHoi = c.String(),
                        SoLanThamHoi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ThamGuis");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.QuanNgucs");
            DropTable("dbo.QuanLyBenhTats");
            DropTable("dbo.PhongGiams");
            DropTable("dbo.PhamNhans");
            DropTable("dbo.LaoDongCongIches");
            DropTable("dbo.Khus");
            DropTable("dbo.CheDoNghiPhepCuaQuanNgucs");
            DropTable("dbo.Benhs");
            DropTable("dbo.AnXas");
        }
    }
}
