using System.Collections.Generic;
using AspNetPractise.Models;

namespace AspNetPractise.ViewModels
{
    public class CategoryViewModel
    {
        public Category SelectedCategory { get; set; }
        public List<Category> Categories { get; set; }
    }
}