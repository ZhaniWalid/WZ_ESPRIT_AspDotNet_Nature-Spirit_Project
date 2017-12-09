namespace NatureSpiritData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "base.account",
                c => new
                    {
                        id_Account = c.Int(nullable: false, identity: true),
                        Credit = c.Double(),
                        Rib_Number = c.Int(nullable: false),
                        member_id_Member = c.Int(),
                    })
                .PrimaryKey(t => t.id_Account)
                .ForeignKey("base.member", t => t.member_id_Member)
                .Index(t => t.member_id_Member);
            
            CreateTable(
                "base.member",
                c => new
                    {
                        id_Member = c.Int(nullable: false, identity: true),
                        DTYPE = c.String(nullable: false, maxLength: 31, storeType: "nvarchar"),
                        Date_Birth = c.DateTime(precision: 0),
                        Email = c.String(maxLength: 255, storeType: "nvarchar"),
                        First_Name = c.String(maxLength: 255, storeType: "nvarchar"),
                        Last_Name = c.String(maxLength: 255, storeType: "nvarchar"),
                        Login = c.String(maxLength: 255, storeType: "nvarchar"),
                        Password = c.String(maxLength: 255, storeType: "nvarchar"),
                        Profil_Picture = c.String(maxLength: 255, storeType: "nvarchar"),
                        balance = c.Single(),
                        Num_Journalist_Card = c.String(maxLength: 255, storeType: "nvarchar"),
                        Num_Sailor = c.String(maxLength: 255, storeType: "nvarchar"),
                        admin_id_Member = c.Int(),
                        newsletter_id_Newsletter = c.Int(),
                        reclamationMember_id_Reclamation = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id_Member)
                .ForeignKey("base.member", t => t.admin_id_Member)
                .ForeignKey("base.newsletter", t => t.newsletter_id_Newsletter)
                .ForeignKey("base.reclamation", t => t.reclamationMember_id_Reclamation)
                .Index(t => t.admin_id_Member)
                .Index(t => t.newsletter_id_Newsletter)
                .Index(t => t.reclamationMember_id_Reclamation);
            
            CreateTable(
                "base.agenda",
                c => new
                    {
                        Id_Event = c.Int(nullable: false),
                        Id_Member = c.Int(nullable: false),
                        date_Event = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => new { t.Id_Event, t.Id_Member, t.date_Event })
                .ForeignKey("base.event", t => t.Id_Event, cascadeDelete: true)
                .ForeignKey("base.member", t => t.Id_Member, cascadeDelete: true)
                .Index(t => t.Id_Event)
                .Index(t => t.Id_Member);
            
            CreateTable(
                "base.event",
                c => new
                    {
                        id_Event = c.Int(nullable: false, identity: true),
                        Date_Event = c.DateTime(precision: 0),
                        Description_Event = c.String(maxLength: 255, storeType: "nvarchar"),
                        Location_Event = c.String(maxLength: 255, storeType: "nvarchar"),
                        NameEvent = c.String(maxLength: 255, storeType: "nvarchar"),
                        TypeEvent = c.String(maxLength: 255, storeType: "nvarchar"),
                        admin_id_Member = c.Int(),
                    })
                .PrimaryKey(t => t.id_Event)
                .ForeignKey("base.member", t => t.admin_id_Member)
                .Index(t => t.admin_id_Member);
            
            CreateTable(
                "base.donation",
                c => new
                    {
                        dateOfDonation = c.DateTime(nullable: false, precision: 0),
                        idEvent = c.Int(nullable: false),
                        idMember = c.Int(nullable: false),
                        amount = c.Single(),
                    })
                .PrimaryKey(t => new { t.dateOfDonation, t.idEvent, t.idMember })
                .ForeignKey("base.event", t => t.idEvent, cascadeDelete: true)
                .ForeignKey("base.member", t => t.idMember, cascadeDelete: true)
                .Index(t => t.idEvent)
                .Index(t => t.idMember);
            
            CreateTable(
                "base.participation",
                c => new
                    {
                        Id_Event = c.Int(nullable: false),
                        Id_Member = c.Int(nullable: false),
                        date_Event = c.DateTime(nullable: false, precision: 0),
                        evaluation = c.Int(),
                        opinions = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.Id_Event, t.Id_Member, t.date_Event })
                .ForeignKey("base.event", t => t.Id_Event, cascadeDelete: true)
                .ForeignKey("base.member", t => t.Id_Member, cascadeDelete: true)
                .Index(t => t.Id_Event)
                .Index(t => t.Id_Member);
            
            CreateTable(
                "base.alert",
                c => new
                    {
                        id_Alert = c.Int(nullable: false, identity: true),
                        Alert_Date = c.DateTime(precision: 0),
                        Alert_Description = c.String(maxLength: 255, storeType: "nvarchar"),
                        Alert_Location = c.String(maxLength: 255, storeType: "nvarchar"),
                        Alert_Subject = c.String(maxLength: 255, storeType: "nvarchar"),
                        admin_id_Member = c.Int(),
                        member_id_Member = c.Int(),
                    })
                .PrimaryKey(t => t.id_Alert)
                .ForeignKey("base.member", t => t.member_id_Member)
                .ForeignKey("base.member", t => t.admin_id_Member)
                .Index(t => t.admin_id_Member)
                .Index(t => t.member_id_Member);
            
            CreateTable(
                "base.article",
                c => new
                    {
                        id_Article = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 255, storeType: "nvarchar"),
                        Subject = c.String(maxLength: 255, storeType: "nvarchar"),
                        journalist_id_Member = c.Int(),
                    })
                .PrimaryKey(t => t.id_Article)
                .ForeignKey("base.member", t => t.journalist_id_Member)
                .Index(t => t.journalist_id_Member);
            
            CreateTable(
                "base.comment",
                c => new
                    {
                        Date_Of_Comment = c.DateTime(nullable: false, precision: 0),
                        Id_Article = c.Int(nullable: false),
                        Id_Member = c.Int(nullable: false),
                        Comment = c.String(maxLength: 255, storeType: "nvarchar"),
                        reclamationComment_id_Reclamation = c.Int(),
                    })
                .PrimaryKey(t => new { t.Date_Of_Comment, t.Id_Article, t.Id_Member })
                .ForeignKey("base.article", t => t.Id_Article, cascadeDelete: true)
                .ForeignKey("base.member", t => t.Id_Member, cascadeDelete: true)
                .ForeignKey("base.reclamation", t => t.reclamationComment_id_Reclamation)
                .Index(t => t.Id_Article)
                .Index(t => t.Id_Member)
                .Index(t => t.reclamationComment_id_Reclamation);
            
            CreateTable(
                "base.reclamation",
                c => new
                    {
                        id_Reclamation = c.Int(nullable: false, identity: true),
                        DTYPE = c.String(nullable: false, maxLength: 31, storeType: "nvarchar"),
                        Date_Reclamation = c.DateTime(precision: 0),
                        Description_Reclamation = c.String(maxLength: 255, storeType: "nvarchar"),
                        First_Name = c.String(maxLength: 255, storeType: "nvarchar"),
                        Last_Name = c.String(maxLength: 255, storeType: "nvarchar"),
                        idReclamtionMember = c.Int(),
                        Picture = c.String(maxLength: 255, storeType: "nvarchar"),
                        idReclamationPicture = c.Int(),
                        Comment = c.String(maxLength: 255, storeType: "nvarchar"),
                        idReclamationComment = c.Int(),
                        admin_id_Member = c.Int(),
                        member_id_Member = c.Int(),
                    })
                .PrimaryKey(t => t.id_Reclamation)
                .ForeignKey("base.member", t => t.admin_id_Member)
                .ForeignKey("base.member", t => t.member_id_Member)
                .Index(t => t.admin_id_Member)
                .Index(t => t.member_id_Member);
            
            CreateTable(
                "base.photography_competition",
                c => new
                    {
                        id_PhotoCompetition = c.Int(nullable: false, identity: true),
                        Date_Of_Capture = c.DateTime(precision: 0),
                        Description = c.String(maxLength: 255, storeType: "nvarchar"),
                        Picture = c.String(maxLength: 255, storeType: "nvarchar"),
                        admin_id_Member = c.Int(),
                        journalist_id_Member = c.Int(),
                        member_id_Member = c.Int(),
                        reclamationPicture_id_Reclamation = c.Int(),
                    })
                .PrimaryKey(t => t.id_PhotoCompetition)
                .ForeignKey("base.member", t => t.admin_id_Member)
                .ForeignKey("base.member", t => t.journalist_id_Member)
                .ForeignKey("base.member", t => t.member_id_Member)
                .ForeignKey("base.reclamation", t => t.reclamationPicture_id_Reclamation)
                .Index(t => t.admin_id_Member)
                .Index(t => t.journalist_id_Member)
                .Index(t => t.member_id_Member)
                .Index(t => t.reclamationPicture_id_Reclamation);
            
            CreateTable(
                "base.details",
                c => new
                    {
                        Id_Member = c.Int(nullable: false),
                        Id_Product = c.Int(nullable: false),
                        date_Of_Purchase = c.DateTime(nullable: false, precision: 0),
                        Quantity = c.Int(),
                        Total_amount = c.Double(),
                        state = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.Id_Member, t.Id_Product, t.date_Of_Purchase })
                .ForeignKey("base.member", t => t.Id_Member, cascadeDelete: true)
                .ForeignKey("base.product", t => t.Id_Product, cascadeDelete: true)
                .Index(t => t.Id_Member)
                .Index(t => t.Id_Product);
            
            CreateTable(
                "base.product",
                c => new
                    {
                        id_Product = c.Int(nullable: false, identity: true),
                        Availability = c.Int(nullable: false),
                        Price = c.Double(),
                        Type_Product = c.String(maxLength: 255, storeType: "nvarchar"),
                        admin_id_Member = c.Int(),
                    })
                .PrimaryKey(t => t.id_Product)
                .ForeignKey("base.member", t => t.admin_id_Member)
                .Index(t => t.admin_id_Member);
            
            CreateTable(
                "base.donationtheory",
                c => new
                    {
                        id_Donation_Theory = c.Int(nullable: false, identity: true),
                        Amount_of_money = c.Double(),
                        Date_of_transfert = c.DateTime(precision: 0),
                        member_id_Member = c.Int(),
                    })
                .PrimaryKey(t => t.id_Donation_Theory)
                .ForeignKey("base.member", t => t.member_id_Member)
                .Index(t => t.member_id_Member);
            
            CreateTable(
                "base.membernews",
                c => new
                    {
                        Id_Member = c.Int(nullable: false),
                        Id_News = c.Int(nullable: false),
                        date_Of_Comment = c.DateTime(nullable: false, precision: 0),
                        Comment = c.String(maxLength: 255, storeType: "nvarchar"),
                        State_News = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id_Member, t.Id_News, t.date_Of_Comment })
                .ForeignKey("base.member", t => t.Id_Member, cascadeDelete: true)
                .ForeignKey("base.news", t => t.Id_News, cascadeDelete: true)
                .Index(t => t.Id_Member)
                .Index(t => t.Id_News);
            
            CreateTable(
                "base.news",
                c => new
                    {
                        idNews = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 255, storeType: "nvarchar"),
                        picture = c.String(maxLength: 255, storeType: "nvarchar"),
                        video = c.Binary(),
                        admin_id_Member = c.Int(),
                        topic_idTopic = c.Int(),
                    })
                .PrimaryKey(t => t.idNews)
                .ForeignKey("base.member", t => t.admin_id_Member)
                .ForeignKey("base.topic", t => t.topic_idTopic)
                .Index(t => t.admin_id_Member)
                .Index(t => t.topic_idTopic);
            
            CreateTable(
                "base.topic",
                c => new
                    {
                        idTopic = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 255, storeType: "nvarchar"),
                        title = c.String(maxLength: 255, storeType: "nvarchar"),
                        typeTopic = c.String(maxLength: 255, storeType: "nvarchar"),
                        admin_id_Member = c.Int(),
                    })
                .PrimaryKey(t => t.idTopic)
                .ForeignKey("base.member", t => t.admin_id_Member)
                .Index(t => t.admin_id_Member);
            
            CreateTable(
                "base.mission_sailor",
                c => new
                    {
                        Id_Member = c.Int(nullable: false),
                        Id_SeaMission = c.Int(nullable: false),
                        end_Date = c.DateTime(nullable: false, precision: 0),
                        start_Date = c.DateTime(nullable: false, precision: 0),
                        state = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.Id_Member, t.Id_SeaMission, t.end_Date, t.start_Date })
                .ForeignKey("base.member", t => t.Id_Member, cascadeDelete: true)
                .ForeignKey("base.sea_mission", t => t.Id_SeaMission, cascadeDelete: true)
                .Index(t => t.Id_Member)
                .Index(t => t.Id_SeaMission);
            
            CreateTable(
                "base.sea_mission",
                c => new
                    {
                        id_SeaMission = c.Int(nullable: false, identity: true),
                        Destination = c.String(maxLength: 255, storeType: "nvarchar"),
                        Goal = c.String(maxLength: 255, storeType: "nvarchar"),
                        Ship_Number = c.Int(nullable: false),
                        admin_id_Member = c.Int(),
                    })
                .PrimaryKey(t => t.id_SeaMission)
                .ForeignKey("base.member", t => t.admin_id_Member)
                .Index(t => t.admin_id_Member);
            
            CreateTable(
                "base.newsletter",
                c => new
                    {
                        id_Newsletter = c.Int(nullable: false, identity: true),
                        News_Contents = c.String(maxLength: 255, storeType: "nvarchar"),
                        News_Subject = c.String(maxLength: 255, storeType: "nvarchar"),
                        User_Registration_Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_Newsletter);
            
            CreateTable(
                "base.seamissionaward",
                c => new
                    {
                        idSeaMissionAward = c.Int(nullable: false, identity: true),
                        Destination = c.String(maxLength: 255, storeType: "nvarchar"),
                        altitude = c.Double(),
                        endStart = c.DateTime(precision: 0),
                        goal = c.String(maxLength: 255, storeType: "nvarchar"),
                        longitude = c.Double(),
                        startDate = c.DateTime(precision: 0),
                        warning = c.String(maxLength: 255, storeType: "nvarchar"),
                        admin_id_Member = c.Int(),
                        sailor_id_Member = c.Int(),
                    })
                .PrimaryKey(t => t.idSeaMissionAward)
                .ForeignKey("base.member", t => t.admin_id_Member)
                .ForeignKey("base.member", t => t.sailor_id_Member)
                .Index(t => t.admin_id_Member)
                .Index(t => t.sailor_id_Member);
            
        }
        
        public override void Down()
        {
            DropForeignKey("base.account", "member_id_Member", "base.member");
            DropForeignKey("base.seamissionaward", "sailor_id_Member", "base.member");
            DropForeignKey("base.seamissionaward", "admin_id_Member", "base.member");
            DropForeignKey("base.member", "reclamationMember_id_Reclamation", "base.reclamation");
            DropForeignKey("base.member", "newsletter_id_Newsletter", "base.newsletter");
            DropForeignKey("base.mission_sailor", "Id_SeaMission", "base.sea_mission");
            DropForeignKey("base.sea_mission", "admin_id_Member", "base.member");
            DropForeignKey("base.mission_sailor", "Id_Member", "base.member");
            DropForeignKey("base.membernews", "Id_News", "base.news");
            DropForeignKey("base.news", "topic_idTopic", "base.topic");
            DropForeignKey("base.topic", "admin_id_Member", "base.member");
            DropForeignKey("base.news", "admin_id_Member", "base.member");
            DropForeignKey("base.membernews", "Id_Member", "base.member");
            DropForeignKey("base.member", "admin_id_Member", "base.member");
            DropForeignKey("base.donationtheory", "member_id_Member", "base.member");
            DropForeignKey("base.details", "Id_Product", "base.product");
            DropForeignKey("base.product", "admin_id_Member", "base.member");
            DropForeignKey("base.details", "Id_Member", "base.member");
            DropForeignKey("base.article", "journalist_id_Member", "base.member");
            DropForeignKey("base.comment", "reclamationComment_id_Reclamation", "base.reclamation");
            DropForeignKey("base.photography_competition", "reclamationPicture_id_Reclamation", "base.reclamation");
            DropForeignKey("base.photography_competition", "member_id_Member", "base.member");
            DropForeignKey("base.photography_competition", "journalist_id_Member", "base.member");
            DropForeignKey("base.photography_competition", "admin_id_Member", "base.member");
            DropForeignKey("base.reclamation", "member_id_Member", "base.member");
            DropForeignKey("base.reclamation", "admin_id_Member", "base.member");
            DropForeignKey("base.comment", "Id_Member", "base.member");
            DropForeignKey("base.comment", "Id_Article", "base.article");
            DropForeignKey("base.alert", "admin_id_Member", "base.member");
            DropForeignKey("base.alert", "member_id_Member", "base.member");
            DropForeignKey("base.agenda", "Id_Member", "base.member");
            DropForeignKey("base.agenda", "Id_Event", "base.event");
            DropForeignKey("base.participation", "Id_Member", "base.member");
            DropForeignKey("base.participation", "Id_Event", "base.event");
            DropForeignKey("base.event", "admin_id_Member", "base.member");
            DropForeignKey("base.donation", "idMember", "base.member");
            DropForeignKey("base.donation", "idEvent", "base.event");
            DropIndex("base.seamissionaward", new[] { "sailor_id_Member" });
            DropIndex("base.seamissionaward", new[] { "admin_id_Member" });
            DropIndex("base.sea_mission", new[] { "admin_id_Member" });
            DropIndex("base.mission_sailor", new[] { "Id_SeaMission" });
            DropIndex("base.mission_sailor", new[] { "Id_Member" });
            DropIndex("base.topic", new[] { "admin_id_Member" });
            DropIndex("base.news", new[] { "topic_idTopic" });
            DropIndex("base.news", new[] { "admin_id_Member" });
            DropIndex("base.membernews", new[] { "Id_News" });
            DropIndex("base.membernews", new[] { "Id_Member" });
            DropIndex("base.donationtheory", new[] { "member_id_Member" });
            DropIndex("base.product", new[] { "admin_id_Member" });
            DropIndex("base.details", new[] { "Id_Product" });
            DropIndex("base.details", new[] { "Id_Member" });
            DropIndex("base.photography_competition", new[] { "reclamationPicture_id_Reclamation" });
            DropIndex("base.photography_competition", new[] { "member_id_Member" });
            DropIndex("base.photography_competition", new[] { "journalist_id_Member" });
            DropIndex("base.photography_competition", new[] { "admin_id_Member" });
            DropIndex("base.reclamation", new[] { "member_id_Member" });
            DropIndex("base.reclamation", new[] { "admin_id_Member" });
            DropIndex("base.comment", new[] { "reclamationComment_id_Reclamation" });
            DropIndex("base.comment", new[] { "Id_Member" });
            DropIndex("base.comment", new[] { "Id_Article" });
            DropIndex("base.article", new[] { "journalist_id_Member" });
            DropIndex("base.alert", new[] { "member_id_Member" });
            DropIndex("base.alert", new[] { "admin_id_Member" });
            DropIndex("base.participation", new[] { "Id_Member" });
            DropIndex("base.participation", new[] { "Id_Event" });
            DropIndex("base.donation", new[] { "idMember" });
            DropIndex("base.donation", new[] { "idEvent" });
            DropIndex("base.event", new[] { "admin_id_Member" });
            DropIndex("base.agenda", new[] { "Id_Member" });
            DropIndex("base.agenda", new[] { "Id_Event" });
            DropIndex("base.member", new[] { "reclamationMember_id_Reclamation" });
            DropIndex("base.member", new[] { "newsletter_id_Newsletter" });
            DropIndex("base.member", new[] { "admin_id_Member" });
            DropIndex("base.account", new[] { "member_id_Member" });
            DropTable("base.seamissionaward");
            DropTable("base.newsletter");
            DropTable("base.sea_mission");
            DropTable("base.mission_sailor");
            DropTable("base.topic");
            DropTable("base.news");
            DropTable("base.membernews");
            DropTable("base.donationtheory");
            DropTable("base.product");
            DropTable("base.details");
            DropTable("base.photography_competition");
            DropTable("base.reclamation");
            DropTable("base.comment");
            DropTable("base.article");
            DropTable("base.alert");
            DropTable("base.participation");
            DropTable("base.donation");
            DropTable("base.event");
            DropTable("base.agenda");
            DropTable("base.member");
            DropTable("base.account");
        }
    }
}
