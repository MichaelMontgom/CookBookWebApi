using CookBookApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        

        private readonly RecipesContext _context;

        public RecipesController(RecipesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Recipe> GetRecipes()
        {
            List<Recipe> recipes = _context.Recipes.Include(ingredients => ingredients.Ingredients).ToList();
            return recipes;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(Guid id)
        {
            var recipe = await _context.Recipes.FindAsync(id);

          

            if(recipe == null)
            {
                return NotFound();
            }

            return recipe;

        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipes(Recipe recipe)
        {


            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecipe", new { id = recipe.Id }, recipe);
        }


        [HttpPut]
        public async Task<ActionResult<Recipe>> PutRecipe(Guid id, Recipe recipe)
        {
            if(id != recipe.Id)
            {
                return BadRequest();
            }
            _context.Entry(recipe).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!_context.Recipes.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();


        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRecipe(Guid id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if(recipe == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipe);

            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
