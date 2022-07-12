namespace csharp_ecommerce_db
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");

            // Login();
            // InserimentoProdottoUtente();
            // InserisciOrdini();
            ricercaOrdini();


            bool Login()
            {
                bool validator = false;
                Console.WriteLine("Effettua il login");
                Console.WriteLine("Inserisci il tuo nome: ");
                string nome = Console.ReadLine();

                Console.WriteLine("Inserisci il tuo cognome: ");
                string cognome = Console.ReadLine();

                Console.WriteLine("Inserisci la tua email: ");
                string email = Console.ReadLine();

                using(ECommerceContext context = new ECommerceContext())
                {
                    foreach (Customer customer in context.Customers)
                    {
                        if(customer.Name == nome && customer.Surname == cognome && customer.Email == email)
                        {
                            Console.WriteLine("Login effettuato");
                            validator = true;
                        }
                        else
                        {
                            Console.WriteLine("Dati non corretti");
                            
                        }
                    }
                    return validator;
                }
                
;            }

            void InserisciOrdini()
            {
                using (ECommerceContext context = new ECommerceContext())
                {
                    Console.WriteLine("Lista articoli: ");

                    List<Product> products = context.Products.OrderBy(product => product.Name).ToList<Product>();

                    foreach (Product prod in products)
                    {
                        Console.WriteLine("Prodotto: " + prod.ProductId + " " + prod.Name);
                    }


                    Console.WriteLine("Digita il numero dell'articolo che desideri acquistare");
                    int scelta = Int32.Parse(Console.ReadLine());
                 


                    List<Product> listaProdotti = new List<Product>();
                    foreach (Product prod in products)
                    {
                        if(scelta == prod.ProductId)
                        {
                            listaProdotti.Add(prod);
                            Console.WriteLine("Aggiunto al carrello");
                            context.SaveChanges();
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine("Effettua il login");
                    Console.WriteLine("Inserisci il tuo nome: ");
                    string nome = Console.ReadLine();

                    Console.WriteLine("Inserisci il tuo cognome: ");
                    string cognome = Console.ReadLine();

                    Console.WriteLine("Inserisci la tua email: ");
                    string email = Console.ReadLine();
                    List<Customer> customerList = context.Customers.ToList<Customer>();

                    foreach (Customer customer in customerList)
                    {
                        if (customer.Surname == cognome && customer.Email == email && customer.Name == nome)
                        {
                            Order newOrder = new Order(customer, listaProdotti);
                            context.Add(newOrder);
                            context.SaveChanges();
                        }
                    }
                }
            }


            void InserimentoProdottoUtente()
            {
                Console.WriteLine("Cosa vuoi fare?");
                Console.WriteLine("1-inserire un nuovo utente");
                Console.WriteLine("2-aggiungere un nuovo prodotto");

                int scelta = Int32.Parse(Console.ReadLine());

                if (scelta == 1)
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
                        Customer nuovoUtente = new Customer { Name = nomeUtente, Surname = cognomeUtente, Email = emailUtente };
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

            void ricercaOrdini()
            {
                Console.WriteLine("Inserisci il nome per effettuare la ricerca dell'ordine");
                string nome = Console.ReadLine();

                using(ECommerceContext context = new ECommerceContext())
                {
                    List<Customer> listaClienti = context.Customers.ToList<Customer>();
                    //List<Order> listaOrdini = context.Orders.ToList<Order>();

                    foreach(Customer customer in listaClienti)
                    {
                        if(nome == customer.Name)
                        {
                            Console.WriteLine("La lista dei tuoi ordini: ");
                            List<Order> listaOrders = context.Orders.Where(order => order.CustomerId == customer.CustomerId).ToList<Order>();
                            foreach(Order order in listaOrders)
                            {
                                Console.WriteLine("Id ordine: " + order.CustomerId);
                                Console.WriteLine("Totale ordine: " + order.Amount);
                            }
                        }
                    }
                }

                
            }

        }
    }
}