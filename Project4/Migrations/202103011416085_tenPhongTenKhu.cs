namespace Project4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tenPhongTenKhu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Khus", "TenKhu", c => c.String());
            AddColumn("dbo.PhongGiams", "TenPhong", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhongGiams", "TenPhong");
            DropColumn("dbo.Khus", "TenKhu");
        }
    }
}
