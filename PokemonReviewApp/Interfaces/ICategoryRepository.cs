using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICategoryRepository
    {
        // Get Request
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonByCategory(int categoryId);
        bool CategoryExist(int id);

        // Create Request
        bool CreateCategory(Category category);

        // Update Request
        bool UpdateCategory(Category category);

        // Delete Request
        bool DeleteCategory(Category category);


        bool Save();
    }
}
