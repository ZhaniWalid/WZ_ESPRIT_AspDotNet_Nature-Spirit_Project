using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class articleMap : EntityTypeConfiguration<article>
    {
        public articleMap()
        {
            // Primary Key
            this.HasKey(t => t.id_Article);

            // Properties
            this.Property(t => t.Image)
                .HasMaxLength(255);

            this.Property(t => t.Subject)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("article", "base");
            this.Property(t => t.id_Article).HasColumnName("id_Article");
            this.Property(t => t.Image).HasColumnName("Image");
            this.Property(t => t.Subject).HasColumnName("Subject");
            this.Property(t => t.journalist_id_Member).HasColumnName("journalist_id_Member");

            // Relationships
            this.HasOptional(t => t.member)
                .WithMany(t => t.articles)
                .HasForeignKey(d => d.journalist_id_Member);

        }
    }
}
