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

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var result = service.Delete(id);
        if (!result)
            return NotFound($"Pharmacy with id {id} not found.");
        return Ok();
    }

    [HttpGet("GetProductsForPharmacy")]
    public ActionResult<IEnumerable<ProductForPharmacyDto>> GetProductsForPharmacy(string pharmacyName)
    {
        return Ok(service.GetProductsForPharmacy(pharmacyName));
    }

    [HttpGet("GetPharmaciesWithLargeProductSoldVolume")]
    public ActionResult<IEnumerable<string>> GetPharmaciesWithLargeProductSoldVolume(string district, string productName, int volume)
    {
        return Ok(service.GetPharmaciesWithLargeProductSoldVolume(district, productName, volume));
    }

    [HttpGet("GetPharmaciesWithMinProductPrice")]
    public ActionResult<IEnumerable<string>> GetPharmaciesWithMinProductPrice(string productName)
    {
        return Ok(service.GetPharmaciesWithMinProductPrice(productName));
    }
}
