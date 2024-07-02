using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Notifications.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<NotificationsHub, INotificationClient> _hubContext;
        
        // GET: api/<ValuesController>
        public MessageController(IHubContext<NotificationsHub,INotificationClient> hubContext)
        {
            _hubContext = hubContext;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async void Post([FromBody] string value)
        {
            await _hubContext.Clients.All.ReceiveNotification(value);
        }
    }
}
