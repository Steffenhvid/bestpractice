using Microsoft.AspNetCore.Mvc;
using bp.domain.Interfaces;
using bp.domain.Models;

namespace bp.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ILogger<ProductController> logger, ICreate<Product> create, IGet<Product> get, IUpdate<Product> update) : BaseController<Product>(logger, create, get, update)
    {
    }
}