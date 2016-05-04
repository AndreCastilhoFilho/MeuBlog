using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AndreFilho.Blog.Application.ViewModel
{
    public class TagViewModel
    {
        public TagViewModel()
        {
            TagId = Guid.NewGuid();
            Posts = new List<PostViewModel>();
        }

        public Guid TagId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Preencha o campo Nome ")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(10, ErrorMessage = "Mínimo {0} caracteres")]
        public string Name { get; set; }

        [Display(Name = "Url SEO")]
        [Required(ErrorMessage = "Preencha o campo Nome ")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string UrlSlug { get; set; }

        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        public string Description { get; set; }
        
        public ICollection<PostViewModel> Posts { get; set; }


    }
}