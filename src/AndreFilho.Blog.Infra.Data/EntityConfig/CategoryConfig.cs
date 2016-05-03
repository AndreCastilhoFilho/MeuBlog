using System.Data.Entity.ModelConfiguration;
using AndreFilho.Blog.Domain.Entities;

namespace AndreFilho.Blog.Infra.Data.EntityConfig
{
    public class CategoryConfig : EntityTypeConfiguration<Category>
    {

        public CategoryConfig()
        {
            HasKey(c => c.CategoryId);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Description)
                .HasMaxLength(200);
            
            


            ToTable("Categories");
        }
         
    }
}