using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class topicMap : EntityTypeConfiguration<topic>
    {
        public topicMap()
        {
            // Primary Key
            this.HasKey(t => t.idTopic);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.title)
                .HasMaxLength(255);

            this.Property(t => t.typeTopic)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("topic", "base");
            this.Property(t => t.idTopic).HasColumnName("idTopic");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.typeTopic).HasColumnName("typeTopic");
            this.Property(t => t.admin_id_Member).HasColumnName("admin_id_Member");

            // Relationships
            this.HasOptional(t => t.member)
                .WithMany(t => t.topics)
                .HasForeignKey(d => d.admin_id_Member);

        }
    }
}
