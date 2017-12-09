using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class detailMap : EntityTypeConfiguration<detail>
    {
        public detailMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id_Member, t.Id_Product, t.date_Of_Purchase });

            // Properties
            this.Property(t => t.Id_Member)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Id_Product)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("details", "base");
            this.Property(t => t.Id_Member).HasColumnName("Id_Member");
            this.Property(t => t.Id_Product).HasColumnName("Id_Product");
            this.Property(t => t.date_Of_Purchase).HasColumnName("date_Of_Purchase");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.Total_amount).HasColumnName("Total_amount");
            this.Property(t => t.state).HasColumnName("state");

            // Relationships
            this.HasRequired(t => t.member)
                .WithMany(t => t.details)
                .HasForeignKey(d => d.Id_Member);
            this.HasRequired(t => t.product)
                .WithMany(t => t.details)
                .HasForeignKey(d => d.Id_Product);

        }
    }
}
