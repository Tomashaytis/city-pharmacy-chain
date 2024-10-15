using CityPharmacyChain.Api.Services;
using CityPharmacyChain.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PharmaceuticalGroupController(PharmaceuticalGroupService service) : Controller
{
    [HttpGet("{id}")]
    public ActionResult<PharmaceuticalGroupDto> GetById(int id)
    {
        var value = service.GetById(id);
        if (value is null)
            return NotFound($"Pharmacy with id {id} not found.");
        return Ok(value);
    }

    [HttpGet]
    public ActionResult<IEnumerable<PharmaceuticalGroup>> GetAll()
    {
        return Ok(service.GetAll());
    }

    [HttpPut("{id}")]
    public ActionResult<PharmaceuticalGroup> Put(int id, [FromBody] PharmaceuticalGroupDto dto)
    {
        var entity = service.Put(id, dto);
        if (entity is null)
            return NotFound($"Pharmacy with id {id} not found.");
        return Ok(entity);
    }

    [HttpPost]
    public ActionResult<PharmaceuticalGroup> Post([FromBody] PharmaceuticalGroupDto dto)
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

