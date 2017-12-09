using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class commentMap : EntityTypeConfiguration<comment>
    {
        public commentMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Date_Of_Comment, t.Id_Article, t.Id_Member });

            // Properties
            this.Property(t => t.Id_Article)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Id_Member)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Comment1)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("comment", "base");
            this.Property(t => t.Date_Of_Comment).HasColumnName("Date_Of_Comment");
            this.Property(t => t.Id_Article).HasColumnName("Id_Article");
            this.Property(t => t.Id_Member).HasColumnName("Id_Member");
            this.Property(t => t.Comment1).HasColumnName("Comment");
            this.Property(t => t.reclamationComment_id_Reclamation).HasColumnName("reclamationComment_id_Reclamation");

            // Relationships
            this.HasRequired(t => t.article)
                .WithMany(t => t.comments)
                .HasForeignKey(d => d.Id_Article);
            this.HasOptional(t => t.reclamation)
                .WithMany(t => t.comments)
                .HasForeignKey(d => d.reclamationComment_id_Reclamation);
            this.HasRequired(t => t.member)
                .WithMany(t => t.comments)
                .HasForeignKey(d => d.Id_Member);

        }
    }
}
