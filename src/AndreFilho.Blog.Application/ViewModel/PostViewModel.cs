﻿using System;
using System.Collections.Generic;
using AndreFilho.Blog.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AndreFilho.Blog.Application.ViewModel
{
    public class PostViewModel
    {
        public PostViewModel()
        {
            PostId = Guid.NewGuid();
            Tags = new List<TagViewModel>();
        }

        [Key]
        public Guid PostId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Título")]
        [MaxLength(500, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(10, ErrorMessage = "Mínimo {0} caracteres")]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name = "Breve Descrição")]
        [Required(ErrorMessage = "Preencha o campo Breve Descrição")]
        [MaxLength(5000, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(50, ErrorMessage = "Mínimo {0} caracteres")]
        [AllowHtml]
        public string ShortDescription { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(5000, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(100, ErrorMessage = "Mínimo {0} caracteres")]
        [AllowHtml]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Meta")]
        public string Meta { get; set; }

        [Required]
        [Display(Name = "Url SEO")]
        public string SlugUrl { get; set; }

        [Display(Name = "Publicar")]
        public bool Published { get; set; }

        [ScaffoldColumn(false)]
        public DateTime PostedOn { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? Modified { get; set; }

        public  ICollection<TagViewModel> Tags { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage ="Selecione a Categoria")]
        public Guid CategoryId { get; set; }

        [ScaffoldColumn(false)]
        public CategoryViewModel Category { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public Guid? SelectedTag { get;set; }
        public IEnumerable<TagViewModel> TagList { get; set; }

    }
}