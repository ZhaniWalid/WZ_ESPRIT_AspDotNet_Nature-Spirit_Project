using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class reclamationMap : EntityTypeConfiguration<reclamation>
    {
        public reclamationMap()
        {
            // Primary Key
            this.HasKey(t => t.id_Reclamation);

            // Properties
            this.Property(t => t.DTYPE)
                .IsRequired()
                .HasMaxLength(31);

            this.Property(t => t.Description_Reclamation)
                .HasMaxLength(255);

            this.Property(t => t.First_Name)
                .HasMaxLength(255);

            this.Property(t => t.Last_Name)
                .HasMaxLength(255);

            this.Property(t => t.Picture)
                .HasMaxLength(255);

            this.Property(t => t.Comment)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("reclamation", "base");
            this.Property(t => t.DTYPE).HasColumnName("DTYPE");
            this.Property(t => t.id_Reclamation).HasColumnName("id_Reclamation");
            this.Property(t => t.Date_Reclamation).HasColumnName("Date_Reclamation");
            this.Property(t => t.Description_Reclamation).HasColumnName("Description_Reclamation");
            this.Property(t => t.First_Name).HasColumnName("First_Name");
            this.Property(t => t.Last_Name).HasColumnName("Last_Name");
            this.Property(t => t.idReclamtionMember).HasColumnName("idReclamtionMember");
            this.Property(t => t.Picture).HasColumnName("Picture");
            this.Property(t => t.idReclamationPicture).HasColumnName("idReclamationPicture");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.idReclamationComment).HasColumnName("idReclamationComment");
            this.Property(t => t.admin_id_Member).HasColumnName("admin_id_Member");
            this.Property(t => t.member_id_Member).HasColumnName("member_id_Member");

            // Relationships
            this.HasOptional(t => t.member)
                .WithMany(t => t.reclamations)
                .HasForeignKey(d => d.admin_id_Member);
            this.HasOptional(t => t.member1)
                .WithMany(t => t.reclamations1)
                .HasForeignKey(d => d.member_id_Member);

        }
    }
}
