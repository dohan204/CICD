using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private readonly HomeService homeService;
    public HomeController(HomeService homeService)
    {
        this.homeService = homeService;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = homeService.GetProducts();
        return Ok(products);
    }
    [HttpGet("{Id}")]
    public IActionResult GetProduct(int Id)
    {
        var product = homeService.GetProduct(Id) as Product;
        return Ok(product);
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        homeService.AddProduct(product);
        return CreatedAtAction(nameof(GetProduct), new { Id = product.Id}, product);
    }
}


public class Product
{
    public int Id { get; set;}
    public required string Name {get; set;}
    public required string Description {get; set;}
    public decimal Price {get; set;}
    public int Quantity {get; set;}
}