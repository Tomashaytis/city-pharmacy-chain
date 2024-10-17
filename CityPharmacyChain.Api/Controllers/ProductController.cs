using CityPharmacyChain.Api.Services;
using CityPharmacyChain.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Api.Controllers;

/// <summary>
/// Контроллер для работы с сущностями класса препарат
/// </summary>
/// <param name="service">Сервис для работы с сущностями препарат</param>
[ApiController]
[Route("[controller]")]
public class ProductController(ProductService service) : Controller
{
    /// <summary>
    /// GET запрос по получению всех объектов класса препарат из базы данных
    /// </summary>
    /// <returns>Коллекция объектов класса препарат в формате JSON</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
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
            return NotFound($"Product with id {id} not found.");
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
        var entity = service.Post(productDto);
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
        var entity = service.Put(id, productDto);
        if (entity is null)
            return NotFound($"Product with id {id} not found.");
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
            return NotFound($"Product with id {id} not found.");
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
        return Ok(service.GetProductCountForEachPharmacy(productName));
    }
}
