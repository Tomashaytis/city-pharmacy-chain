# Аптекарская сеть города

## Используемые классы:
<b>Pharmacy</b> - класс, определяющий аптеку.
Основные поля:
1) <b>PharmacyNumber</b> - номер аптеки;
2) <b>Name</b> - название аптеки;
3) <b>PhoneNumber</b> - номер телефона аптеки;
4) <b>Address</b> - адрес аптеки;
5) <b>DirectorFullName</b> - ФИО директора.

<b>Product</b> - класс, определяющий лекарственный препарат.
Основные поля:
1) <b>ProductCode</b> - код продукта;
2) <b>Name</b> - название препарата;
3) <b>ProductGroup</b> - группа препарата.

<b>PriceListEntry</b> - класс, определяющий запись в прайс-листе.
Основные поля:
1) <b>ProductCode</b> - код препарата;
2) <b>PharmacyNumber</b> - номер аптеки;
3) <b>Price</b> - цена препарата;
4) <b>SoldCount</b> - количество проданных препаратов;
5) <b>Manufacturer</b> - производитель препарата;
6) <b>PaymentType</b> - способ оплаты;
7) <b>SaleDate</b> - дата продажи.

<b>PharmaceuticalGroup</b> - класс, определяющий фармацевтическую группу препарата.
Основные поля:
1) <b>Name</b> - имя группы;
2) <b>ProductCode</b> - код препарата.

<b>PharmacyProduct</b> - класс, определяющий все товары, хранимые в аптеках.
Основные поля:
1) <b>PharmacyNumber</b> - номер аптеки;
2) <b>ProductCode</b> - код препарата;
3) <b>Count</b> - количество товара на складе аптеки.

## Реализованные тесты
1) Корректность вывода сведений о всех препаратах в заданной аптеке, упорядоченных по 
названию.
2) Корректность вывода для данного препарата подробного списка всех аптек с указанием 
количества препарата в аптеках.
3) Корректность вывода информации о средней стоимости препаратов в каждой 
фармацевтической группе для каждой аптеки.
4) Корректность вывода топ 5 аптек по количеству и объёму продаж данного препарата за 
указанный период времени.
5) Корректность вывода списка аптек указанного района, продавших заданный препарат 
более указанного объёма.
6) Корректность вывода списка аптек, в которых указанный препарат продается с 
минимальной ценой.
