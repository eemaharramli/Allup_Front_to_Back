using System.Collections.Generic;

namespace AspNetPractise.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsMain { get; set; }
        public bool IsDeleted { get; set; }
        public Category Parent { get; set; }
        public List<Category> Children { get; set; }
    }
}