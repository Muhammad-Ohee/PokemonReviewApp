using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        

        // Implementing Interface

        public Review GetReview(int reviewId)
        {
            return _context.Reviews.Where(x => x.Id == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviewOfAPokemon(int pokemonId)
        {
            var result = _context.Reviews
                .Where(x => x.Pokemon.Id == pokemonId)
                .ToList();
            return result;
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public bool ReviewExist(int reviewId)
        {
            return _context.Reviews.Any(x => x.Id == reviewId);
        }

        public bool CreateReview(Review review)
        {
            _context.Add(review);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateReview(Review review)
        {
            _context.Update(review);
            return Save();
        }

        public bool DeleteReview(Review review)
        {
            _context.Remove(review);
            return Save();
        }

        public bool DeleteReviews(List<Review> reviews)
        {
            _context.RemoveRange(reviews);
            return Save();
        }
    }
}
