using CityPharmacyChain.Api.Host.Services;
using CityPharmacyChain.Api.Host.Dto;
using Microsoft.AspNetCore.Mvc;
using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Api.Host.Controllers;

/// <summary>
/// Контроллер для работы с сущностями класса препарат
/// </summary>
/// <param name="service">Сервис для работы с сущностями препарат</param>
/// <param name="logger">Логгер</param>
[ApiController]
[Route("[controller]")]
public class ProductController(ProductService service, ILogger<Product> logger) : Controller
{
    /// <summary>
    /// GET запрос по получению всех объектов класса препарат из базы данных
    /// </summary>
    /// <returns>Коллекция объектов класса препарат в формате JSON</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        logger.LogInformation("{date} : Get : Get all products.", DateTime.Now);
        return Ok(service.GetAll());
    }

    /// <summary>
    /// GET запрос по получению объекта класса препарат из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор препарата</param>
    /// <returns>Объект класса препарат в формате JSON или статус NotFound при отсутствии объекта в базе данных</returns>
    [HttpGet("{id}")]
    public ActionResult<ProductDto> GetById(int id)
    {
        var value = service.GetById(id);
        if (value is null)
        {
            logger.LogError("{date} : NotFound : Product with id={id} not found.", DateTime.Now, id);
            return NotFound($"Product with id {id} not found.");
        }
        logger.LogInformation("{date} : Get : Get product with id={id}.", DateTime.Now, id);
        return Ok(value);
    }

    /// <summary>
    /// POST запрос по добавлению объекта класса препарат в базу данных
    /// </summary>
    /// <param name="productDto">Объект класса препарат в формате JSON</param>
    /// <returns>Добавленный объект класса препарат в формате JSON</returns>
    [HttpPost]
    public ActionResult<Product> Post([FromBody] ProductDto productDto)
    {
        if (!ModelState.IsValid)
        {
            logger.LogError("{date} : BadRequest : Bad request structure for post product operation.", DateTime.Now);
            return BadRequest(ModelState);
        }
        var entity = service.Post(productDto);
        if (entity is null)
        {
            logger.LogError("{date} : BadRequest : Product cannot be added, because it is referring to non-existent entities.", DateTime.Now);
            return BadRequest($"Product cannot be added, because it is referring to non-existent entities.");
        }
        logger.LogInformation("{date} : Post : Post product with id={id}.", DateTime.Now, entity.ProductId);
        return Ok(entity);
    }

    /// <summary>
    /// PUT запрос по модификации объекта класса препарат из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор препарата</param>
    /// <param name="productDto">Объект класса препарат в формате JSON</param>
    /// <returns>Изменённый объект класса препарат в формате JSON или статус NotFound при отсутствии объекта в базе данных</returns>
    [HttpPut("{id}")]
    public ActionResult<Product> Put(int id, [FromBody] ProductDto productDto)
    {
        if (!ModelState.IsValid)
        {
            logger.LogError("{date} : BadRequest : Bad request structure for put product operation.", DateTime.Now);
            return BadRequest(ModelState);
        }
        var entity = service.Put(id, productDto);
        if (entity is null)
        {
            logger.LogError("{date} : NotFound : Product with id={id} not found.", DateTime.Now, id);
            return NotFound($"Product with id {id} not found.");
        }
        logger.LogInformation("{date} : Put : Put product with id={id}.", DateTime.Now, id);
        return Ok(entity);
    }

    /// <summary>
    /// DELETE запрос по удалению существующего объекта класса препарат из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор препарата</param>
    /// <returns>Сообщение об успешности операции удаления или статус NotFound при отсутствии объекта в базе данных</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = service.Delete(id);
        if (!result)
        {
            logger.LogError("{date} : NotFound : Product with id={id} not found.", DateTime.Now, id);
            return NotFound($"Product with id {id} not found.");
        }
        logger.LogInformation("{date} : Delete : Delete product with id={id}.", DateTime.Now, id);
        return Ok("Product was successfully deleted.");
    }

    /// <summary>
    /// GET запрос по получению коллекции объектов в формате JSON с информацией о всех аптеках, у которых есть в наличии заданный препарат, с указанием количества данного препарата в них
    /// </summary>
    /// <param name="productName">Название препарата</param>
    /// <returns>Коллекция объектов в формате JSON с информацией о всех аптеках, у которых есть в наличии заданный препарат, с указанием количества данного препарата в них</returns>
    [HttpGet("GetProductCountForEachPharmacy")]
    public ActionResult<IEnumerable<ProductForPharmacyDto>> GetProductsForPharmacy(string productName)
    {
        logger.LogInformation("{date} : Get : Get specific data.", DateTime.Now);
        return Ok(service.GetProductCountForEachPharmacy(productName));
    }
}
