using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class participationMap : EntityTypeConfiguration<participation>
    {
        public participationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id_Event, t.Id_Member, t.date_Event });

            // Properties
            this.Property(t => t.Id_Event)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Id_Member)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.opinions)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("participation", "base");
            this.Property(t => t.Id_Event).HasColumnName("Id_Event");
            this.Property(t => t.Id_Member).HasColumnName("Id_Member");
            this.Property(t => t.date_Event).HasColumnName("date_Event");
            this.Property(t => t.evaluation).HasColumnName("evaluation");
            this.Property(t => t.opinions).HasColumnName("opinions");

            // Relationships
            this.HasRequired(t => t.@event)
                .WithMany(t => t.participations)
                .HasForeignKey(d => d.Id_Event);
            this.HasRequired(t => t.member)
                .WithMany(t => t.participations)
                .HasForeignKey(d => d.Id_Member);

        }
    }
}
