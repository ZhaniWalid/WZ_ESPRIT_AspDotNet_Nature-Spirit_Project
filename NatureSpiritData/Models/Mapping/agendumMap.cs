using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class agendumMap : EntityTypeConfiguration<agendum>
    {
        public agendumMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id_Event, t.Id_Member, t.date_Event });

            // Properties
            this.Property(t => t.Id_Event)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Id_Member)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("agenda", "base");
            this.Property(t => t.Id_Event).HasColumnName("Id_Event");
            this.Property(t => t.Id_Member).HasColumnName("Id_Member");
            this.Property(t => t.date_Event).HasColumnName("date_Event");

            // Relationships
            this.HasRequired(t => t.member)
                .WithMany(t => t.agenda)
                .HasForeignKey(d => d.Id_Member);
            this.HasRequired(t => t.@event)
                .WithMany(t => t.agenda)
                .HasForeignKey(d => d.Id_Event);

        }
    }
}
