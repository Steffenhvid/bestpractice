using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using bp.domain.Interfaces;
using bp.domain.Models;

namespace bp.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentTypeController(
        ILogger<AssignmentTypeController> logger,
        ICreate<AssignmentType> create,
        IGet<AssignmentType> get,
        IUpdate<AssignmentType> update
        ) : BaseController<AssignmentType>(logger, create, get, update)
    {
    }
}