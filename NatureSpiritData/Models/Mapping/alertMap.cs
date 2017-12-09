using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class alertMap : EntityTypeConfiguration<alert>
    {
        public alertMap()
        {
            // Primary Key
            this.HasKey(t => t.id_Alert);

            // Properties
            this.Property(t => t.Alert_Description)
                .HasMaxLength(255);

            this.Property(t => t.Alert_Location)
                .HasMaxLength(255);

            this.Property(t => t.Alert_Subject)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("alert", "base");
            this.Property(t => t.id_Alert).HasColumnName("id_Alert");
            this.Property(t => t.Alert_Date).HasColumnName("Alert_Date");
            this.Property(t => t.Alert_Description).HasColumnName("Alert_Description");
            this.Property(t => t.Alert_Location).HasColumnName("Alert_Location");
            this.Property(t => t.Alert_Subject).HasColumnName("Alert_Subject");
            this.Property(t => t.admin_id_Member).HasColumnName("admin_id_Member");
            this.Property(t => t.member_id_Member).HasColumnName("member_id_Member");

            // Relationships
            this.HasOptional(t => t.member)
                .WithMany(t => t.alerts)
                .HasForeignKey(d => d.member_id_Member);
            this.HasOptional(t => t.member1)
                .WithMany(t => t.alerts1)
                .HasForeignKey(d => d.admin_id_Member);

        }
    }
}
