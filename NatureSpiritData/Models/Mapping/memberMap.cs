using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class memberMap : EntityTypeConfiguration<member>
    {
        public memberMap()
        {
            // Primary Key
            this.HasKey(t => t.id_Member);

            // Properties
            this.Property(t => t.DTYPE)
                .IsRequired()
                .HasMaxLength(31);

            this.Property(t => t.Email)
                .HasMaxLength(255);

            this.Property(t => t.First_Name)
                .HasMaxLength(255);

            this.Property(t => t.Last_Name)
                .HasMaxLength(255);

            this.Property(t => t.Login)
                .HasMaxLength(255);

            this.Property(t => t.Password)
                .HasMaxLength(255);

            this.Property(t => t.Profil_Picture) 
                .HasMaxLength(255);

           /* this.Property(t => t.Role)
                .HasMaxLength(255); */

            this.Property(t => t.Num_Journalist_Card)
                .HasMaxLength(255);

            this.Property(t => t.Num_Sailor)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("member", "base");
            this.Property(t => t.DTYPE).HasColumnName("DTYPE");
            this.Property(t => t.id_Member).HasColumnName("id_Member");
            this.Property(t => t.Date_Birth).HasColumnName("Date_Birth");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.First_Name).HasColumnName("First_Name");
            this.Property(t => t.Last_Name).HasColumnName("Last_Name");
            this.Property(t => t.Login).HasColumnName("Login");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Profil_Picture).HasColumnName("Profil_Picture");
            //this.Property(t => t.Role).HasColumnName("Role");
            this.Property(t => t.balance).HasColumnName("balance");
            this.Property(t => t.Num_Journalist_Card).HasColumnName("Num_Journalist_Card");
            this.Property(t => t.Num_Sailor).HasColumnName("Num_Sailor");
            this.Property(t => t.admin_id_Member).HasColumnName("admin_id_Member");
            this.Property(t => t.newsletter_id_Newsletter).HasColumnName("newsletter_id_Newsletter");
            this.Property(t => t.reclamationMember_id_Reclamation).HasColumnName("reclamationMember_id_Reclamation");

            // Relationships
            this.HasOptional(t => t.newsletter)
                .WithMany(t => t.members)
                .HasForeignKey(d => d.newsletter_id_Newsletter);
            this.HasOptional(t => t.member2)
                .WithMany(t => t.member1)
                .HasForeignKey(d => d.admin_id_Member);
            this.HasOptional(t => t.reclamation)
                .WithMany(t => t.members)
                .HasForeignKey(d => d.reclamationMember_id_Reclamation);  

        }
    }
}
