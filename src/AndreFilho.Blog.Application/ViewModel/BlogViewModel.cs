using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreFilho.Blog.Application.ViewModel
{
    public class BlogViewModel
    {
        public BlogViewModel()
        {
            PostId = Guid.NewGuid();
        }
        public Guid PostId { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public DateTime PostedOn { get; set; }

        public DateTime? Modified { get; set; }

        public string SlugUrl { get; set; }

    }
}
