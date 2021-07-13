using CookBookApi.Models;
using Microsoft.AspNetCore.Http;
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
    public class GroceryListsController : ControllerBase
    {


        private readonly RecipesContext _context;

        public GroceryListsController(RecipesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<GroceryList> GetGroceryLists()
        {
            return _context.GroceryLists.ToList();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GroceryList>> GetGroceryList(Guid id)
        {
            var groceryList = await _context.GroceryLists.FindAsync(id);



            if (groceryList == null)
            {
                return NotFound();
            }

            return groceryList;

        }



        [HttpPost]
        public async Task<ActionResult<GroceryList>> PostGroceryList(GroceryList groceryList)
        {


            _context.GroceryLists.Add(groceryList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroceryList", new { id = groceryList.Id }, groceryList);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GroceryList>> PutGroceryList(Guid id, GroceryList groceryList)
        {
            if (id != groceryList.Id)
            {
                return BadRequest();
            }
            _context.Entry(groceryList).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.GroceryLists.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(groceryList);


        }


        [HttpDelete]
        public async Task<IActionResult> DeleteGroceryList(Guid id)
        {
            var groceryList = await _context.GroceryLists.FindAsync(id);
            if (groceryList == null)
            {
                return NotFound();
            }

            _context.GroceryLists.Remove(groceryList);

            await _context.SaveChangesAsync();

            return Ok();
        }



    }
}
