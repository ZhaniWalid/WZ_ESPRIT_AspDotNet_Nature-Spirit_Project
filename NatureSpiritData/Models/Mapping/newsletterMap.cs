using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class newsletterMap : EntityTypeConfiguration<newsletter>
    {
        public newsletterMap()
        {
            // Primary Key
            this.HasKey(t => t.id_Newsletter);

            // Properties
            this.Property(t => t.News_Contents)
                .HasMaxLength(255);

            this.Property(t => t.News_Subject)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("newsletter", "base");
            this.Property(t => t.id_Newsletter).HasColumnName("id_Newsletter");
            this.Property(t => t.News_Contents).HasColumnName("News_Contents");
            this.Property(t => t.News_Subject).HasColumnName("News_Subject");
            this.Property(t => t.User_Registration_Number).HasColumnName("User_Registration_Number");
        }
    }
}
