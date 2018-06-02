using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

using SignalR_WebApi.Hubs;

namespace SignalR_WebApi.Controllers
{
    [Route("api/price")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IHubContext<DataHub> dataHubContext;

        public ValuesController(IHubContext<DataHub> hubContext )
        {
            dataHubContext = hubContext;
        }

        // POST api/price
        [HttpPost]
        public IActionResult Post([FromBody] double updatedPrice)
        {
            dataHubContext.Clients.All.SendAsync("ReceiveData", updatedPrice);
            return Ok(true);
        }
    }
}
