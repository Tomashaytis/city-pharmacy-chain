using CityPharmacyChain.Api.Services;
using CityPharmacyChain.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Api.Controllers;

/// <summary>
/// Контроллер для работы с сущностями класса запись в прайс-листе
/// </summary>
/// <param name="service">Сервис для работы с сущностями класса запись в прайс-листе</param>
/// <param name="logger">Логгер</param>
[ApiController]
[Route("[controller]")]
public class PriceListEntryController(PriceListEntryService service, ILogger<Product> logger) : Controller
{
    /// <summary>
    /// GET запрос по получению всех объектов класса запись в прайс-листе из базы данных
    /// </summary>
    /// <returns>Коллекция объектов класса запись в прайс-листе в формате JSON</returns>
    [HttpGet]
    public ActionResult<IEnumerable<PriceListEntry>> GetAll()
    {
        logger.LogInformation("{date} : Get : Get all price list entries.", DateTime.Now);
        return Ok(service.GetAll());
    }

    /// <summary>
    /// GET запрос по получению объекта класса запись в прайс-листе из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор записи в прайс-листе</param>
    /// <returns>Объект класса запись в прайс-листе в формате JSON или статус NotFound при отсутствии объекта в базе данных</returns>
    [HttpGet("{id}")]
    public ActionResult<PriceListEntryDto> GetById(int id)
    {
        var value = service.GetById(id);
        if (value is null)
        {
            logger.LogError("{date} : NotFound : Price list entry with id={id} not found.", DateTime.Now, id);
            return NotFound($"PriceListEntry with id {id} not found.");
        }
        logger.LogInformation("{date} : Get : Get price list entry with id={id}.", DateTime.Now, id);
        return Ok(value);
    }

    /// <summary>
    /// POST запрос по добавлению объекта класса запись в прайс-листе в базу данных
    /// </summary>
    /// <param name="priceListEntryDto">Объект класса запись в прайс-листе в формате JSON</param>
    /// <returns>Добавленный объект класса запись в прайс-листе в формате JSON</returns>
    [HttpPost]
    public ActionResult<PriceListEntry> Post([FromBody] PriceListEntryDto priceListEntryDto)
    {
        if (!ModelState.IsValid)
        {
            logger.LogError("{date} : BadRequest : Bad request structure for post price list entry operation.", DateTime.Now);
            return BadRequest(ModelState);
        }
        var entity = service.Post(priceListEntryDto);
        if (entity is null)
        {
            logger.LogError("{date} : BadRequest : Price list entry cannot be added, because it is referring to non-existent entities.", DateTime.Now);
            return BadRequest($"PriceListEntry cannot be added, because it is referring to non-existent entities.");
        }
        logger.LogInformation("{date} : Post : Post price list entry with id={id}.", DateTime.Now, entity.PriceListEntryId);
        return Ok(entity);
    }

    /// <summary>
    /// PUT запрос по модификации объекта класса запись в прайс-листе из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор записи в прайс-листе</param>
    /// <param name="priceListEntryDto">Объект класса запись в прайс-листе в формате JSON</param>
    /// <returns>Изменённый объект класса запись в прайс-листе в формате JSON или статус NotFound при отсутствии объекта в базе данных</returns>
    [HttpPut("{id}")]
    public ActionResult<PriceListEntry> Put(int id, [FromBody] PriceListEntryDto priceListEntryDto)
    {
        if (!ModelState.IsValid)
        {
            logger.LogError("{date} : BadRequest : Bad request structure for put price list entry operation.", DateTime.Now);
            return BadRequest(ModelState);
        }
        var entity = service.Put(id, priceListEntryDto);
        if (entity is null)
        {
            logger.LogError("{date} : NotFound : Price list entry with id={id} not found.", DateTime.Now, id);
            return NotFound($"PriceListEntry with id {id} not found.");
        }
        logger.LogInformation("{date} : Put : Put price list entry with id={id}.", DateTime.Now, id);
        return Ok(entity);
    }

    /// <summary>
    /// DELETE запрос по удалению существующего объекта класса запись в прайс-листе из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор записи в прайс-листе</param>
    /// <returns>Сообщение об успешности операции удаления или статус NotFound при отсутствии объекта в базе данных</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = service.Delete(id);
        if (!result)
        {
            logger.LogError("{date} : NotFound : Price list entry with id={id} not found.", DateTime.Now, id);
            return NotFound($"PriceListEntry with id {id} not found.");
        }
        logger.LogInformation("{date} : Delete : Delete price list entry with id={id}.", DateTime.Now, id);
        return Ok("PriceListEntry was successfully deleted.");
    }
}