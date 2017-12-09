using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class donationMap : EntityTypeConfiguration<donation>
    {
        public donationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.dateOfDonation, t.idEvent, t.idMember });

            // Properties
            this.Property(t => t.idEvent)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idMember)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("donation", "base");
            this.Property(t => t.dateOfDonation).HasColumnName("dateOfDonation");
            this.Property(t => t.idEvent).HasColumnName("idEvent");
            this.Property(t => t.idMember).HasColumnName("idMember");
            this.Property(t => t.amount).HasColumnName("amount");

            // Relationships
            this.HasRequired(t => t.member)
                .WithMany(t => t.donations)
                .HasForeignKey(d => d.idMember);
            this.HasRequired(t => t.@event)
                .WithMany(t => t.donations)
                .HasForeignKey(d => d.idEvent);

        }
    }
}
