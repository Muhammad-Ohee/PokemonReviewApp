using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }


        //Implementing Interfaces
        public bool CategoryExist(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(x => x.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            //var result = _context.PokemonCategories.Where(x => x.CategoryId == categoryId)
                //.Select(x => x.Pokemon).ToList();
            return _context.PokemonCategories.Where(x => x.CategoryId == categoryId)
                .Select(x => x.Pokemon).ToList();
        }



        public bool CreateCategory(Category category)
        {
            // Change Tracker
            // Adding, updating, modifying
            // Connected vs disconnected state
            // EntityState.Added 
            
            _context.Add(category);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;

        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return Save();
        }
    }
}
