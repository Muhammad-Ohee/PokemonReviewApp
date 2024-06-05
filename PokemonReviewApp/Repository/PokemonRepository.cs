using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        //Implementing Interfaces

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemon.Where(x => x.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.Where(x => x.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var rating = _context.Reviews.Where(x => x.Pokemon.Id == pokeId);

            if (rating.Count() <= 0)
            {
                return 0;
            }

            return ((decimal)rating.Sum(r => r.Rating)) / rating.Count();
        }

        public bool PokemonExist(int pokeId)
        {
            return _context.Pokemon.Any(x => x.Id == pokeId); ;
        }


        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(x => x.Id).ToList();
        }

        public bool CreatePokemon(Pokemon pokemon, int ownerId, int categoryId)
        {
            var pokmonOwnerEntity = _context.Owners
                .Where(x => x.Id == ownerId)
                .FirstOrDefault();
            var pokmonCategoryEntity = _context.Categories
                .Where(x => x.Id == categoryId)
                .FirstOrDefault();

            var pokemomOwner = new PokemonOwner()
            {
                Owner = pokmonOwnerEntity,
                Pokemon = pokemon
            };

            _context.Add(pokemomOwner);

            var pokemomCategory = new PokemonCategory()
            {
                Category = pokmonCategoryEntity,
                Pokemon = pokemon
            };

            _context.Add(pokemomCategory);

            _context.Add(pokemon);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePokemon(Pokemon pokemon, int ownerId, int categoryId)
        {
            _context.Update(pokemon);
            return Save();
        }

        public bool DeletePokemon(Pokemon pokemon)
        {
            _context.Remove(pokemon);
            return Save();
        }
    }
}
