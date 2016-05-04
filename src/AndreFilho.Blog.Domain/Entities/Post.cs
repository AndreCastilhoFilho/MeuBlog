using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreFilho.Blog.Domain.Entities
{
    public class Post
    {
        
        public Post()
        {
            PostId = Guid.NewGuid();
            Tags = new List<Tag>();
        }

        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Meta { get; set; }
        public string SlugUrl { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

      

    }

    
}
