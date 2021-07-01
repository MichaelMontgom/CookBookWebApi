using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookApi.Models
{
    public class Recipe
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string Instructions { get; set; }

        public string CookTime { get; set; }
        public string CookTemp { get; set; }

        public string Difficulty { get; set; }

        public DateTime DateCreated { get; set; }

        public string ImageUrl { get; set; }

        public virtual List<Ingredient> Ingredients { get; set; }
    }
}
