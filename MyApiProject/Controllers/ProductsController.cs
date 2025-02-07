using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "UserOnly")]
    public IActionResult GetAll() => Ok("Products for User");

    [HttpPost]
    [Authorize(Policy = "AdminOnly")]
    public IActionResult Create([FromBody] Product product)
    {
        return Ok("Product created by Admin");
    }
}