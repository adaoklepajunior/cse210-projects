using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("20 W 34th St.", "New York", "NY", "USA");
        Address address2 = new Address("7474 Charmant Dr", "San Diego", "CA", "USA");
        Address address3 = new Address("525 Estado de Israel street", "La Bajada", "SF", "ARG");

        // Create customers
        Customer customer1 = new Customer("Al Pacino", address1);
        Customer customer2 = new Customer("Tony Hawk", address2);
        Customer customer3 = new Customer("Lionel Messi", address3);

        // Create products
        Product product1 = new Product("pool table equipment", "PTE555", 999.99m, 1);
        Product product2 = new Product("running shoes", "RUN366", 149.99m, 2);
        Product product3 = new Product("weight machine", "WEY789", 1289.99m, 1);
        Product product4 = new Product("gym equipment", "GYN012", 1199.99m, 2);
        Product product5 = new Product("roller skates", "ROL345", 149.99m, 1);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        Order order3 = new Order(customer3);
        order3.AddProduct(product2);
        order3.AddProduct(product4);

        // Display order details
        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
        DisplayOrderDetails(order3);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Cost: {order.GetTotalCost():C}");
        Console.WriteLine();
    }
}