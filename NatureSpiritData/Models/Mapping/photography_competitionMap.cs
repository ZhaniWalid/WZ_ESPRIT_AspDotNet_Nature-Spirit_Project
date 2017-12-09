using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class photography_competitionMap : EntityTypeConfiguration<photography_competition>
    {
        public photography_competitionMap()
        {
            // Primary Key
            this.HasKey(t => t.id_PhotoCompetition);

            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(255);

            this.Property(t => t.Picture)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("photography_competition", "base");
            this.Property(t => t.id_PhotoCompetition).HasColumnName("id_PhotoCompetition");
            this.Property(t => t.Date_Of_Capture).HasColumnName("Date_Of_Capture");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Picture).HasColumnName("Picture");
            this.Property(t => t.admin_id_Member).HasColumnName("admin_id_Member");
            this.Property(t => t.journalist_id_Member).HasColumnName("journalist_id_Member");
            this.Property(t => t.member_id_Member).HasColumnName("member_id_Member");
            this.Property(t => t.reclamationPicture_id_Reclamation).HasColumnName("reclamationPicture_id_Reclamation");

            // Relationships
            this.HasOptional(t => t.member)
                .WithMany(t => t.photography_competition)
                .HasForeignKey(d => d.admin_id_Member);
            this.HasOptional(t => t.member1)
                .WithMany(t => t.photography_competition1)
                .HasForeignKey(d => d.journalist_id_Member);
            this.HasOptional(t => t.member2)
                .WithMany(t => t.photography_competition2)
                .HasForeignKey(d => d.member_id_Member);
            this.HasOptional(t => t.reclamation)
                .WithMany(t => t.photography_competition)
                .HasForeignKey(d => d.reclamationPicture_id_Reclamation);

        }
    }
}
