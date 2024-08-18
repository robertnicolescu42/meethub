using MeetHub.API.Models;
using MeetHub.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MeetHub.API.Controllers
{
    /// <summary>
    /// The controller for currency actions
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        #region Fields

        private const string _cmGetByIdName = "GetCurrency";
        private readonly ICurrencyRepository _rmCurrencyRepository;

        #endregion Fields

        #region Constructor

        public CurrencyController(ICurrencyRepository currencyRepository)
        {
            _rmCurrencyRepository = currencyRepository ?? throw new ArgumentNullException(nameof(currencyRepository));
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets all currencys from repository
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpHead]
        public async Task<ActionResult<IEnumerable<CurrencyModel>>> GetAllCurrencies()
        {
            var currencies = _rmCurrencyRepository
                .GetAllCurrenciesAsync()
                .GetAwaiter()
                .GetResult();

            return Ok(currencies);
        }

        /// <summary>
        /// Gets a specific currency using id
        /// </summary>
        /// <param name="id"> The id of the currency </param>
        /// <returns></returns>
        [HttpGet("{id}", Name = _cmGetByIdName)]
        public async Task<ActionResult<CurrencyModel>> GetCurrency(int id)
        {
            var currency = _rmCurrencyRepository
                .GetCurrencyByIdAsync(id)
                .GetAwaiter()
                .GetResult();

            return Ok(currency);
        }

        /// <summary>
        /// Adds new currency
        /// </summary>
        /// <param name="currency"> The currency model </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddCurrency(CurrencyModel currency)
        {
            _rmCurrencyRepository.AddCurrency(currency);
            return CreatedAtRoute(_cmGetByIdName, new { id = currency.Id }, currency);
        }

        /// <summary>
        /// Updates an existing currency
        /// </summary>
        /// <param name="currency"> The updated currency model </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCurrency(CurrencyModel currency)
        {
            _rmCurrencyRepository.UpdateCurrency(currency);
            return NoContent();
        }

        /// <summary>
        /// Deletes an existion currency
        /// </summary>
        /// <param name="id"> The currency id </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(int id)
        {
            _rmCurrencyRepository.DeleteCurrency(id);
            return NoContent();
        }

        #endregion Methods

    }
}
