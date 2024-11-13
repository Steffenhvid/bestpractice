using Microsoft.AspNetCore.Mvc;
using bp.domain.Interfaces;
using bp.domain.Models;

namespace bp.api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class BaseController<T>(
        ILogger<BaseController<T>> logger,
        ICreate<T> create,
        IGet<T> get,
        IUpdate<T> update
        ) : ControllerBase where T : BaseEntity
    {
        private readonly ILogger<BaseController<T>> logger = logger;

        [HttpGet("{id:int}")]
        public async Task<ActionResult<T>> Get(int id)
        {
            try
            {
                T? result = await get.ByIdAsync(id);
                return result == null ? NotFound($"No customer with id = {id} was found") : Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "There was an error retrieving data from the database");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<T>>> GetAll()
        {
            try
            {
                return Ok(await get.AllAsync());
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "There was an error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<T>> Create([FromBody] T entity)
        {
            try
            {
                await create.NewAsync(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, $"There was an error retrieving data from the database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<T>> Update([FromBody] T entity)
        {
            try
            {
                await update.EntityAsync(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, $"There was an error retrieving data from the database");
            }
        }
    }
}