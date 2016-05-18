using AndreFilho.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreFilho.Blog.Domain.Interfaces.Services
{
    public interface IPostService : IDisposable
    {
        Post Add(Post obj);
        Post GetById(Guid id);
        IEnumerable<Post> GetAll();
        Post Update(Post obj);
        void Remove(Guid id);       
        IEnumerable<Post> PostsByTag(string tagSlug);

      
        IEnumerable<Post> PostsByCategory(string slug);

        IEnumerable<Post> PostsBySearch(string search);
      
        Post PostByYearMonthAndTitle(int year, int month, string titleSlug);
        Post PostByUrlSlug(string urlSlug);

        int TotalPosts(bool checkIsPublished = true);
        int TotalPostsForTag(string tagSlug);
        int TotalPostsForSearch(string search);
        IEnumerable<Post> GetPostsBySearchCategoryAndTag(string search, string categoryUrl, string tagUrl);

        Post RemoveTagFromPost(Guid TagId, Guid PostId);
        Post AddTagToPost(Guid TagId, Guid PostId);

        IEnumerable<Tag> GetAllTags();
    }
}
