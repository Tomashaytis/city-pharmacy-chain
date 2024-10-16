using CityPharmacyChain.Api.Services;
using CityPharmacyChain.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PriceListEntryController(PriceListEntryService service) : Controller
{
    [HttpGet("{id}")]
    public ActionResult<PriceListEntryDto> GetById(int id)
    {
        var value = service.GetById(id);
        if (value is null)
            return NotFound($"PriceListEntry with id {id} not found.");
        return Ok(value);
    }

    [HttpGet]
    public ActionResult<IEnumerable<PriceListEntry>> GetAll()
    {
        return Ok(service.GetAll());
    }

    [HttpPut("{id}")]
    public ActionResult<PriceListEntry> Put(int id, [FromBody] PriceListEntryDto dto)
    {
        var entity = service.Put(id, dto);
        if (entity is null)
            return NotFound($"PriceListEntry with id {id} not found.");
        return Ok(entity);
    }

    [HttpPost]
    public ActionResult<PriceListEntry> Post([FromBody] PriceListEntryDto dto)
    {
        var entity = service.Post(dto);
        return Ok(entity);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = service.Delete(id);
        if (!result)
            return NotFound($"PriceListEntry with id {id} not found.");
        return Ok("PriceListEntry was successfully deleted");
    }
}