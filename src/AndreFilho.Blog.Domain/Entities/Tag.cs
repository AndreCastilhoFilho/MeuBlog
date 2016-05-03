using System;
using System.Collections.Generic;

namespace AndreFilho.Blog.Domain.Entities
{
    public class Tag
    {
        public Tag()
        {
            TagId = Guid.NewGuid();
            Posts = new List<Post>();
        }

        public Guid TagId { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }
        public ICollection<Post> Posts { get; set; }


    }
}