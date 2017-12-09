using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace NatureSpiritData.Models.Mapping
{
    public class membernewMap : EntityTypeConfiguration<membernew>
    {
        public membernewMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id_Member, t.Id_News, t.date_Of_Comment });

            // Properties
            this.Property(t => t.Id_Member)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Id_News)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Comment)
                .HasMaxLength(255);
            
            // Table & Column Mappings
            this.ToTable("membernews", "base");
            this.Property(t => t.Id_Member).HasColumnName("Id_Member");
            this.Property(t => t.Id_News).HasColumnName("Id_News");
            this.Property(t => t.date_Of_Comment).HasColumnName("date_Of_Comment");
            this.Property(t => t.title_selected_news).HasColumnName("title_selected_news");
            this.Property(t => t.description_selected_news).HasColumnName("description_selected_news");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.like_dislike).HasColumnName("like_dislike");
            this.Property(t => t.State_News).HasColumnName("State_News");

            // Relationships
            this.HasRequired(t => t.member)
                .WithMany(t => t.membernews)
                .HasForeignKey(d => d.Id_Member);
            this.HasRequired(t => t.news)
                .WithMany(t => t.membernews)
                .HasForeignKey(d => d.Id_News);

        }
    }
}
