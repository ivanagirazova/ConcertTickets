namespace Concert_Tickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Concerts", "numberOfTicketsFloor", c => c.Int(nullable: false));
            AddColumn("dbo.Concerts", "numberOfTicketsPit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Concerts", "numberOfTicketsPit");
            DropColumn("dbo.Concerts", "numberOfTicketsFloor");
        }
    }
}
