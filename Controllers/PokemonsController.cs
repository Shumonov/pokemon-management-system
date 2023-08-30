using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PokemonEH.Data;
using PokemonEH.Models;
using PokemonEH.Services;
using Newtonsoft.Json.Linq;

namespace PokemonEH.Controllers
{
    public class PokemonsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly PokeApiService _pokeApiService;

        public PokemonsController(ApplicationDbContext context)
        {
            _context = context;
            _pokeApiService = new PokeApiService(); // Initialize the service
        }

        // GET: Pokemons
        public async Task<IActionResult> Index()
        {
            return _context.Pokemon != null ?
                    View(await _context.Pokemon.ToListAsync()) :
                    Problem("Entity set 'ApplicationDbContext.Pokemon'  is null.");
        }

        // GET: Pokemons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pokemon == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pokemon == null)
            {
                return NotFound();
            }

            var pokemon = await _context.Pokemon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pokemon == null)
            {
                return NotFound();
            }

            return View(pokemon);
        }

        // POST: Pokemons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pokemon == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pokemon'  is null.");
            }
            var pokemon = await _context.Pokemon.FindAsync(id);
            if (pokemon != null)
            {
                _context.Pokemon.Remove(pokemon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokemonExists(int id)
        {
            return (_context.Pokemon?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // New Action to Fetch data from PokeAPI
        private const int PageSize = 12;

        public async Task<IActionResult> FetchFromAPI(int page = 1)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                int offset = (page - 1) * PageSize;

                var response = await httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon?limit={PageSize}&offset={offset}");
                var allPokemonsData = JObject.Parse(response);
                var pokemons = allPokemonsData["results"].ToObject<List<PokemonAPIModel>>();

                // Populate the Id for each Pokemon
                for (int i = 0; i < pokemons.Count; i++)
                {
                    pokemons[i].Id = i + 1 + offset;  // Adjusting the ID based on page and offset
                }

                // Pass the current page to the view for the "Load More" button
                ViewBag.CurrentPage = page;

                return View(pokemons);
            }
        }



        [HttpPost]
        public async Task<IActionResult> AddToFavorites(string name, string imageUrl, int currentPage = 1)
        {
            if (!string.IsNullOrEmpty(name) && !_context.Pokemon.Any(p => p.Name == name))
            {
                Pokemon pokemonToAdd = new Pokemon
                {
                    Name = name,
                    ImageUrl = imageUrl
                };
                _context.Pokemon.Add(pokemonToAdd);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("FetchFromAPI", new { page = currentPage });
        }
    }
}
