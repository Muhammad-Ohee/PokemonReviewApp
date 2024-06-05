using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        // Implementing Interfaces

        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.Where(x => x.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners
                .ToList();
        }

        public ICollection<Owner> GetOwnerOfAPokemon(int pokemonId)
        {
            return _context.PokemonOwners
                .Where(x=> x.Pokemon.Id == pokemonId)
                .Select(x => x.Owner)
                .ToList();
        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
        {
            return _context.PokemonOwners
                .Where(x => x.Owner.Id == ownerId)
                .Select(x => x.Pokemon)
                .ToList();
        }

        /*public bool OwnerExist(int ownerId)
        {
            return _context.Owners.Any(x => x.Id == ownerId);
        }*/

        public bool OwnerExist(int ownerId)
        {
            return _context.Owners.Any(o => o.Id == ownerId);
        }

        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOwner(Owner owner)
        {
            _context.Update(owner);
            return Save();
        }

        public bool DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            return Save();
        }
    }
}
