using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context)
        {
            _context = context;
        }


        //Implementing Interfaces


        public bool CountryExist(int countryId)
        {
            return _context.Countries
                .Any(x => x.Id == countryId);
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries
                .ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public Country GetCountryByName(string countryName)
        {
            return _context.Countries
                .Where(x => x.Name == countryName)
                .FirstOrDefault();
        }

        public Country GetCountryByOwnerId(int ownerId)
        {
            //var result = _context.Owners.Where(x => x.Id == ownerId).Select(x => x.Country).FirstOrDefault();
            return _context.Owners
                .Where(x => x.Id == ownerId)
                .Select(x => x.Country)
                .FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromACountry(int countryId)
        {
            //var result1 = _context.Countries.Where(x => x.Id == countryId).Select(x => x.Owners).ToList();
            //var result = _context.Owners.Where(x => x.Country.Id == countryId).ToList();
            return _context.Owners
                .Where(x => x.Country.Id == countryId)
                .ToList();
        }


        public bool CreateCountry(Country country)
        {
            _context.Add(country);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCountry(Country country)
        {
            _context.Update(country);
            return Save();
        }

        public bool DeleteCountry(Country country)
        {
            _context.Remove(country);
            return Save();
        }
    }
}
