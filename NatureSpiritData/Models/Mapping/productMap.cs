using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class productMap : EntityTypeConfiguration<product>
    {
        public productMap()
        {
            // Primary Key
            this.HasKey(t => t.id_Product);

            // Properties
            this.Property(t => t.Type_Product)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("product", "base");
            this.Property(t => t.id_Product).HasColumnName("id_Product");
            this.Property(t => t.Availability).HasColumnName("Availability");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Type_Product).HasColumnName("Type_Product");
            this.Property(t => t.admin_id_Member).HasColumnName("admin_id_Member");

            // Relationships
            this.HasOptional(t => t.member)
                .WithMany(t => t.products)
                .HasForeignKey(d => d.admin_id_Member);

        }
    }
}
