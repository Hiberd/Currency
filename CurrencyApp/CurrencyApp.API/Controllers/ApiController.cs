using CurrencyApp.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyApp.API.Controllers
{
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private readonly ICurrencyServices _currencyServices;

        public ApiController(ILogger<ApiController> logger, ICurrencyServices currencyServices)
        {
            _logger = logger;
            _currencyServices = currencyServices;
        }

        [HttpGet]
        [Route("currencies")]
        public async Task<IActionResult> GetAll(int pageSize = 5, int tablePage = 1)
        {
            var currencies = await _currencyServices.GetAll(tablePage, pageSize);

            return Ok(currencies);
        }

        [HttpGet]
        [Route("currency")]
        public async Task<IActionResult> Get(string currencyId)
        {
            var currency = await _currencyServices.Get(currencyId);

            if (currency.IsFailure)
            {
                _logger.LogError(currency.Error);
                return BadRequest(currency.Error);
            }

            return Ok(currency.Value);
        }

        /// <summary>
	    /// Этот метод добавлен для простоты обновления данных.
		/// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate()
        {
            await _currencyServices.CreateOrUpdate();

            return Ok();
        }
    }
}
