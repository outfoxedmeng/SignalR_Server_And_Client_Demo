using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IHubContext<MsgHub> _hubContext;

        public MessagesController(IHubContext<MsgHub> hubContext)
        {
            _hubContext = hubContext;
        }
        [HttpPost("send-msg")]
        public async Task<IActionResult> SendMessage(string msg)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMsg", msg);
            return Ok();
        }
    }
}
