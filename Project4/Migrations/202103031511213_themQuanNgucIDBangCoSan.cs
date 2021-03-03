namespace Project4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themQuanNgucIDBangCoSan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "QuanNgucID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "QuanNgucID");
        }
    }
}
