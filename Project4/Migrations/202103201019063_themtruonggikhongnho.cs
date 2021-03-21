namespace Project4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themtruonggikhongnho : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Benhs", "NgayBatDauChuaTri", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Benhs", "NgayBatDauChuaTri");
        }
    }
}
