using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AndreFilho.Blog.Domain.Entities;
using AndreFilho.Blog.Infra.Data.EntityConfig;

namespace AndreFilho.Blog.Infra.Data.Context
{
    public class BlogContext : DbContext
    {

        public BlogContext()
            : base("DefaultConnection")
        {
            
        }    

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p=>p.Name == p.ReflectedType.Name + "Id")
                .Configure(p=>p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));


            modelBuilder.Configurations.Add(new PostConfig());
            modelBuilder.Configurations.Add(new TagConfig());
            modelBuilder.Configurations.Add(new CategoryConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}