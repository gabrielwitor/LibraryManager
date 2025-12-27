using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class LibraryManagerBaseController : ControllerBase
    {
    }
}
