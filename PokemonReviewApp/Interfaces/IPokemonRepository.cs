using System.Diagnostics.Eventing.Reader;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IPokemonRepository
    {
        // Get Pokemon
        ICollection<Pokemon> GetPokemons();

        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        decimal GetPokemonRating(int pokeId);
        bool PokemonExist (int pokeId);

        // Create Pokemon
        bool CreatePokemon(Pokemon pokemon, int ownerId, int categoryId);

        // Update Request
        bool UpdatePokemon(Pokemon pokemon, int ownerId, int categoryId);

        // Delete Request
        bool DeletePokemon(Pokemon pokemon);

        bool Save();
    }
}
