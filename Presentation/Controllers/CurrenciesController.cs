using Application.Currencies.Dtos;
using Application.Currencies.Interfaces;
using Application.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrenciesController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }


        [HttpPost("ConvertFromCurrencyToAnother")]
        public async Task<ActionResult<ConvertCurrencyResponseDto>> ConvertFromCurrencyToAnother
                                                                   (ConvertCurrencyRequestDto convertCurrency)
        {
            return Ok(await _currencyService.ConvertFromCurrencyToAnother(convertCurrency));
        }


        [HttpGet]
        public async Task<ActionResult<PagedResponse<CurrencyDto>>> GetAll(int pageNumber = 1, int pageSize = 20)
        {
            return Ok(await _currencyService.GetAllAsync(pageNumber, pageSize));
        }


        [HttpPost]
        public async Task<ActionResult<CurrencyDto>> Create(CreateCurrencyDto entity)
        {
            return Ok(await _currencyService.CreateAsync(entity));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<CurrencyDto>> Update(Guid id, UpdateCurrencyDto entity)
        {
            return Ok(await _currencyService.UpdateAsync(id, entity));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _currencyService.DeleteAsync(id);
            return NoContent();
        }


        [HttpGet("GetCurrencyById/{id}")]
        public async Task<ActionResult<CurrencyDto>> GetCurrencyById(Guid id)
        {
            return Ok(await _currencyService.GetCurrencyById(id));
        }


        [HttpGet("GetCurrencyByName")]
        public async Task<ActionResult<PagedResponse<CurrencyDto>>> GetCurrencyByName(string name, int pageNumber = 1, int pageSize = 20)
        {
            return Ok(await _currencyService.GetCurrencyByName(name, pageNumber, pageSize));
        }


        [HttpGet("GetHighestCurrencies")]
        public async Task<ActionResult<PagedResponse<CurrencyDto>>> GetHighestCurrencies(int pageNumber = 1, int pageSize = 20)
        {
            return Ok(await _currencyService.GetHighestNCurrencies(pageNumber, pageSize));
        }


        [HttpGet("GetLowestCurrencies")]
        public async Task<ActionResult<PagedResponse<CurrencyDto>>> GetLowestCurrencies(int pageNumber = 1, int pageSize = 20)
        {
            return Ok(await _currencyService.GetLowestNCurrencies(pageNumber, pageSize));
        }


        [HttpGet("GetMostImprovedCurrenciesByDate")]
        public async Task<ActionResult<PagedResponse<CurrencyImprovementOrFallenDto>>> GetMostImprovedCurrenciesByDate([FromQuery]ImprovedCurrenciesByDateRequest 
                                                                                                                       improvedCurrenciesByDateRequest,
                                                                                                                       int pageNumber = 1, int pageSize = 20)
        {
            return Ok(await _currencyService.GetMostImprovedCurrenciesByDate(improvedCurrenciesByDateRequest, pageNumber, pageSize));
        }


        [HttpGet("GetLeastImprovedCurrenciesByDate")]
        public async Task<ActionResult<PagedResponse<CurrencyImprovementOrFallenDto>>> GetLeastImprovedCurrenciesByDate([FromQuery]ImprovedCurrenciesByDateRequest 
                                                                                                                        improvedCurrenciesByDateRequest,
                                                                                                                        int pageNumber = 1, int pageSize = 20)
        {
            return Ok(await _currencyService.GetLeastImprovedCurrenciesByDate(improvedCurrenciesByDateRequest, pageNumber, pageSize));
        }
    }
}
