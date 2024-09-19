using CityPharmacyChainLibrary;

namespace CityPharmacyChainTest;

[TestClass]
public class PharmacyUnitTest
{
    public Pharmacy Pharmacy { get; set; }

    public PharmacyUnitTest()
    {
        Pharmacy = new Pharmacy(231, "����", 85466382313, "�. ������, ��. ����-�������, �. 36", "������ ���� ��������");
    }

    [TestMethod]
    public void TestCreate()
    {
        Assert.AreEqual(Pharmacy.Number, 231);
        Assert.AreEqual(Pharmacy.Name, "����");
        Assert.AreEqual(Pharmacy.PhoneNumber, 85466382313);
        Assert.AreEqual(Pharmacy.Address, "�. ������, ��. ����-�������, �. 36");
        Assert.AreEqual(Pharmacy.Director, "������ ���� ��������");
    }
}