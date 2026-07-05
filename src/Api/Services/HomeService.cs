using Api.Controllers;
using Api.Repositories;

namespace Api.Services;


public class HomeService
{
    private readonly IHomeRepository homeRepository;
    public HomeService(IHomeRepository homeRepository)
    {
        this.homeRepository = homeRepository;
    }
    public IEnumerable<Product> GetProducts()
    {
       return this.homeRepository.GetProducts();
    }

    public Product? GetProduct(int productId)
    {
        return this.homeRepository.GetProduct(productId);
    }

    public void AddProduct(Product product)
    {
        if(string.IsNullOrEmpty(product.Name))
        {
            throw new ArgumentException(nameof(product.Name));
        }
        if(string.IsNullOrEmpty(product.Description))
        {
            throw new ArgumentException(nameof(product.Description));
        }

        if(product.Price <= 0 || product.Quantity < 0)
        {
            throw new ArgumentException("Giá phải lớn hơn 0 hoặc số lượng không được âm.");
        }

        this.homeRepository.AddProduct(product);
    }

}