using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreFilho.Blog.Application.ViewModel
{
    class CategoriesAndTagsViewModel
    {

        public IEnumerable<TagViewModel> Tags { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
