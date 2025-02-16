using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Product class
class Product
{
    public string ProductID { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }

    // Constructor to initialize product details
    public Product(string productId, string productName, double price)
    {
        ProductID = productId;
        ProductName = productName;
        Price = price;
    }
}

// ShoppingCart class
class ShoppingCart
{
    private List<Product> products = new List<Product>();

    // Method to add a product to the shopping cart
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // Method to remove a product from the shopping cart by its ID
    public void RemoveProduct(string productId)
    {
        Product productToRemove = products.Find(p => p.ProductID == productId);
        if (productToRemove != null)
        {
            products.Remove(productToRemove);
            Console.WriteLine($"Product {productId} has been removed from the cart.");
        }
        else
        {
            Console.WriteLine($"Product {productId} not found in the cart.");
        }
    }

    // Method to calculate the total price of all products in the cart
    public double CalculateTotalPrice()
    {
        double total = 0;
        foreach (Product product in products)
        {
            total += product.Price;
        }
        return total;
    }

    // Method to display the list of products in the cart
    public void DisplayProducts()
    {
        Console.WriteLine("Products in your cart:");
        foreach (Product product in products)
        {
            Console.WriteLine($"{product.ProductName} - ${product.Price}");
        }
    }
}

class Program
{
    static void Main()
    {
        // Create some products
        Product product1 = new Product("001", "Laptop", 999.99);
        Product product2 = new Product("002", "Smartphone", 499.99);
        Product product3 = new Product("003", "Headphones", 89.99);

        // Create a shopping cart
        ShoppingCart cart = new ShoppingCart();

        // Add products to the cart
        cart.AddProduct(product1);
        cart.AddProduct(product2);
        cart.AddProduct(product3);

        // Display the products in the cart
        cart.DisplayProducts();

        // Calculate and display the total price
        Console.WriteLine($"Total Price: ${cart.CalculateTotalPrice()}");

        // Remove a product from the cart
        Console.WriteLine("\nRemoving product with ID '002'...");
        cart.RemoveProduct("002");

        // Display updated list of products
        cart.DisplayProducts();

        // Calculate and display the updated total price
        Console.WriteLine($"Updated Total Price: ${cart.CalculateTotalPrice()}");
    }
}
