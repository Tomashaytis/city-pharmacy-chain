using CityPharmacyChain.Api.Services;
using CityPharmacyChain.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Api.Controllers;

/// <summary>
/// Контроллер для работы с сущностями класса аптека
/// </summary>
/// <param name="service">Сервис для работы с сущностями класса аптека</param>
/// <param name="logger">Логгер</param>
[ApiController]
[Route("[controller]")]
public class PharmacyController(PharmacyService service, ILogger<Product> logger) : Controller
{
    /// <summary>
    /// GET запрос по получению всех объектов класса аптека из базы данных
    /// </summary>
    /// <returns>Коллекция объектов класса аптека в формате JSON</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Pharmacy>> GetAll()
    {
        logger.LogInformation("{date} : Get : Get all pharmacies.", DateTime.Now);
        return Ok(service.GetAll());
    }

    /// <summary>
    /// GET запрос по получению объекта класса аптека из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор аптеки</param>
    /// <returns>Объект класса аптека в формате JSON или статус NotFound при отсутствии объекта в базе данных</returns>
    [HttpGet("{id}")]
    public ActionResult<PharmacyDto> GetById(int id)
    {
        var value = service.GetById(id);
        if (value is null)
        {
            logger.LogError("{date} : NotFound : Pharmacy with id={id} not found.", DateTime.Now, id);
            return NotFound($"Pharmacy with id {id} not found.");
        }
        logger.LogInformation("{date} : Get : Get pharmacy with id={id}.", DateTime.Now, id);
        return Ok(value);
    }

    /// <summary>
    /// POST запрос по добавлению объекта класса аптека в базу данных
    /// </summary>
    /// <param name="pharmacyDto">Объект класса аптека в формате JSON</param>
    /// <returns>Добавленный объект класса аптека в формате JSON</returns>
    [HttpPost]
    public ActionResult<Pharmacy> Post([FromBody] PharmacyDto pharmacyDto)
    {
        if (!ModelState.IsValid)
        {
            logger.LogError("{date} : BadRequest : Bad request structure for post pharmacy operation.", DateTime.Now);
            return BadRequest(ModelState);
        }
        var entity = service.Post(pharmacyDto);
        logger.LogInformation("{date} : Post : Post pharmacy with id={id}.", DateTime.Now, entity.PharmacyId);
        return Ok(entity);
    }

    /// <summary>
    /// PUT запрос по модификации объекта класса аптека из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор аптеки</param>
    /// <param name="pharmacyDto">Объект класса аптека в формате JSON</param>
    /// <returns>Изменённый объект класса аптека в формате JSON или статус NotFound при отсутствии объекта в базе данных</returns>
    [HttpPut("{id}")]
    public ActionResult<Pharmacy> Put(int id, [FromBody] PharmacyDto pharmacyDto)
    {
        if (!ModelState.IsValid)
        {
            logger.LogError("{date} : BadRequest : Bad request structure for put pharmacy operation.", DateTime.Now);
            return BadRequest(ModelState);
        }
        var entity = service.Put(id, pharmacyDto);
        if (entity is null)
        {
            logger.LogError("{date} : NotFound : Pharmacy with id={id} not found.", DateTime.Now, id);
            return NotFound($"Pharmacy with id {id} not found.");
        }
        logger.LogInformation("{date} : Put : Put pharmacy with id={id}.", DateTime.Now, id);
        return Ok(entity);
    }

    /// <summary>
    /// DELETE запрос по удалению существующего объекта класса аптека из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор аптеки</param>
    /// <returns>Сообщение об успешности операции удаления или статус NotFound при отсутствии объекта в базе данных</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = service.Delete(id);
        if (!result)
        {
            logger.LogError("{date} : NotFound : Pharmacy with id={id} not found.", DateTime.Now, id);
            return NotFound($"Pharmacy with id {id} not found.");
        }
        logger.LogInformation("{date} : Delete : Delete pharmacy with id={id}.", DateTime.Now, id);
        return Ok("Pharmacy was successfully deleted.");
    }

    /// <summary>
    /// GET запрос по получению коллекции объектов в формате JSON с информацией о характеристиках препаратов в заданной аптеке, упорядоченный по названию препарата
    /// </summary>
    /// <param name="pharmacyName">Название аптеки</param>
    /// <returns>Коллекция объектов в формате JSON с информацией о характеристиках препаратов в заданной аптеке, упорядоченный по названию препарата</returns>
    [HttpGet("GetProductsForPharmacy")]
    public ActionResult<IEnumerable<ProductForPharmacyDto>> GetProductsForPharmacy(string pharmacyName)
    {
        logger.LogInformation("{date} : Get : Get specific data.", DateTime.Now);
        return Ok(service.GetProductsForPharmacy(pharmacyName));
    }

    /// <summary>
    /// GET запрос по получению коллекции в формате JSON с названиями аптек в заданном районе, продавших заданный препарат больше заданного объёма
    /// </summary>
    /// <param name="district">Район аптеки</param>
    /// <param name="productName">Название препарата</param>
    /// <param name="volume">Объём продажи</param>
    /// <returns>Коллекция в формате JSON с названиями аптек в заданном районе, продавших заданный препарат больше заданного объёма</returns>
    [HttpGet("GetPharmaciesWithLargeProductSoldVolume")]
    public ActionResult<IEnumerable<string>> GetPharmaciesWithLargeProductSoldVolume(string district, string productName, int volume)
    {
        logger.LogInformation("{date} : Get : Get specific data.", DateTime.Now);
        return Ok(service.GetPharmaciesWithLargeProductSoldVolume(district, productName, volume));
    }

    /// <summary>
    /// GET запрос по получению коллекции в формате JSON с названиями аптек, в которых заданный препарат продаётся с минимальной ценой
    /// </summary>
    /// <param name="productName">Название препарата</param>
    /// <returns>Коллекция в формате JSON с названиями аптек, в которых заданный препарат продаётся с минимальной ценой</returns>
    [HttpGet("GetPharmaciesWithMinProductPrice")]
    public ActionResult<IEnumerable<string>> GetPharmaciesWithMinProductPrice(string productName)
    {
        logger.LogInformation("{date} : Get : Get specific data.", DateTime.Now);
        return Ok(service.GetPharmaciesWithMinProductPrice(productName));
    }
}
