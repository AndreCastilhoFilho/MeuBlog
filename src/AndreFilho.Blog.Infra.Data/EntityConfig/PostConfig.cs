using System.Data.Entity.ModelConfiguration;
using AndreFilho.Blog.Domain.Entities;

namespace AndreFilho.Blog.Infra.Data.EntityConfig
{
    public class PostConfig : EntityTypeConfiguration<Post>
    {
        public PostConfig()
        {
            HasKey(p => p.PostId);

            Property(p => p.Title)
                .HasMaxLength(500)
                .IsRequired();

            Property(p => p.ShortDescription)
                .HasMaxLength(5000)
                .IsRequired();

            Property(p => p.Description)
                .HasMaxLength(5000)
                .IsRequired();
            
            Property(p => p.Meta)
                .HasMaxLength(1000)
                .IsRequired();

            Property(p => p.SlugUrl)
                .HasMaxLength(200)
                .IsRequired();

            Property(p => p.Published)
               .IsRequired();

            Property(p => p.PostedOn)
              .IsRequired();

            Property(p => p.Modified);


            HasRequired(p => p.Category)
                .WithMany(c=>c.Posts)
                .HasForeignKey(p=>p.CategoryId)
                .WillCascadeOnDelete()
                ; 


            HasMany(c => c.Tags)
                .WithMany(t=> t.Posts)
                .Map(me =>
                {
                    me.MapLeftKey("PostId");
                    me.MapRightKey("TagId");
                    me.ToTable("PostTagMap");
                });

           
            ToTable("Posts");

        }

    }
}