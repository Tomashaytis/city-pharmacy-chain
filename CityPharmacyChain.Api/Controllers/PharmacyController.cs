using CityPharmacyChain.Api.Services;
using CityPharmacyChain.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PharmacyController(PharmacyService service) : Controller
{
    [HttpGet("{id}")]
    public ActionResult<PharmacyDto> GetById(int id)
    {
        var value = service.GetById(id);
        if (value is null)
            return NotFound($"Pharmacy with id {id} not found.");
        return Ok(value);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Pharmacy>> GetAll()
    {
        return Ok(service.GetAll());
    }

    [HttpPut("{id}")]
    public ActionResult<Pharmacy> Put(int id, [FromBody] PharmacyDto dto)
    {
        var entity = service.Put(id, dto);
        if (entity is null)
            return NotFound($"Pharmacy with id {id} not found.");
        return Ok(entity);
    }

    [HttpPost]
    public ActionResult<Pharmacy> Post([FromBody] PharmacyDto dto)
    {
        var entity = service.Post(dto);
        return Ok(entity);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var result = service.Delete(id);
        if (!result)
            return NotFound($"Pharmacy with id {id} not found.");
        return Ok();
    }
}
