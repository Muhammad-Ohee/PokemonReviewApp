using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        // Get Request
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByName(string countryName);
        Country GetCountryByOwnerId(int ownerId);
        ICollection<Owner> GetOwnersFromACountry(int countryId);
        bool CountryExist(int countryId);

        // Create Request
        bool CreateCountry(Country country);

        // Update Request
        bool UpdateCountry(Country country);

        // Delete Request
        bool DeleteCountry(Country country);

        bool Save();
    }
}
