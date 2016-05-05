using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreFilho.Blog.Application.ViewModel
{
   public  class SideBarViewModel
    {

        public SideBarViewModel()
        {
            Categories = new List<CategoryViewModel>();
            Tags = new List<TagViewModel>();

        }
        
        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }

    }
}
