using Microsoft.AspNetCore.Mvc;
using bp.domain.Interfaces;
using bp.domain.Models;

namespace bp.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController(
        ILogger<AssignmentController> logger,
        ICreate<Assignment> create,
        IGet<Assignment> get,
        IUpdate<Assignment> update
        ) : BaseController<Assignment>(logger, create, get, update)
    {
    }
}