using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using NatureSpiritData.Models.Mapping;

namespace NatureSpiritData.Models
{
    public partial class baseContext : DbContext
    {
        static baseContext()
        {
            Database.SetInitializer<baseContext>(null);
        }

        public baseContext(): base("Name=baseContext")
        {
            //Database.SetInitializer<baseContext>(new baseContextInitialize());   
        }

        public DbSet<account> accounts { get; set; }
        public DbSet<agendum> agenda { get; set; }
        public DbSet<alert> alerts { get; set; }
        public DbSet<article> articles { get; set; }
        public DbSet<comment> comments { get; set; }
        public DbSet<detail> details { get; set; }
        public DbSet<donation> donations { get; set; }
        public DbSet<donationtheory> donationtheories { get; set; }
        public DbSet<@event> events { get; set; }
        public DbSet<member> members { get; set; }  
        public DbSet<membernew> membernews { get; set; }
        public DbSet<mission_sailor> mission_sailor { get; set; }
        public DbSet<news> news { get; set; }
        public DbSet<newsletter> newsletters { get; set; }
        public DbSet<participation> participations { get; set; }
        public DbSet<photography_competition> photography_competition { get; set; }
        public DbSet<product> products { get; set; }
        public DbSet<reclamation> reclamations { get; set; }
        public DbSet<sea_mission> sea_mission { get; set; }
        public DbSet<seamissionaward> seamissionawards { get; set; }
        public DbSet<topic> topics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new accountMap());
            modelBuilder.Configurations.Add(new agendumMap());
            modelBuilder.Configurations.Add(new alertMap());
            modelBuilder.Configurations.Add(new articleMap());
            modelBuilder.Configurations.Add(new commentMap());
            modelBuilder.Configurations.Add(new detailMap());
            modelBuilder.Configurations.Add(new donationMap());
            modelBuilder.Configurations.Add(new donationtheoryMap());
            modelBuilder.Configurations.Add(new eventMap());
            modelBuilder.Configurations.Add(new memberMap());
            modelBuilder.Configurations.Add(new membernewMap());
            modelBuilder.Configurations.Add(new mission_sailorMap());
            modelBuilder.Configurations.Add(new newsMap());
            modelBuilder.Configurations.Add(new newsletterMap());
            modelBuilder.Configurations.Add(new participationMap());
            modelBuilder.Configurations.Add(new photography_competitionMap());
            modelBuilder.Configurations.Add(new productMap());
            modelBuilder.Configurations.Add(new reclamationMap());
            modelBuilder.Configurations.Add(new sea_missionMap());
            modelBuilder.Configurations.Add(new seamissionawardMap());
            modelBuilder.Configurations.Add(new topicMap());

            // configuring many-to-one relationship between Member(Admin) and News

            modelBuilder.Entity<news>()
                   .HasOptional<member>(n => n.member) // News entity requires Member 
                   .WithMany(n => n.news) // Member entity includes many News entities
                   .HasForeignKey(m => m.admin_id_Member); 
                      
            base.OnModelCreating(modelBuilder);



        }
    }
}
