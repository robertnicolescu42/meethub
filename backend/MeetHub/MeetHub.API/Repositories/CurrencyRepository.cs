using AutoMapper;
using MeetHub.API.Context;
using MeetHub.API.Entities;
using MeetHub.API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MeetHub.API.Repositories
{
    /// <summary>
    /// The currency repository interface
    /// </summary>
    public interface ICurrencyRepository
    {
        #region Methods

        /// <summary>
        /// Gets all currencies from database asynconous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CurrencyModel>> GetAllCurrenciesAsync();

        /// <summary>
        /// Gets currency from database asyncronous
        /// </summary>
        /// <param name="currencyId"> The currency id </param>
        /// <returns></returns>
        Task<CurrencyModel> GetCurrencyByIdAsync(int currencyId);

        /// <summary>
        /// Adds currency to database
        /// </summary>
        /// <param name="currency"> The currency model </param>
        void AddCurrency(CurrencyModel currency);

        /// <summary>
        /// Update the currency from dataabase
        /// </summary>
        /// <param name="currency"> The updated currency model</param>
        void UpdateCurrency(CurrencyModel currency);

        /// <summary>
        /// Removes currency from database
        /// </summary>
        /// <param name="currencyId"> The currency id</param>
        void DeleteCurrency(int currencyId);

        #endregion Methods
    }

    /// <summary>
    /// The currency repository implementation class
    /// </summary>
    public class CurrencyRepository : ICurrencyRepository
    {
        #region Fields

        private readonly MeetHubDatabaseContext _rmDatabaseContext;
        private readonly IMapper _rmMapper;

        #endregion Fields

        #region Constructor

        public CurrencyRepository(MeetHubDatabaseContext databaseContext, IMapper mapper)
        {
            _rmDatabaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
            _rmMapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all currencies from database asynconous
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CurrencyModel>> GetAllCurrenciesAsync()
        {
            var currencies = await _rmDatabaseContext.Currencies.ToListAsync();
            return _rmMapper.Map<IEnumerable<CurrencyModel>>(currencies);
        }

        /// <summary>
        /// Gets currency from database asyncronous
        /// </summary>
        /// <param name="currencyId"> The currency id </param>
        /// <returns></returns>
        public async Task<CurrencyModel> GetCurrencyByIdAsync(int currencyId)
        {
            var currency = await _rmDatabaseContext.Currencies.FirstOrDefaultAsync(currency => currency.Id == currencyId);
            return _rmMapper.Map<CurrencyModel>(currency);
        }

        /// <summary>
        /// Adds currency to database
        /// </summary>
        /// <param name="currency"> The currency model </param>
        public void AddCurrency(CurrencyModel currency)
        {
            try
            {
                var inserting_currency = _rmMapper.Map<Currency>(currency);
                _rmDatabaseContext.Currencies.Add(inserting_currency);
                _rmDatabaseContext.SaveChanges();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the inserting operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Updates the currency from dataabase
        /// </summary>
        /// <param name="currency"> The updated currency model</param>
        public void UpdateCurrency(CurrencyModel currency)
        {
            try
            {
                var updating_currency = _rmMapper.Map<Currency>(currency);
                _rmDatabaseContext.Currencies.Update(updating_currency);
                _rmDatabaseContext.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the updating operation: \n" + ex.Message);
            }
        }

        /// <summary>
        /// Removes currency from database
        /// </summary>
        /// <param name="currencyId"> The currency id</param>
        public async void DeleteCurrency(int currencyId)
        {
            try
            {
                var currency = await _rmDatabaseContext.Currencies.FirstOrDefaultAsync(curr => curr.Id == currencyId);
                _rmDatabaseContext.Currencies.Remove(currency);
                _rmDatabaseContext.SaveChanges();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("There was an issue with the removing operation: \n" + ex.Message);
            }
        }

        #endregion Methods
    }
}
