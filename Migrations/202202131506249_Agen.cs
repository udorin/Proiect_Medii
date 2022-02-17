namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agenda", "WhenToComplete", c => c.DateTime(nullable: false));
            DropColumn("dbo.Agenda", "EndUntil");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agenda", "EndUntil", c => c.DateTime(nullable: false));
            DropColumn("dbo.Agenda", "WhenToComplete");
        }
    }
}
