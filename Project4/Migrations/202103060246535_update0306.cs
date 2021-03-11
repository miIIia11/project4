namespace Project4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update0306 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Khus", "TenKhu", c => c.String());
            AddColumn("dbo.PhongGiams", "TenPhong", c => c.String());
            AddColumn("dbo.AspNetUsers", "QuanNgucID", c => c.Guid(nullable: false));
            DropColumn("dbo.Khus", "PhongID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Khus", "PhongID", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "QuanNgucID");
            DropColumn("dbo.PhongGiams", "TenPhong");
            DropColumn("dbo.Khus", "TenKhu");
        }
    }
}
