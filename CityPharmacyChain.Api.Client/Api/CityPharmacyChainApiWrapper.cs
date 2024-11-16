namespace CityPharmacyChain.Api.Client.Api;

/// <summary>
/// Класс-обёртка для класса CityPharmacyChainApi
/// </summary>
/// <param name="configuration">Конфигурация для класса-обёртки</param>
public class CityPharmacyChainApiWrapper(IConfiguration configuration)
{
    /// <summary>
    /// Экземпляр клиента
    /// </summary>
    public readonly CityPharmacyChainApi Client = new(configuration["OpenApi:ServerUrl"], new HttpClient());


    /// <summary>
    /// Метод посылает GET запрос на получение коллекции объектов типа фармацевтическая группа с сервера
    /// </summary>
    /// <returns>Коллекция объектов типа фармацевтическая группа</returns>
    public async Task<ICollection<PharmaceuticalGroupFullDto>> PharmaceuticalGroupGetAll() => await Client.PharmaceuticalGroupAllAsync();

    /// <summary>
    /// Метод посылает GET запрос на получение объекта типа фармацевтическая группа по его идентификатору с сервера
    /// </summary>
    /// <param name="id">Идентификатор объекта типа фармацевтическая группа</param>
    /// <returns>Объект типа фармацевтическая группа по его идентификатору</returns>
    public async Task<PharmaceuticalGroupDto> PharmaceuticalGroupGetById(int id) => await Client.PharmaceuticalGroupGETAsync(id);

    /// <summary>
    /// Метод посылает POST запрос на добавление объекта типа фармацевтическая группа на сервер
    /// </summary>
    /// <param name="pharmaceuticalGroupDto">Объект типа фармацевтическая группа</param>
    /// <returns>Добавленный объект типа фармацевтическая группа</returns>
    public async Task<PharmaceuticalGroupFullDto> PharmaceuticalGroupPost(PharmaceuticalGroupDto pharmaceuticalGroupDto) => await Client.PharmaceuticalGroupPOSTAsync(pharmaceuticalGroupDto);

    /// <summary>
    /// Метод посылает PUT запрос на модификацию объекта типа фармацевтическая группа по его идентификатору на сервере
    /// </summary>
    /// <param name="id">Идентификатор объекта типа фармацевтическая группа</param>
    /// <param name="pharmaceuticalGroupDto">Объект типа фармацевтическая группа</param>
    /// <returns>Изменённый объект типа фармацевтическая группа</returns>
    public async Task<PharmaceuticalGroupFullDto> PharmaceuticalGroupPut(int id, PharmaceuticalGroupDto pharmaceuticalGroupDto) => await Client.PharmaceuticalGroupPUTAsync(id, pharmaceuticalGroupDto);

    /// <summary>
    /// Метод посылает DELETE запрос на удаление объекта типа фармацевтическая группа по его идентификатору с сервера
    /// </summary>
    /// <param name="id">Идентификатор объекта типа фармацевтическая группа</param>
    /// <returns>Нет возвращаемого значения</returns>
    public async Task PharmaceuticalGroupDelete(int id) => await Client.PharmaceuticalGroupDELETEAsync(id);


    /// <summary>
    /// Метод посылает GET запрос на получение коллекции объектов типа аптека с сервера
    /// </summary>
    /// <returns>Коллекция объектов типа аптека</returns>
    public async Task<ICollection<PharmacyFullDto>> PharmacyGetAll() => await Client.PharmacyAllAsync();

    /// <summary>
    /// Метод посылает GET запрос на получение объекта типа аптека по его идентификатору с сервера
    /// </summary>
    /// <param name="id">Идентификатор объекта типа аптека</param>
    /// <returns>Объект типа аптека по его идентификатору</returns>
    public async Task<PharmacyDto> PharmacyGetById(int id) => await Client.PharmacyGETAsync(id);

    /// <summary>
    /// Метод посылает POST запрос на добавление объекта типа аптека на сервер
    /// </summary>
    /// <param name="pharmacyDto">Объект типа аптека</param>
    /// <returns>Добавленный объект типа аптека</returns>
    public async Task<PharmacyFullDto> PharmacyPost(PharmacyDto pharmacyDto) => await Client.PharmacyPOSTAsync(pharmacyDto);

    /// <summary>
    /// Метод посылает PUT запрос на модификацию объекта типа аптека по его идентификатору на сервере
    /// </summary>
    /// <param name="id">Идентификатор объекта типа аптека</param>
    /// <param name="pharmacyDto">Объект типа аптека</param>
    /// <returns>Изменённый объект типа аптека</returns>
    public async Task<PharmacyFullDto> PharmacyPut(int id, PharmacyDto pharmacyDto) => await Client.PharmacyPUTAsync(id, pharmacyDto);

    /// <summary>
    /// Метод посылает DELETE запрос на удаление объекта типа аптека по его идентификатору с сервера
    /// </summary>
    /// <param name="id">Идентификатор объекта типа аптека</param>
    /// <returns>Нет возвращаемого значения</returns>
    public async Task PharmacyDelete(int id) => await Client.PharmacyDELETEAsync(id);


    /// <summary>
    /// Метод посылает GET запрос на получение коллекции объектов типа связь препарат-аптека с сервера
    /// </summary>
    /// <returns>Коллекция объектов типа связь препарат-аптека</returns>
    public async Task<ICollection<PharmacyProductFullDto>> PharmacyProductGetAll() => await Client.PharmacyProductAllAsync();

    /// <summary>
    /// Метод посылает GET запрос на получение объекта типа связь препарат-аптека по его идентификатору с сервера
    /// </summary>
    /// <param name="id">Идентификатор объекта типа связь препарат-аптека</param>
    /// <returns>Объект типа связь препарат-аптека по его идентификатору</returns>
    public async Task<PharmacyProductDto> PharmacyProductGetById(int id) => await Client.PharmacyProductGETAsync(id);

    /// <summary>
    /// Метод посылает POST запрос на добавление объекта типа связь препарат-аптека на сервер
    /// </summary>
    /// <param name="pharmacyProductDto">Объект типа связь препарат-аптека</param>
    /// <returns>Добавленный объект типа связь препарат-аптека</returns>
    public async Task<PharmacyProductFullDto> PharmacyProductPost(PharmacyProductDto pharmacyProductDto) => await Client.PharmacyProductPOSTAsync(pharmacyProductDto);

    /// <summary>
    /// Метод посылает PUT запрос на модификацию объекта типа связь препарат-аптека по его идентификатору на сервере
    /// </summary>
    /// <param name="id">Идентификатор объекта типа связь препарат-аптека</param>
    /// <param name="pharmacyProductDto">Объект типа связь препарат-аптека</param>
    /// <returns>Изменённый объект связь препарат-аптека аптека</returns>
    public async Task<PharmacyProductFullDto> PharmacyProductPut(int id, PharmacyProductDto pharmacyProductDto) => await Client.PharmacyProductPUTAsync(id, pharmacyProductDto);

    /// <summary>
    /// Метод посылает DELETE запрос на удаление объекта типа связь препарат-аптека по его идентификатору с сервера
    /// </summary>
    /// <param name="id">Идентификатор объекта типа связь препарат-аптека</param>
    /// <returns>Нет возвращаемого значения</returns>
    public async Task PharmacyProductDelete(int id) => await Client.PharmacyProductDELETEAsync(id);


    /// <summary>
    /// Метод посылает GET запрос на получение коллекции объектов типа запись в прайс-листе с сервера
    /// </summary>
    /// <returns>Коллекция объектов типа запись в прайс-листе</returns>
    public async Task<ICollection<PriceListEntryFullDto>> PriceListEntryGetAll() => await Client.PriceListEntryAllAsync();

    /// <summary>
    /// Метод посылает GET запрос на получение объекта типа запись в прайс-листе по его идентификатору с сервера
    /// </summary>
    /// <param name="id">Идентификатор объекта типа запись в прайс-листе</param>
    /// <returns>Объект типа запись в прайс-листе по его идентификатору</returns>
    public async Task<PriceListEntryDto> PriceListEntryGetById(int id) => await Client.PriceListEntryGETAsync(id);

    /// <summary>
    /// Метод посылает POST запрос на добавление объекта типа запись в прайс-листе на сервер
    /// </summary>
    /// <param name="priceListEntryDto">Объект типа запись в прайс-листе</param>
    /// <returns>Добавленный объект типа запись в прайс-листе</returns>
    public async Task<PriceListEntryFullDto> PriceListEntryPost(PriceListEntryDto priceListEntryDto) => await Client.PriceListEntryPOSTAsync(priceListEntryDto);

    /// <summary>
    /// Метод посылает PUT запрос на модификацию объекта типа запись в прайс-листе по его идентификатору на сервере
    /// </summary>
    /// <param name="id">Идентификатор объекта типа запись в прайс-листе</param>
    /// <param name="priceListEntryDto">Объект типа запись в прайс-листе</param>
    /// <returns>Изменённый объект типа запись в прайс-листе</returns>
    public async Task<PriceListEntryFullDto> PriceListEntryDtoPut(int id, PriceListEntryDto priceListEntryDto) => await Client.PriceListEntryPUTAsync(id, priceListEntryDto);

    /// <summary>
    /// Метод посылает DELETE запрос на удаление объекта типа запись в прайс-листе по его идентификатору с сервера
    /// </summary>
    /// <param name="id">Идентификатор объекта типа запись в прайс-листе</param>
    /// <returns>Нет возвращаемого значения</returns>
    public async Task PriceListEntryDelete(int id) => await Client.PriceListEntryDELETEAsync(id);


    /// <summary>
    /// Метод посылает GET запрос на получение коллекции объектов типа препарат с сервера
    /// </summary>
    /// <returns>Коллекция объектов типа препарат</returns>
    public async Task<ICollection<ProductFullDto>> ProductGetAll() => await Client.ProductAllAsync();

    /// <summary>
    /// Метод посылает GET запрос на получение объекта типа препарат по его идентификатору с сервера
    /// </summary>
    /// <param name="id">Идентификатор объекта типа препарат</param>
    /// <returns>Объект типа препарат по его идентификатору</returns>
    public async Task<ProductDto> ProductGetById(int id) => await Client.ProductGETAsync(id);

    /// <summary>
    /// Метод посылает POST запрос на добавление объекта типа препарат на сервер
    /// </summary>
    /// <param name="productDto">Объект типа препарат</param>
    /// <returns>Добавленный объект типа препарат</returns>
    public async Task<ProductFullDto> ProductPost(ProductDto productDto) => await Client.ProductPOSTAsync(productDto);

    /// <summary>
    /// Метод посылает PUT запрос на модификацию объекта типа препарат по его идентификатору на сервере
    /// </summary>
    /// <param name="id">Идентификатор объекта типа препарат</param>
    /// <param name="productDto">Объект типа препарат</param>
    /// <returns>Изменённый объект типа препарат</returns>
    public async Task<ProductFullDto> ProductDtoPut(int id, ProductDto productDto) => await Client.ProductPUTAsync(id, productDto);

    /// <summary>
    /// Метод посылает DELETE запрос на удаление объекта типа препарат по его идентификатору с сервера
    /// </summary>
    /// <param name="id">Идентификатор объекта типа препарат</param>
    /// <returns>Нет возвращаемого значения</returns>
    public async Task ProductDelete(int id) => await Client.ProductDELETEAsync(id);


    /// <summary>
    /// Метод посылает GET запрос на получение коллекции с информацией о средней стоимости препаратов в каждой фармацевтической группе для каждой аптеки
    /// </summary>
    /// <returns>Коллекция объектов в формате JSON с информацией о средней стоимости препаратов в каждой фармацевтической группе для каждой аптеки</returns>
    public async Task<ICollection<PharmaceuticalGroupPriceDto>> PharmaceuticalGroupPriceForEachPharmacy() => await Client.GetPharmaceuticalGroupPriceForEachPharmacyAsync();

    /// <summary>
    /// Метод посылает GET запрос на получение коллекции в формате JSON с названиями аптек в заданном районе, продавших заданный препарат больше заданного объёма
    /// </summary>
    /// <param name="district">Район аптеки</param>
    /// <param name="productName">Название препарата</param>
    /// <param name="volume">Объём продажи</param>
    /// <returns>Коллекция в формате JSON с названиями аптек в заданном районе, продавших заданный препарат больше заданного объёма</returns>
    public async Task<ICollection<string>> PharmaciesWithLargeProductSoldVolume(string district, string productName, int volume) => await Client.GetPharmaciesWithLargeProductSoldVolumeAsync(district, productName, volume);

    /// <summary>
    /// Метод посылает GET запрос на получение коллекции в формате JSON с названиями аптек, в которых заданный препарат продаётся с минимальной ценой
    /// </summary>
    /// <param name="productName">Название препарата</param>
    /// <returns>Коллекция в формате JSON с названиями аптек, в которых заданный препарат продаётся с минимальной ценой</returns>
    public async Task<ICollection<string>> PharmaciesWithMinProductPrice(string productName) => await Client.GetPharmaciesWithMinProductPriceAsync(productName);

    /// <summary>
    /// Метод посылает GET запрос на получение коллекции объектов в формате JSON с информацией о всех аптеках, у которых есть в наличии заданный препарат, с указанием количества данного препарата в них
    /// </summary>
    /// <param name="productName">Название препарата</param>
    /// <returns>Коллекция объектов в формате JSON с информацией о всех аптеках, у которых есть в наличии заданный препарат, с указанием количества данного препарата в них</returns>
    public async Task<ICollection<ProductCountDto>> ProductCountForEachPharmacy(string productName) => await Client.GetProductCountForEachPharmacyAsync(productName);

    /// <summary>
    /// Метод посылает GET запрос на получение коллекции объектов в формате JSON с информацией о характеристиках препаратов в заданной аптеке, упорядоченный по названию препарата
    /// </summary>
    /// <param name="pharmacyName">Название аптеки</param>
    /// <returns>Коллекция объектов в формате JSON с информацией о характеристиках препаратов в заданной аптеке, упорядоченный по названию препарата</returns>
    public async Task<ICollection<ProductForPharmacyDto>> ProductsForPharmacy(string productName) => await Client.GetProductsForPharmacyAsync(productName);

    /// <summary>
    /// Метод посылает GET запрос на получение коллекции объектов в формате JSON с информацией о топ 5 аптеках по количеству и объёму продаж заданного препарата в заданном временном интервале
    /// </summary>
    /// <param name="productName">Название препарата</param>
    /// <param name="start">Начало временного интервала</param>
    /// <param name="end">Конец временного интервала</param>
    /// <returns>Коллекция объектов в формате JSON с информацией о топ 5 аптеках по количеству и объёму продаж заданного препарата в заданном временном интервале</returns>
    public async Task<ICollection<ProductSoldVolumeDto>> TopFivePharmaciesBySoldVolume(string productName, DateTimeOffset start, DateTimeOffset end) => await Client.GetTopFivePharmaciesBySoldVolumeAsync(productName, start, end);
}
