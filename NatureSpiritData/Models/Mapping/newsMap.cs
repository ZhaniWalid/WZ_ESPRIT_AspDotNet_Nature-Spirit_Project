using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class newsMap : EntityTypeConfiguration<news>
    {
        public newsMap()
        {
            // Primary Key
            this.HasKey(t => t.idNews);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.picture)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("news", "base");
            this.Property(t => t.idNews).HasColumnName("idNews");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.picture).HasColumnName("picture");
            this.Property(t => t.video).HasColumnName("video");
            this.Property(t => t.like).HasColumnName("like");
            this.Property(t => t.comment).HasColumnName("comment");
            this.Property(t => t.admin_id_Member).HasColumnName("admin_id_Member");   
            this.Property(t => t.topic_idTopic).HasColumnName("topic_idTopic");       
             
            // Relationships 
            this.HasOptional(t => t.member) 
                .WithMany(t => t.news)
                .HasForeignKey(d => d.admin_id_Member);
            this.HasOptional(t => t.topic)
                .WithMany(t => t.news)
                .HasForeignKey(d => d.topic_idTopic);
                      
        }
    }
}
