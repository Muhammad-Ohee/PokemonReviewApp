using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IOwnerRepository
    {
        // Get Request
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        ICollection<Owner> GetOwnerOfAPokemon(int pokemonId);
        ICollection<Pokemon> GetPokemonByOwner(int ownerId);
        bool OwnerExist(int ownerId);

        // Create Request
        bool CreateOwner(Owner owner);

        // Update Request
        bool UpdateOwner(Owner owner);

        // Delete Owner
        bool DeleteOwner(Owner owner);

        bool Save();
    }
}
