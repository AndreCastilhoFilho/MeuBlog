using AndreFilho.Blog.Domain.Entities;
using AndreFilho.Blog.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreFilho.Blog.Infra.Data.Context;
using Dapper;

namespace AndreFilho.Blog.Infra.Data.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {

        public PostRepository(BlogContext context)
            : base(context)
        {
        }

        public IEnumerable<Post> PostsByCategory(string categorySlug)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Posts p " +
                       " JOIN Categories c " +
                       "ON p.CategoryId = c.CategoryId " +                       
                       "WHERE ('' = @scategorySlug or  c.UrlSlug = @scategorySlug) and p.Published = @sPublished order by PostedOn desc";



            var posts = cn.Query<Post, Category,  Post>(sql,
               (p, c) =>
               {
                   p.Category = c;
                 
                   return p;
               }, new { scategorySlug = categorySlug ??"", sPublished = true }, splitOn: "PostId, CategoryId");

            foreach (Post p in posts)
                p.Tags = TagsFromPost(p.PostId).ToList();
            

            return posts.ToList();

        }

      private IEnumerable<Tag> TagsFromPost(Guid postId)
        {
            var cn = Db.Database.Connection;

            var sql = "SELECT pt.PostId, t.* from PostTagMap pt  left join  Tags t on pt.TagId = t.TagId "+
                " where pt.PostId = @spostId";


            var tags = cn.Query<Tag>(sql, new { spostId = postId });

            return tags; 
        }

        public Post PostByYearMonthAndTitle(int year, int month, string titleSlug)
        {
            return Search(p =>
            p.PostedOn.Year == year &&
            p.PostedOn.Month == month &&
            p.SlugUrl.Equals(titleSlug))
                .FirstOrDefault();

        }

      
       
        public IEnumerable<Post> PostsBySearch(string search)
        {
            return Search(p => p.Published &&
            (p.Title.Contains(search) ||
            p.Category.Name.Equals(search) ||
            p.Tags.Any(t => t.Name.Equals(search))))
                              .OrderByDescending(p => p.PostedOn)                            
                              .ToList();
        }

        public IEnumerable<Post> PostsByTag(string tagSlug)
        {
            return Search(p => p.Published && p.Tags.Any(t => t.UrlSlug.Equals(tagSlug)))
                             .OrderByDescending(p => p.PostedOn)                            
                             .ToList();        }


        public override IEnumerable<Post> GetAll()
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Posts";

            return cn.Query<Post>(sql);
        }

        public Post PostByUrlSlug(string urlSlug)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Posts p " +
                       " LEFT JOIN Categories c " +
                       "ON p.PostId = c.CategoryId " +
                       "WHERE p.SlugUrl = @surlSlug and p.Published = @sPublished";

            var post = cn.Query<Post, Category, Post>(sql,
               (p, c) =>
               {
                   p.Category = c;                  
                   return p;
               }, new { surlSlug = urlSlug , sPublished  = true}, splitOn: "PostId, CategoryId");

            return post.SingleOrDefault();
        }

    
    }
}
