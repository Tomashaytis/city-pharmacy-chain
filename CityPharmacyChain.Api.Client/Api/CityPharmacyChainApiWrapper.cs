namespace CityPharmacyChain.Api.Client.Api;

/// <summary>
/// Класс-обёртка для класса CityPharmacyChainApi
/// </summary>
/// <param name="configuration">Конфигурация</param>
public class CityPharmacyChainApiWrapper(IConfiguration configuration)
{
    /// <summary>
    /// Экземпляр клиента
    /// </summary>
    public readonly CityPharmacyChainApi Client = new(configuration["OpenApi:ServerUrl"], new HttpClient());

    /// <summary>
    /// Метод, возвращающий коллекцию объектов типа фармацевтическая группа
    /// </summary>
    /// <returns>Коллекция объектов типа фармацевтическая группа</returns>
    public async Task<ICollection<PharmaceuticalGroupFullDto>> PharmaceuticalGroupGetAll() => await Client.PharmaceuticalGroupAllAsync();

    public async Task<PharmaceuticalGroupDto> PharmaceuticalGroupGetById(int id) => await Client.PharmaceuticalGroupGETAsync(id);

    public async Task<PharmaceuticalGroupFullDto> PharmaceuticalGroupPost(PharmaceuticalGroupDto pharmaceuticalGroupDto) => await Client.PharmaceuticalGroupPOSTAsync(pharmaceuticalGroupDto);

    public async Task<PharmaceuticalGroupFullDto> PharmaceuticalGroupPut(int id, PharmaceuticalGroupDto pharmaceuticalGroupDto) => await Client.PharmaceuticalGroupPUTAsync(id, pharmaceuticalGroupDto);

    public async Task PharmaceuticalGroupPut(int id) => await Client.PharmaceuticalGroupDELETEAsync(id);


    /// <summary>
    /// Метод, возвращающий коллекцию объектов типа аптека
    /// </summary>
    /// <returns>Коллекция объектов типа аптека</returns>
    public async Task<ICollection<PharmacyFullDto>> PharmacyGetAll() => await Client.PharmacyAllAsync();


    /// <summary>
    /// Метод, возвращающий коллекцию объектов типа связь препарат-аптека
    /// </summary>
    /// <returns>Коллекция объектов типа связь препарат-аптека</returns>
    public async Task<ICollection<PharmacyProductFullDto>> PharmacyProductGetAll() => await Client.PharmacyProductAllAsync();


    /// <summary>
    /// Метод, возвращающий коллекцию объектов типа запись в прайс-листе
    /// </summary>
    /// <returns>Коллекция объектов типа запись в прайс-листе</returns>
    public async Task<ICollection<PriceListEntryFullDto>> PriceListEntryGetAll() => await Client.PriceListEntryAllAsync();


    /// <summary>
    /// Метод, возвращающий коллекцию объектов типа препарат
    /// </summary>
    /// <returns>Коллекция объектов типа препарат</returns>
    public async Task<ICollection<ProductFullDto>> ProductGetAll() => await Client.ProductAllAsync();

}
