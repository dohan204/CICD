using Api.Controllers;

namespace Api.Repositories;


public interface IHomeRepository
{
    Product? GetProduct(int id);
    void AddProduct(Product product);
    IEnumerable<Product> GetProducts();
}



public class HomeRepository : IHomeRepository
{
    public static readonly List<Product> products = new List<Product>()
    {
        new Product {Id = 1, Name = "Máy tính", Description = "day la máy tính", Price = 200000m, Quantity = 12},
        new Product {Id = 2, Name = "Điện thoại", Description = "Day la dien thoại", Price = 1500000m, Quantity = 15}

    };
    public Product? GetProduct(int id)
    {
        return products.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Product> GetProducts()
    {
        return products;
    }

    public void AddProduct(Product product)
    {
        int newProductId = products.Max(x => x.Id) + 1;
        Product newProduct = new Product()
        {
            Id = newProductId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Quantity = product.Quantity,
        };

        products.Add(newProduct);
    }
}