
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
using System.Threading.Channels;

List<Product> products = new List<Product>
        {
            new Product { Name = "Sonnet Collection", Price = 15.99m, ProductTypeId = 1 },
            new Product { Name = "The Art of Poetry", Price = 20.50m, ProductTypeId = 1 },
            new Product { Name = "Trumpet", Price = 300.00m, ProductTypeId = 2 },
            new Product { Name = "Trombone", Price = 450.00m, ProductTypeId = 2 },
            new Product { Name = "French Horn", Price = 500.00m, ProductTypeId = 2 }
        };
//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>
        {
            new ProductType { Id = 1, Title = "Poetry Book" },
            new ProductType { Id = 2, Title = "Brass Instrument" }
        };
//put your greeting here
Console.WriteLine("Welcome to Brass and Poem!");
//implement your loop here
int chosenOption = 0;
while (chosenOption != 5)
{
    DisplayMenu();
    chosenOption = int.Parse(Console.ReadLine().Trim());

    if (chosenOption == 1)
    {
        DisplayAllProducts(products, productTypes);
    }
    else if (chosenOption == 2)
    {
        DeleteProduct(products, productTypes);
    }
    else if (chosenOption == 3)
    {
        AddProduct(products, productTypes);
    }
    else if (chosenOption == 4)
    {
        UpdateProduct(products, productTypes);
    }

}

void DisplayMenu()
{
    Console.WriteLine(@"Choose an option:
1. Display all products
2. Delete a product
3. Add a new product
4. Update product properties
5. Exit");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    int index = 1;
    foreach (Product product in products)
    {

        ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);

        Console.WriteLine($"{index}. {product.Name} Price: {product.Price} Type: {productType?.Title}");
        index++;
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    int index = 1;
    foreach (Product product in products)
    {

        Console.WriteLine($"{index}. {product.Name}");
        index++;
    }
    Console.WriteLine("Choose a product to delete:");
    int deletedProductId = int.Parse(Console.ReadLine());

    var removedProduct = products[deletedProductId - 1];
    products.Remove(removedProduct);
    Console.WriteLine($"You deleted {removedProduct.Name}");
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Enter the name of the new product:");
    string name = Console.ReadLine();
    Console.WriteLine("Enter the price of the new product:");
    decimal price = decimal.Parse(Console.ReadLine());

    int index = 1;
    foreach (ProductType type in productTypes)
    {

        Console.WriteLine($"{index}. {type.Title}");
        index++;
    }
    Console.WriteLine("Choose a product type:");
    int typeId = int.Parse(Console.ReadLine());

    Product newProduct = new Product()
    {
        Name = name,
        Price = price,
        ProductTypeId = typeId

    };

    products.Add(newProduct);
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);
    Console.WriteLine("Choose a product to update:");

    int chosenProductId = int.Parse(Console.ReadLine());

    Product chosenProduct = products[chosenProductId - 1];

    Console.WriteLine("Enter the name of the updated product:");
    string newName = Console.ReadLine();
    chosenProduct.Name = newName;

    Console.WriteLine("Enter the price of the updated product:");
    decimal newPrice = decimal.Parse(Console.ReadLine());
    chosenProduct.Price = newPrice;

    int index = 1;
    foreach (ProductType type in productTypes)
    {

        Console.WriteLine($"{index}. {type.Title}");
        index++;
    }
    Console.WriteLine("Update the product type:");
    int typeId = int.Parse(Console.ReadLine());
    chosenProduct.ProductTypeId = typeId;

    Console.WriteLine("Product updated successfully.");
}

// don't move or change this!
public partial class Program { }