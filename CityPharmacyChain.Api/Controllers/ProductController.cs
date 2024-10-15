using CityPharmacyChain.Api.Services;
using CityPharmacyChain.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(ProductService service) : Controller
{
    [HttpGet("{id}")]
    public ActionResult<ProductDto> GetById(int id)
    {
        var value = service.GetById(id);
        if (value is null)
            return NotFound($"Pharmacy with id {id} not found.");
        return Ok(value);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        return Ok(service.GetAll());
    }

    [HttpPut("{id}")]
    public ActionResult<Product> Put(int id, [FromBody] ProductDto dto)
    {
        var entity = service.Put(id, dto);
        if (entity is null)
            return NotFound($"Pharmacy with id {id} not found.");
        return Ok(entity);
    }

    [HttpPost]
    public ActionResult<Product> Post([FromBody] ProductDto dto)
    {
        var entity = service.Post(dto);
        return Ok(entity);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = service.Delete(id);
        if (!result)
            return NotFound($"Pharmacy with id {id} not found.");
        return Ok();
    }
}
