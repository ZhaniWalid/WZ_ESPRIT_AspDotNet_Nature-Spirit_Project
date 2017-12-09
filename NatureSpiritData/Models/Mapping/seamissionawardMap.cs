using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class seamissionawardMap : EntityTypeConfiguration<seamissionaward>
    {
        public seamissionawardMap()
        {
            // Primary Key
            this.HasKey(t => t.idSeaMissionAward);

            // Properties
            this.Property(t => t.Destination)
                .HasMaxLength(255);

            this.Property(t => t.goal)
                .HasMaxLength(255);

            this.Property(t => t.warning)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("seamissionaward", "base");
            this.Property(t => t.idSeaMissionAward).HasColumnName("idSeaMissionAward");
            this.Property(t => t.Destination).HasColumnName("Destination");
            this.Property(t => t.altitude).HasColumnName("altitude");
            this.Property(t => t.endStart).HasColumnName("endStart");
            this.Property(t => t.goal).HasColumnName("goal");
            this.Property(t => t.longitude).HasColumnName("longitude");
            this.Property(t => t.startDate).HasColumnName("startDate");
            this.Property(t => t.warning).HasColumnName("warning");
            this.Property(t => t.admin_id_Member).HasColumnName("admin_id_Member");
            this.Property(t => t.sailor_id_Member).HasColumnName("sailor_id_Member");

            // Relationships
            this.HasOptional(t => t.member)
                .WithMany(t => t.seamissionawards)
                .HasForeignKey(d => d.admin_id_Member);
            this.HasOptional(t => t.member1)
                .WithMany(t => t.seamissionawards1)
                .HasForeignKey(d => d.sailor_id_Member);

        }
    }
}
