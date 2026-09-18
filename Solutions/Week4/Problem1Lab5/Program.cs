// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Metrics;
using System.Reflection;

Console.WriteLine("Hello, World!");

// Sample data
Invoice[] invoices =
[
    new Invoice(83, "Electric sander", 7, 57.98M),
    new Invoice(24, "Power saw", 18, 99.99M),
    new Invoice(7 , "Sledge hammer", 11, 21.50M),
    new Invoice(77, "Hammer", 76, 11.99M),
    new Invoice(39, "Lawn mower", 3, 79.50M),
    new Invoice(68, "Screwdriver", 106, 6.99M),
    new Invoice(56, "Jig saw", 21, 11.00M),
    new Invoice(3, "Wrench", 34, 7.50M),
    new Invoice(83, "Electric sander", 17, 57.98M),
    new Invoice(24, "Power saw", 28, 99.99M),
    new Invoice(7 , "Sledge hammer", 67, 21.50M),
    new Invoice(77, "Hammer", 64, 11.99M),
];

Console.WriteLine("Sort by part description...");

// declare LINQ
var sortedByDesc =
    from invoice in invoices
    orderby invoice.PartDescription
    select invoice;

// Sorted lambda version
var sortedByDescLambda = invoices
                          .OrderBy(invoice => invoice.PartDescription)
                          .ThenByDescending(invoice => invoice.Quantity);

// execute LINQ
foreach (var invoice in sortedByDesc)
{
    Console.WriteLine($"{invoice} ");
}

Console.WriteLine();

foreach (var invoice in sortedByDescLambda)
{
    Console.WriteLine($"{invoice} ");
}

Console.WriteLine();
Console.WriteLine("Sort by invoice price...");

// sort by invoice price
var sortedByPrice =
    from invoice in invoices
    let price = invoice.Price * invoice.Quantity
    orderby price descending
    select new {Invoice=invoice, Price=price };

// with tuple
var sortedByPriceTuple =
    from invoice in invoices
    let price = invoice.Price * invoice.Quantity
    orderby price descending
    select (Invoice: invoice, Price: price );

foreach (var invoice in sortedByPrice)
{
    Console.WriteLine($"Invoice price {invoice.Price,8}$ for {invoice.Invoice}");
}

Console.WriteLine();
Console.WriteLine("Sorted by invoice price (with tuple)...");

foreach (var invoice in sortedByPrice)
{
    Console.WriteLine($"Invoice price {invoice.Price,8}$ for {invoice.Invoice}");
}

Console.WriteLine();
Console.WriteLine("Filtered results...");

var invoiceBetween = 
    from invoice in sortedByPriceTuple
    where invoice.Price > 200 && invoice.Price < 500
    select invoice;

foreach (var invoice in invoiceBetween)
{
    Console.WriteLine($"Invoice price {invoice.Price,8}$ for {invoice.Invoice}");
}

// lambda version
var invoiceBetweenLambda = sortedByPriceTuple
    .Where(inv => inv.Price > 200 && inv.Price < 500);

Console.WriteLine();
Console.WriteLine("Filtered results with lambda...");

foreach (var invoice in invoiceBetweenLambda)
{
    Console.WriteLine($"Invoice price {invoice.Price,8}$ for {invoice.Invoice}");
}