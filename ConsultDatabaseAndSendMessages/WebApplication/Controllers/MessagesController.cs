using MessagesApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MessagesApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("Messages")]
    public class MessagesController : ControllerBase
    {
        private readonly ISendMessages _sendMessages;
        private ILogger<MessagesController> _logger;
        public MessagesController(ILogger<MessagesController> logger, ISendMessages sendMessages)
        {
            _sendMessages= sendMessages;
            _logger = logger;
        }

        [HttpGet("/statements/{accountNumber}")]
        public async Task<IActionResult>SendStatement(long accountNumber)
        {
            try
            {
                _logger.LogInformation($"Begin routine at: {DateTime.Now}");
                var message = await _sendMessages.GetStatement(accountNumber);
                _logger.LogInformation($"End routine at: {DateTime.Now}");
                return Ok(message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}