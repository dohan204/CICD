// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



public class Product
{
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
}