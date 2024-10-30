namespace CityPharmacyChain.Domain.Entity;

/// <summary>
/// Перечисление, характеризующее тип оплаты
/// </summary>
public enum PaymentType
{
    /// <summary>
    /// Оплата наличными
    /// </summary>
    Cash,

    /// <summary>
    /// Оплата картой
    /// </summary>
    Cashless,

    /// <summary>
    /// Тип оплаты не задан
    /// </summary>
    Null
}
