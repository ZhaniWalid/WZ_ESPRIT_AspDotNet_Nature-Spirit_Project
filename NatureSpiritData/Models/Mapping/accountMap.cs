using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class accountMap : EntityTypeConfiguration<account>
    {
        public accountMap()
        {
            // Primary Key
            this.HasKey(t => t.id_Account);

            // Properties
            // Table & Column Mappings
            this.ToTable("account", "base");
            this.Property(t => t.id_Account).HasColumnName("id_Account");
            this.Property(t => t.Credit).HasColumnName("Credit");
            this.Property(t => t.Rib_Number).HasColumnName("Rib_Number");
            this.Property(t => t.member_id_Member).HasColumnName("member_id_Member");

            // Relationships
            this.HasOptional(t => t.member)
                .WithMany(t => t.accounts)
                .HasForeignKey(d => d.member_id_Member);

        }
    }
}
