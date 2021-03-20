namespace Project4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuanNgucs", "AnhNhanDien", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuanNgucs", "AnhNhanDien");
        }
    }
}
