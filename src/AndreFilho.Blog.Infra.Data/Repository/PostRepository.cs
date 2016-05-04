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

        public IEnumerable<Post> PostByCategoryAndPagination(string categorySlug, int pageNo, int pageSize)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Posts p " +
                       " JOIN Categories c " +
                       "ON p.PostId = c.CategoryId " +
                        "LEFT JOIN Tags t " +
                       "ON p.TagId = t.TagId " +
                       "WHERE c.UrlSlug = @scategorySlug and p.Published = true";

            var posts = cn.Query<Post, Category, Tag, Post>(sql,
               (p, c, t) =>
               {
                   p.Category = c;
                   p.Tags.Add(t);
                   return p;
               }, new { scategorySlug = categorySlug }, splitOn: "PostId, CategoryId, TagId");

            return posts.OrderByDescending(p => p.PostedOn)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize)
                            .ToList();


        }

        public Post PostByYearMonthAndTitle(int year, int month, string titleSlug)
        {
            return Search(p =>
            p.PostedOn.Year == year &&
            p.PostedOn.Month == month &&
            p.SlugUrl.Equals(titleSlug))
                .FirstOrDefault();

        }

        public IEnumerable<Post> PostsByPagination(int pageNo, int pageSize)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Posts p " +
                       " JOIN Categories c " +
                       "ON p.PostId = c.CategoryId " +
                        "LEFT JOIN Tags t " +
                       "ON p.TagId = t.TagId " +
                       "WHERE  p.Published = @spublished ";


            var posts = cn.Query<Post, Category, Tag, Post>(sql,
               (p, c, t) =>
               {
                   p.Category = c;
                   p.Tags.Add(t);
                   return p;
               }, new { spublished = true }, splitOn: "PostId, CategoryId, TagId");

            return posts.OrderByDescending(p => p.PostedOn)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize)
                            .ToList();


        }

        public IEnumerable<Post> PostsByPaginationAndSorting(int pageNo, int pageSize, string sortColumn, bool sortByAscending)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> PostsBySearchAndPagination(string search, int pageNo, int pageSize)
        {
            return Search(p => p.Published &&
            (p.Title.Contains(search) ||
            p.Category.Name.Equals(search) ||
            p.Tags.Any(t => t.Name.Equals(search))))
                              .OrderByDescending(p => p.PostedOn)
                              .Skip(pageNo * pageSize)
                              .Take(pageSize)
                              .ToList();

        }

        public IEnumerable<Post> PostsByTagAndPagination(string tagSlug, int pageNo, int pageSize)
        {
            return Search(p => p.Published && p.Tags.Any(t => t.UrlSlug.Equals(tagSlug)))
                             .OrderByDescending(p => p.PostedOn)
                             .Skip(pageNo * pageSize)
                             .Take(pageSize)
                             .ToList();
        }


        public override IEnumerable<Post> GetAll()
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Posts";

            return cn.Query<Post>(sql);
        }
    }
}
