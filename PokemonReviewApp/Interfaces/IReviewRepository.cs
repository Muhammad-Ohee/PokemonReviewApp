using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IReviewRepository
    {
        // Get Request
        ICollection<Review> GetReviews();
        Review GetReview(int reviewId);
        ICollection<Review> GetReviewOfAPokemon(int pokemonId);
        bool ReviewExist(int reviewId);

        // Create Request
        bool CreateReview(Review review);

        // Update Request
        bool UpdateReview(Review review);

        // Delete Request
        bool DeleteReview(Review review);
        bool DeleteReviews(List<Review> reviews);

        bool Save();
    }
}
