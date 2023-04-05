using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppingLib.Models;

using IHost host = CreateHostBuilder(args).Build();

using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;

ShoppingCart shoppingCart = new ShoppingCart();

try
{
    Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}


static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args);
}

void Run()
{
    AddItemsToShoppingCart();

    Console.WriteLine($"The total for the cart is {shoppingCart.GetCartTotal(DisplaySubTotal, CalculateLevelDiscount, NotifyCustomer):C2}");

    Console.WriteLine();
    Console.Write("Press any key to exit...");
    Console.ReadLine();
}

void AddItemsToShoppingCart()
{
    shoppingCart.AddItems(new Product { ItemName = "Coffee", Price = 21.65M });
    shoppingCart.AddItems(new Product { ItemName = "Milk", Price = 3.78M });
    shoppingCart.AddItems(new Product { ItemName = "Butter", Price = 4.99M });
    shoppingCart.AddItems(new Product { ItemName = "Bread", Price = 3.75M });
    shoppingCart.AddItems(new Product { ItemName = "Olive Oil", Price = 12.68M });
}

void DisplaySubTotal(decimal subTotal)
{
    Console.WriteLine($"Your cart subtotal before discount {subTotal:C2}");
}

decimal CalculateLevelDiscount(IEnumerable<Product> items, decimal subTotal )
{
    switch (subTotal)
    {
        case > 100:
            return subTotal * 0.80M;
        case > 50:
            return subTotal * 0.85M;
        case > 10:
            return subTotal * 0.95M;
        default:
            return subTotal;
    }
}

void NotifyCustomer(string message)
{
    Console.WriteLine(message);
}