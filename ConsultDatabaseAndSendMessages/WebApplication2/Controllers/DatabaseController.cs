using DatabaseApi.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("customer")]
    public class DatabaseController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;

        public DatabaseController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        [HttpGet("transactions/")]
        public async Task<IActionResult> CustomerTransactions([FromQuery]long accountnumber)
        {
            try
            {
                var result = await _transactionsService.GetCustomerTransactions(accountnumber);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}