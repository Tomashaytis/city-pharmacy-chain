using CityPharmacyChain.Api.Services;
using CityPharmacyChain.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Api.Controllers;

/// <summary>
/// Контроллер для работы с сущностями класса связь препарат-аптека
/// </summary>
/// <param name="service">Сервис для работы с сущностями класса связь препарат-аптека</param>
/// <param name="logger">Логгер</param>
[ApiController]
[Route("[controller]")]
public class PharmacyProductController(PharmacyProductService service, ILogger<Product> logger) : Controller
{
    /// <summary>
    /// GET запрос по получению всех объектов класса связь препарат-аптека из базы данных
    /// </summary>
    /// <returns>Коллекция объектов класса связь препарат-аптека в формате JSON</returns>
    [HttpGet]
    public ActionResult<IEnumerable<PharmacyProduct>> GetAll()
    {
        logger.LogInformation("{date} : Get : Get all pharmacy-products.", DateTime.Now);
        return Ok(service.GetAll());
    }

    /// <summary>
    /// GET запрос по получению объекта класса связь препарат-аптека из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор связи препарат-аптека</param>
    /// <returns>Объект класса связь препарат-аптека в формате JSON или статус NotFound при отсутствии объекта в базе данных</returns>
    [HttpGet("{id}")]
    public ActionResult<PharmacyProductDto> GetById(int id)
    {
        var value = service.GetById(id);
        if (value is null)
        {
            logger.LogError("{date} : NotFound : Pharmacy-product with id={id} not found.", DateTime.Now, id);
            return NotFound($"PharmacyProduct with id {id} not found.");
        }
        logger.LogInformation("{date} : Get : Get pharmacy-product with id={id}.", DateTime.Now, id);
        return Ok(value);
    }

    /// <summary>
    /// POST запрос по добавлению объекта класса связь препарат-аптека в базу данных
    /// </summary>
    /// <param name="pharmacyProductDto">Объект класса связь препарат-аптека в формате JSON</param>
    /// <returns>Добавленный объект класса связь препарат-аптека в формате JSON</returns>
    [HttpPost]
    public ActionResult<PharmacyProduct> Post([FromBody] PharmacyProductDto pharmacyProductDto)
    {
        if (!ModelState.IsValid)
        {
            logger.LogError("{date} : BadRequest : Bad request structure for post pharmacy-product operation.", DateTime.Now);
            return BadRequest(ModelState);
        }
        var entity = service.Post(pharmacyProductDto);
        logger.LogInformation("{date} : Post : Post pharmacy-product with id={id}.", DateTime.Now, entity.PharmacyProductId);
        return Ok(entity);
    }

    /// <summary>
    /// PUT запрос по модификации объекта класса связь препарат-аптека из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор связи препарат-аптека</param>
    /// <param name="pharmacyProductDto">Объект класса связь препарат-аптека в формате JSON</param>
    /// <returns>Изменённый объект класса связь препарат-аптека в формате JSON или статус NotFound при отсутствии объекта в базе данных</returns>

    [HttpPut("{id}")]
    public ActionResult<PharmacyProduct> Put(int id, [FromBody] PharmacyProductDto pharmacyProductDto)
    {
        if (!ModelState.IsValid)
        {
            logger.LogError("{date} : BadRequest : Bad request structure for put pharmacy-product operation.", DateTime.Now);
            return BadRequest(ModelState);
        }
        var entity = service.Put(id, pharmacyProductDto);
        if (entity is null)
        {
            logger.LogError("{date} : NotFound : Pharmacy-product with id={id} not found.", DateTime.Now, id);
            return NotFound($"PharmacyProduct with id {id} not found.");
        }
        logger.LogInformation("{date} : Put : Put pharmacy-product with id={id}.", DateTime.Now, id);
        return Ok(entity);
    }

    /// <summary>
    /// DELETE запрос по удалению существующего объекта класса связь препарат-аптека из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор связи препарат-аптека</param>
    /// <returns>Сообщение об успешности операции удаления или статус NotFound при отсутствии объекта в базе данных</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = service.Delete(id);
        if (!result)
        {
            logger.LogError("{date} : NotFound : Pharmacy-product with id={id} not found.", DateTime.Now, id);
            return NotFound($"PharmacyProduct with id {id} not found.");
        }
        logger.LogInformation("{date} : Delete : Delete pharmacy-product with id={id}.", DateTime.Now, id);
        return Ok("PharmacyProduct was successfully deleted.");
    }

    /// <summary>
    /// GET запрос по получению коллекции объектов в формате JSON с информацией о топ 5 аптеках по количеству и объёму продаж заданного препарата в заданном временном интервале
    /// </summary>
    /// <param name="productName">Название препарата</param>
    /// <param name="start">Начало временного интервала</param>
    /// <param name="end">Конец временного интервала</param>
    /// <returns>Коллекция объектов в формате JSON с информацией о топ 5 аптеках по количеству и объёму продаж заданного препарата в заданном временном интервале</returns>
    [HttpGet("GetTopFivePharmaciesBySoldVolume")]
    public ActionResult<IEnumerable<ProductSoldVolumeDto>> GetTopFivePharmaciesBySoldVolume(string productName, DateTime start, DateTime end)
    {
        logger.LogInformation("{date} : Get : Get specific data.", DateTime.Now);
        return Ok(service.GetTopFivePharmaciesBySoldVolume(productName, start, end));
    }
}