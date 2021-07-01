using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookApi.Models
{
    public class Ingredient
    {
        public Guid Id { get; set; }

        public decimal Amount { get; set; }

        public string Unit { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

    }
}
