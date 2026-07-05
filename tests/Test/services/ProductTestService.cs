using Api.Controllers;
using Api.Repositories;
using Api.Services;
using Moq;

namespace Test.services;


[TestFixture]
public class ProductTestService
{
    private Mock<IHomeRepository> _repositoryMock;
    private HomeService _homeService;
    [SetUp]
    public void Setup()
    {
        _repositoryMock = new Mock<IHomeRepository>();
        _homeService = new HomeService(_repositoryMock.Object);
    }

    private static IEnumerable<Product> DataTest()
    {
        yield return new Product {Id = 1, Name = "", Description = "Day la san pham tỏng", Price = 1000000m, Quantity = 50};
        yield return new Product {Id = 2, Name = "máy tính", Description = "", Price = 100000m, Quantity = 12};
        yield return new Product {Id = 3, Name = "Điện thoại", Description = "Day la dient haoi", Price = 0, Quantity = 10};
        yield return new Product {Id = 4, Name = "Tủ lạnh", Description = "day la tu lanh", Price = 1000m, Quantity = -1};
    }
    [Test]
    public void GetProduct_ShouldReturnProduct_WhenProductExists()
    {
        // arr
        var product = new Product {Id = 1, Name = "máy tính",  Description = "hóidf", Price = 12000m, Quantity = 1000};
        _repositoryMock.Setup(repo => repo.GetProduct(1)).Returns(product); 


        // act
        var result = _homeService.GetProduct(1);

        // assert
        Assert.That(result,Is.Not.Null);
        Assert.That(result.Name, Is.EqualTo("máy tính"));
    }


    [Test]
    public void GetProduct_ShouldReturnNull_WhenProductNotExists()
    {
        // arrangeL: nếu tìm id = 99 thì trả về null(ép sang kiểu product)
        _repositoryMock.Setup(repo => repo.GetProduct(99)).Returns((Product)null);

        var result = _homeService.GetProduct(99);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void AddProduct_ShouldCallRepository_WhenProductIsValid()
    {
        var validProduct = new Product { Id = 1, Name = "Máy tính", Description = "Day la may tinh cua han", Price = 500000m, Quantity = 10};

        //act 
        _homeService.AddProduct(validProduct);

        // ass
        _repositoryMock.Verify(repo => repo.AddProduct(validProduct), times: Times.Once());

    }
    [Test]
    [TestCaseSource(nameof(DataTest))]
    public void AdđProduct_ShouldThrowException_WhenProductIsInvalid(Product product)
    {
        // ass & act
        Assert.Throws<ArgumentException>(() => _homeService.AddProduct(product));

        // kiểm tra xem nó có được gọi không, dữ liệu sai thì không được gọi 
        _repositoryMock.Verify(repo => repo.AddProduct(It.IsAny<Product>()), times: Times.Never());
    }

}