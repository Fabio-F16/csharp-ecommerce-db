namespace csharp_ecommerce_db
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");


            using (ECommerceContext context = new ECommerceContext())
            {
                Product prodotto1 = new Product { Name = "Cuffioni", Description = "Text text text text text text", Price = 19.99 };
                Product prodotto2 = new Product { Name = "Cellularone", Description = "Text text text text text text", Price = 19.99 };
                Product prodotto3 = new Product { Name = "Ciabattone", Description = "Text text text text text text", Price = 19.99 };
                context.Add(prodotto1);
                context.Add(prodotto2);
                context.Add(prodotto3);
                context.SaveChanges();
            }
        }
    }
}