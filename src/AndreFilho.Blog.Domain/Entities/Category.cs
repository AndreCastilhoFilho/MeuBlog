using System;
using System.Collections.Generic;

namespace AndreFilho.Blog.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            CategoryId = Guid.NewGuid();
            Posts = new List<Post>();
        }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }
        public string UrlSlug { get; set; }

        public virtual ICollection<Post> Posts { get; set; }


    }
}