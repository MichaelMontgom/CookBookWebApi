using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookApi.Models
{
    public class GroceryList
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public HashSet<Ingredient> Ingredients { get; set; }
    }
}
