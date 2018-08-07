namespace Capstone_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class followinginvited : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalUserId = c.Int(nullable: false),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .ForeignKey("dbo.PersonalUsers", t => t.PersonalUserId, cascadeDelete: true)
                .Index(t => t.PersonalUserId)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.Inviteds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        InvitedID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.InvitedID)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.InvitedID);
            
            AddColumn("dbo.Events", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Events", "ApplicationUserID");
            AddForeignKey("dbo.Events", "ApplicationUserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inviteds", "EventId", "dbo.Events");
            DropForeignKey("dbo.Inviteds", "InvitedID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "PersonalUserId", "dbo.PersonalUsers");
            DropForeignKey("dbo.Followings", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Inviteds", new[] { "InvitedID" });
            DropIndex("dbo.Inviteds", new[] { "EventId" });
            DropIndex("dbo.Followings", new[] { "ApplicationUserID" });
            DropIndex("dbo.Followings", new[] { "PersonalUserId" });
            DropIndex("dbo.Events", new[] { "ApplicationUserID" });
            DropColumn("dbo.Events", "ApplicationUserID");
            DropTable("dbo.Inviteds");
            DropTable("dbo.Followings");
        }
    }
}
