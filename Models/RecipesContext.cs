using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookApi.Models
{
    public class RecipesContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("CookBook");
        }


        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<GroceryList> GroceryLists { get; set; }
    }
}
