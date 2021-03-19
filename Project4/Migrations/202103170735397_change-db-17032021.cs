namespace Project4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedb17032021 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Benhs", "PhamNhanID", c => c.Guid(nullable: false));
            AddColumn("dbo.Benhs", "NgayChuaTri", c => c.Int(nullable: false));
            AddColumn("dbo.PhamNhans", "NgayVaoTrai", c => c.DateTime());
            AlterColumn("dbo.PhamNhans", "NgaySinh", c => c.DateTime());
            AlterColumn("dbo.QuanNgucs", "NgaySinh", c => c.DateTime());
            DropColumn("dbo.Benhs", "TenBenh");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Benhs", "TenBenh", c => c.String());
            AlterColumn("dbo.QuanNgucs", "NgaySinh", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PhamNhans", "NgaySinh", c => c.DateTime(nullable: false));
            DropColumn("dbo.PhamNhans", "NgayVaoTrai");
            DropColumn("dbo.Benhs", "NgayChuaTri");
            DropColumn("dbo.Benhs", "PhamNhanID");
        }
    }
}
