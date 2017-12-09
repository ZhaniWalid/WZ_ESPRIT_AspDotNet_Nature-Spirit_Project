using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class donationtheoryMap : EntityTypeConfiguration<donationtheory>
    {
        public donationtheoryMap()
        {
            // Primary Key
            this.HasKey(t => t.id_Donation_Theory);

            // Properties
            // Table & Column Mappings
            this.ToTable("donationtheory", "base");
            this.Property(t => t.id_Donation_Theory).HasColumnName("id_Donation_Theory");
            this.Property(t => t.Amount_of_money).HasColumnName("Amount_of_money");
            this.Property(t => t.Date_of_transfert).HasColumnName("Date_of_transfert");
            this.Property(t => t.member_id_Member).HasColumnName("member_id_Member");

            // Relationships
            this.HasOptional(t => t.member)
                .WithMany(t => t.donationtheories)
                .HasForeignKey(d => d.member_id_Member);

        }
    }
}
