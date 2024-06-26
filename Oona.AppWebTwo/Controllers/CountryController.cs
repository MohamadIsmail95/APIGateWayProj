using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Oona.AppWebTwo.Application.Interfaces.ICountryServices;
using Oona.AppWebTwo.Application.Interfaces.UnitOfWorkServices;
using Oona.AppWebTwo.Core.Domain.Dtos;
using Oona.AppWebTwo.Core.Domain.Entities;

namespace Oona.AppWebTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        private readonly IUnitOfWorkService _unitOfWorkService;

        public CountryController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ApiRequestFilter input)
        {
            var response = await _unitOfWorkService.CountryServices.GetOrCreateAsync<ApiResponse>
                ("countryCached",await _unitOfWorkService.CountryServices.GetLisCountries(input),null);
            return Ok(response);
        }
    }
}
