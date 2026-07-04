// See https://aka.ms/new-console-template for more information
using System.Text.Json.Serialization;

Console.WriteLine("Hello, World!");



public class Product
{

    public Product(decimal price, string name, string description, string priceType)
    {
        _price = price;
        _name = name;
        _description = description;
        _priceType = priceType;
    }

    public Product AddProduct(decimal price, string name, string description, string priceType)
    {
        return new Product(price, name, description, priceType);
    }
    private decimal _price;
    private string _name;
    private string _description;
    private string _priceType;

    public decimal Price
    {
        get
        {
            return _price;
        }

        set
        {
            if(value == 0) 
               throw new ArgumentNullException(nameof(value));

            _price = value;
        }
    }


    public string Name
    {
        get
        {
            return _name;
        }

        private set
        {
            if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            _name = value;
        }
    }
    public string Description
    {
        get {  return _description; }
        set { _description = value; }
    }


    public string PriceType
    {
        get { return _priceType; }
        set { _priceType = value; }
    }
}