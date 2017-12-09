using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class sea_missionMap : EntityTypeConfiguration<sea_mission>
    {
        public sea_missionMap()
        {
            // Primary Key
            this.HasKey(t => t.id_SeaMission);

            // Properties
            this.Property(t => t.Destination)
                .HasMaxLength(255);

            this.Property(t => t.Goal)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("sea_mission", "base");
            this.Property(t => t.id_SeaMission).HasColumnName("id_SeaMission");
            this.Property(t => t.Destination).HasColumnName("Destination");
            this.Property(t => t.Goal).HasColumnName("Goal");
            this.Property(t => t.Ship_Number).HasColumnName("Ship_Number");
            this.Property(t => t.admin_id_Member).HasColumnName("admin_id_Member");

            // Relationships
            this.HasOptional(t => t.member)
                .WithMany(t => t.sea_mission)
                .HasForeignKey(d => d.admin_id_Member);

        }
    }
}
