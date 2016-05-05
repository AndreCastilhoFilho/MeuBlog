using System;
using System.ComponentModel.DataAnnotations;

namespace AndreFilho.Blog.Application.ViewModel
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            CategoryId = Guid.NewGuid();
         
        }
        public Guid CategoryId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Preencha o campo Nome ")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(10, ErrorMessage = "Mínimo {0} caracteres")]
        public string Name { get; set; }

        [Display(Name = "Descrição")]
        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        public string Description { get; set; }

        public string UrlSlug { get; set; }
             

    }
}