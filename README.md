# SignalR-WebAPI-Demo
Sample application demonstrating use of SignalR from a WebAPI to update clients in real time.

### How to run
```bash
cd <project_folder>
dotnet build
dotnet run
```

### Using SignalR hubs in Controllers
To access SignalR hubs from controllers, pass `IHubContext<YourHub>` as a paramter to the controller's constructor and the dependency injector will take care of passing the hub's context during runtime

#### Example:

```C#
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
```

#### Demo video:
[![Video](https://img.youtube.com/vi/kjuIoWJLiwQ/0.jpg)](https://www.youtube.com/watch?v=kjuIoWJLiwQ)
