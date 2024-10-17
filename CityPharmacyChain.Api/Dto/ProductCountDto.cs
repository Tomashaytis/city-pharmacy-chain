﻿namespace CityPharmacyChain.Api.Dto;

/// <summary>
/// Класс DTO для сущности класса количество препаратов на складе аптеки
/// </summary>
/// <param name="productName">Название препарата</param>
/// <param name="pharmacyName">Название препарата</param>
/// <param name="count">Количество препарата на складе аптеки</param>
public class ProductCountDto(string productName = "", string pharmacyName = "", int count = 0)
{
    /// <summary>
    /// Название препарата
    /// </summary>
    public string ProductName { get; set; } = productName;

    /// <summary>
    /// Название аптеки
    /// </summary>
    public string PharmacyName { get; set; } = pharmacyName;

    /// <summary>
    /// Количество препарата на складе аптеки
    /// </summary>
    public int Count { get; set; } = count;
}
