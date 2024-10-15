using CityPharmacyChain.Api.Services;
using CityPharmacyChain.Api.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CityPharmacyChain.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PharmacyController(PharmacyService service) : Controller
{
    [HttpGet("{id}")]
    public ActionResult<PharmacyDtoGet> Get(int id)
    {
        var value = service.GetById(id);
        if (value is null)
            return NotFound($"Pharmacy with id {id} not found.");
        return Ok(service.GetById(id));
    }
}
