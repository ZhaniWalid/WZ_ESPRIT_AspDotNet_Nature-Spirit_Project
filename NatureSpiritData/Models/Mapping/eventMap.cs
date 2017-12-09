using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class eventMap : EntityTypeConfiguration<@event>
    {
        public eventMap()
        {
            // Primary Key
            this.HasKey(t => t.id_Event);

            // Properties 
            this.Property(t => t.Description_Event)
                .HasMaxLength(255);

            this.Property(t => t.Location_Event)
                .HasMaxLength(255);

            this.Property(t => t.NameEvent)
                .HasMaxLength(255);

            this.Property(t => t.TypeEvent)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("event", "base");
            this.Property(t => t.id_Event).HasColumnName("id_Event");
            this.Property(t => t.Date_Event).HasColumnName("Date_Event");
            this.Property(t => t.Description_Event).HasColumnName("Description_Event");
            this.Property(t => t.Location_Event).HasColumnName("Location_Event");
            this.Property(t => t.NameEvent).HasColumnName("NameEvent");
            this.Property(t => t.TypeEvent).HasColumnName("TypeEvent");
            this.Property(t => t.admin_id_Member).HasColumnName("admin_id_Member");

            // Relationships
            this.HasOptional(t => t.member)
                .WithMany(t => t.events)
                .HasForeignKey(d => d.admin_id_Member);

        }
    }
}
