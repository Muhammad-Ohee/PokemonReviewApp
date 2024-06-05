using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IReviewerRepository
    {
        // Get Request
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int reviewerId);
        ICollection<Review> GetReviewsByReviewer(int reviewerId);
        bool ReviewerExist(int reviewerId);

        // Create Request
        bool CreateReviewer(Reviewer reviewer);

        // Update Request
        bool UpdateReviewer(Reviewer reviewer);

        // Delete Request
        bool DeleteReviewer(Reviewer reviewer);

        bool Save();
    }
}
