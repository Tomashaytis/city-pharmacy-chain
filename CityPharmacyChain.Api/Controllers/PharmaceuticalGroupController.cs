using CityPharmacyChain.Api.Host.Services;
using CityPharmacyChain.Api.Host.Dto;
using Microsoft.AspNetCore.Mvc;
using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Api.Host.Controllers;

/// <summary>
/// Контроллер для работы с сущностями класса фармацевтическая группа
/// </summary>
/// <param name="service">Сервис для работы с сущностями класса фармацевтическая группа</param>
/// <param name="logger">Логгер</param>
[ApiController]
[Route("[controller]")]
public class PharmaceuticalGroupController(PharmaceuticalGroupService service, ILogger<Product> logger) : Controller
{
    /// <summary>
    /// GET запрос по получению всех объектов класса фармацевтическая группа из базы данных
    /// </summary>
    /// <returns>Коллекция объектов класса фармацевтическая группа в формате JSON</returns>
    [HttpGet]
    public ActionResult<IEnumerable<PharmaceuticalGroup>> GetAll()
    {
        logger.LogInformation("{date} : Get : Get all pharmaceutical groups.", DateTime.Now);
        return Ok(service.GetAll());
    }

    /// <summary>
    /// GET запрос по получению объекта класса фармацевтическая группа из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор фармацевтической группы</param>
    /// <returns>Объект класса фармацевтическая группа в формате JSON или статус NotFound при отсутствии объекта в базе данных</returns>
    [HttpGet("{id}")]
    public ActionResult<PharmaceuticalGroupDto> GetById(int id)
    {
        var value = service.GetById(id);
        if (value is null)
        {
            logger.LogError("{date} : NotFound : Pharmaceutical group with id={id} not found.", DateTime.Now, id);
            return NotFound($"PharmaceuticalGroup with id {id} not found.");
        }
        logger.LogInformation("{date} : Get : Get pharmaceutical group with id={id}.", DateTime.Now, id);
        return Ok(value);
    }

    /// <summary>
    /// POST запрос по добавлению объекта класса фармацевтическая группа в базу данных
    /// </summary>
    /// <param name="pharmaceuticalGroupDto">Объект класса фармацевтическая группа в формате JSON</param>
    /// <returns>Добавленный объект класса фармацевтическая группа в формате JSON</returns>
    [HttpPost]
    public ActionResult<PharmaceuticalGroup> Post([FromBody] PharmaceuticalGroupDto pharmaceuticalGroupDto)
    {
        if (!ModelState.IsValid)
        {
            logger.LogError("{date} : BadRequest : Bad request structure for post pharmaceutical group operation.", DateTime.Now);
            return BadRequest(ModelState);
        }
        var entity = service.Post(pharmaceuticalGroupDto);
        if (entity is null)
        {
            logger.LogError("{date} : BadRequest : Pharmaceutical group cannot be added, because it is referring to non-existent entities.", DateTime.Now);
            return BadRequest($"PharmaceuticalGroup cannot be added, because it is referring to non-existent entities.");
        }
        logger.LogInformation("{date} : Post : Post pharmaceutical group with id={id}.", DateTime.Now, entity.PharmaceuticalGroupId);
        return Ok(entity);
    }

    /// <summary>
    /// PUT запрос по модификации объекта класса фармацевтическая группа из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор фармацевтической группы</param>
    /// <param name="pharmaceuticalGroupDto">Объект класса фармацевтическая группа в формате JSON</param>
    /// <returns>Изменённый объект класса фармацевтическая группа в формате JSON или статус NotFound при отсутствии объекта в базе данных</returns>
    [HttpPut("{id}")]
    public ActionResult<PharmaceuticalGroup> Put(int id, [FromBody] PharmaceuticalGroupDto pharmaceuticalGroupDto)
    {
        if (!ModelState.IsValid)
        {
            logger.LogError("{date} : BadRequest : Bad request structure for put pharmaceutical group operation.", DateTime.Now);
            return BadRequest(ModelState);
        }
        var entity = service.Put(id, pharmaceuticalGroupDto);
        if (entity is null)
        {
            logger.LogError("{date} : NotFound : Pharmaceutical group with id={id} not found.", DateTime.Now, id);
            return NotFound($"PharmaceuticalGroup with id {id} not found.");
        }
        logger.LogInformation("{date} : Put : Put pharmaceutical group with id={id}.", DateTime.Now, id);
        return Ok(entity);
    }

    /// <summary>
    /// DELETE запрос по удалению существующего объекта класса фармацевтическая группа из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор фармацевтической группы</param>
    /// <returns>Сообщение об успешности операции удаления или статус NotFound при отсутствии объекта в базе данных</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = service.Delete(id);
        if (!result)
        {
            logger.LogError("{date} : NotFound : Pharmaceutical group with id={id} not found.", DateTime.Now, id);
            return NotFound($"PharmaceuticalGroup with id {id} not found.");
        }
        logger.LogInformation("{date} : Delete : Delete pharmaceutical group with id={id}.", DateTime.Now, id);
        return Ok("PharmaceuticalGroup was successfully deleted.");
    }

    /// <summary>
    /// GET запрос по получению коллекции объектов в формате JSON с информацией о средней стоимости препаратов в каждой фармацевтической группе для каждой аптеки
    /// </summary>
    /// <returns>Коллекция объектов в формате JSON с информацией о средней стоимости препаратов в каждой фармацевтической группе для каждой аптеки</returns>
    [HttpGet("GetPharmaceuticalGroupPriceForEachPharmacy")]
    public ActionResult<IEnumerable<PharmaceuticalGroupPriceDto>> GetProductsForPharmacy()
    {
        logger.LogInformation("{date} : Get : Get specific data.", DateTime.Now);
        return Ok(service.GetPharmaceuticalGroupPriceForEachPharmacy());
    }
}

