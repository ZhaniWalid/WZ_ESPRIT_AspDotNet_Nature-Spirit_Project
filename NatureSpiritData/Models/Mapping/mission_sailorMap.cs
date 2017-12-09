using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class mission_sailorMap : EntityTypeConfiguration<mission_sailor>
    {
        public mission_sailorMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id_Member, t.Id_SeaMission, t.end_Date, t.start_Date });

            // Properties
            this.Property(t => t.Id_Member)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Id_SeaMission)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("mission_sailor", "base");
            this.Property(t => t.Id_Member).HasColumnName("Id_Member");
            this.Property(t => t.Id_SeaMission).HasColumnName("Id_SeaMission");
            this.Property(t => t.end_Date).HasColumnName("end_Date");
            this.Property(t => t.start_Date).HasColumnName("start_Date");
            this.Property(t => t.state).HasColumnName("state");

            // Relationships
            this.HasRequired(t => t.member)
                .WithMany(t => t.mission_sailor)
                .HasForeignKey(d => d.Id_Member);
            this.HasRequired(t => t.sea_mission)
                .WithMany(t => t.mission_sailor)
                .HasForeignKey(d => d.Id_SeaMission);

        }
    }
}
