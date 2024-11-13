using Microsoft.AspNetCore.Mvc;
using bp.domain.Interfaces;
using bp.domain.Models;

namespace bp.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(
        ILogger<CustomerController> logger,
        ICreate<Customer> create,
        IGet<Customer> get,
        IUpdate<Customer> update
        ) : BaseController<Customer>(logger, create, get, update)
    {
    }
}