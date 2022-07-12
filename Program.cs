namespace csharp_ecommerce_db
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");

            Console.WriteLine("Cosa vuoi fare?");
            Console.WriteLine("1-inserire un nuovo utente");
            Console.WriteLine("2-aggiungere un nuovo prodotto");

            int scelta = Int32.Parse(Console.ReadLine());

            if(scelta == 1)
            {
                Console.WriteLine("Inserisci un nuovo utente: ");
                Console.WriteLine("Inserisci il nome dell?utente: ");
                string nomeUtente = Console.ReadLine();

                Console.WriteLine("Inserisci il cognome dell'utente: ");
                string cognomeUtente = Console.ReadLine();

                Console.WriteLine("Inserisci l'email dell'utente: ");
                string emailUtente = Console.ReadLine();

                using (ECommerceContext context = new ECommerceContext())
                {
                    Customer nuovoUtente = new Customer { Name = nomeUtente, Surname = cognomeUtente, Email = emailUtente};
                    context.Add(nuovoUtente);
                    context.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("Inserisci un nuovo prodotto: ");
                Console.WriteLine("Inserisci il nome del prodotto: ");
                string nomeProdotto = Console.ReadLine();

                Console.WriteLine("Inserisci la descrizione del prodotto: ");
                string descrizioneProdotto = Console.ReadLine();

                Console.WriteLine("Inserisci il prezzo del prodotto: ");
                double prezzoProdotto = double.Parse(Console.ReadLine());

                using (ECommerceContext context = new ECommerceContext())
                {
                    Product nuovoProdotto = new Product { Name = nomeProdotto, Description = descrizioneProdotto, Price = prezzoProdotto };
                    context.Add(nuovoProdotto);
                    context.SaveChanges();
                }
            }


        }
    }
}