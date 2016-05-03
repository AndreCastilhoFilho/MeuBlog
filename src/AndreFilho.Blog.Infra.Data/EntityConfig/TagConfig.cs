using System.Data.Entity.ModelConfiguration;
using AndreFilho.Blog.Domain.Entities;

namespace AndreFilho.Blog.Infra.Data.EntityConfig
{
    public class TagConfig : EntityTypeConfiguration<Tag>
    {

        public TagConfig()
        {
            HasKey(t => t.TagId);

            Property(t => t.Description)
                .HasMaxLength(200);

            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.UrlSlug)
                .HasMaxLength(50)
                .IsRequired();

            HasMany(t => t.Posts)
                  .WithMany(p=>p.Tags)
                  .Map(me =>
                  {
                      me.MapLeftKey("TagId");
                      me.MapRightKey("PostId");
                      me.ToTable("PostTagMap");
                  });


        }

    }
}