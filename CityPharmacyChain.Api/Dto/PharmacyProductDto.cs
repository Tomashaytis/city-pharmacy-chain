﻿namespace CityPharmacyChain.Api.Dto;

/// <summary>
/// Класс DTO для сущности класса связь препарат-аптека
/// </summary>
/// <param name="productId">Идентификатор препарата</param>
/// <param name="pharmacyId">Идентификатор аптеки</param>
/// <param name="count">Количество препарата на складе аптеки</param>
/// <param name="price">Цена препарата</param>
public class PharmacyProductDto(int productId = 0, int pharmacyId = 0, int count = 0, double price = 0)
{
    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public int ProductId { get; set; } = productId;

    /// <summary>
    /// Идентификатор аптеки
    /// </summary>
    public int PharmacyId { get; set; } = pharmacyId;

    /// <summary>
    /// Количество препарата на складе аптеки
    /// </summary>
    public int Count { get; set; } = count;

    /// <summary>
    /// Цена препарата
    /// </summary>
    public double Price { get; set; } = price;
}
