namespace Laboration_2_Melvin_Friberg;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Laboration_2_Melvin_Friberg;

    internal class Program
    {
        static List<Kund> users = new List<Kund>();//Skapar en lista med alla kunder som finns registrerade
        static void Main(string[] args)
        {
        users.Add(new Kund("Knatte", "pw123"));
        
            while (true)
            {
                
                Console.WriteLine("1. Logga in");
                Console.WriteLine("2. Skapa användare");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        LoggaIn();//Metod för inloggning
                        break;
                    case "2":
                        SkapaAnvändare();//Metod för att skapa en användare
                        break;
                    default:
                        Console.WriteLine("Ogiltligt val, försök igen");
                        break;
                }
            }

            static void LoggaIn()//Logga in metod
            {
                Console.Clear();
                Console.WriteLine("Skriv in användarnamn");
                string username = Console.ReadLine();
                Console.WriteLine("Skriv in ett Lösenord");
                string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(username) || (string.IsNullOrWhiteSpace(password)))//Om det inte finns något värde i strängarna
            {
                Console.WriteLine("Du har inte angett något värde, försök igen");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            bool loginklar = false;//skapar en bool variabel som kollar så att värderna och inloggningen lyckades, hade bara massa if och else if men felmeddelandet kom när man loggade ut hela tiden, så jag fick skapa en bool variabel istället.
            {
                foreach (var user in users)
                {
                    if (user.Name == username && user.Password == password)//kollar så att inloggningen matchar med det som är sparat
                    {
                        Console.WriteLine($"Du är nu inloggad som {username}");
                        Console.WriteLine("tryck 'Enter' för att gå vidare till butiken");
                        Console.ReadLine();
                        HuvudMeny(user);//Går till huvudmenyn
                        loginklar = true;
                        break;

                    }
                }
                if (!loginklar)
                {
                    Console.WriteLine("Användarnamnet eller Lösenordet du angivit är fel, Försök gärna igen");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

                
            }


            static void SkapaAnvändare()//en metod för att skapa en användare
            {
                Console.Clear();
                Console.WriteLine("Skriv in ditt användarnamn");
                string name = Console.ReadLine();
                Console.WriteLine("Skriv in ditt Lösenord");
                string password = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name) || (string.IsNullOrWhiteSpace(password)))//Om det inte finns något värde i strängarna
            {
                    Console.WriteLine("Användarnamn eller Lösenord kan inte vara tomt, Försök igen");
                    Console.ReadLine();
                    Console.Clear();
                }
            foreach (var user in users)//Loopar igenom kund listan
            {
                if (user.Name.Equals(name, StringComparison.OrdinalIgnoreCase))//Kollar om det ny skapade användarnamnet är upptaget eller inte
                {
                    Console.WriteLine("Användarnamnet är upptaget, försök med något nytt");
                    Console.ReadLine();
                    Console.Clear();
                    return;
                }
            }
                var kund = new Kund(name, password);//Lägger till en ny kund i listan "Kund"
                users.Add(kund);
                Console.WriteLine($"Du har nu skapat ett nytt konto och ditt användarnamn är: {name}");
                Console.WriteLine();
                Console.WriteLine("Tryck 'Enter' för att Fortsätta");
                Console.ReadLine();
                Console.Clear();
            
                

            }
          

            static void HuvudMeny(Kund user)//Huvudmenyn i användarens profil 
            {
           
            decimal totalaPris = 0;//skapar en decimal för totalpriset
            bool meny = true;
                while (meny)
                {
                

                    //----------V BUTIKEN V------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Hejsan  och välkommen till Melvins Livs!");
                    Console.ResetColor();
                    Console.WriteLine("Vänligen klicka på de alternativ som är bäst för dig");
                    Console.WriteLine("1. Handla i Butiken");
                    Console.WriteLine("2. Se kundvagnen");
                    Console.WriteLine("3. Gå till kassan");
                    Console.WriteLine("4. Logga ut");
                    string input = Console.ReadLine();

                    switch (input)// skapar upp en meny
                    {

                        case "1"://Handla i butiken
                            bool innreMeny = true;
                            while (innreMeny)//skapar en innre meny för att visa upp och handla på ett lätt sätt
                            {
                                List<Product> products = new List<Product>();//Gör en lista med alla produkter som finns
                                Product banan = new Product("Banan", 15);
                                Product pasta = new Product("Pasta", 20);
                                Product mjölk = new Product("Mjölk", 25);
                                products.Add(pasta);
                                products.Add(banan);
                                products.Add(mjölk);

                                Console.Clear();
                                Console.WriteLine("---------Butikens Varor---------");
                                foreach (var product in products)//Skapar en foreach loop som ska skriva ut alla varor för användaren
                                {
                                    Console.WriteLine($"Produkten: {product.Name}, Pris: {product.Price}kr");//Skriver ut namn på produkterna och även pris
                                }
                                Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Dessa är alla produkter vi har för tillfället");
                            Console.WriteLine("Välj produkt med hjälp av siffrorna på tangentbordet 1 Till 3");
                            Console.WriteLine("1 = Längst upp");
                            Console.WriteLine("3 = Längst ner");
                            Console.WriteLine("Skriv back för att gå tillbaka");
                                string köp = Console.ReadLine();
                                switch (köp)//En köp funktion som fungerar som menyval
                                {

                                    case "1":
                                        user.AddToCart(banan);//Lägger till banan i kundvagnen
                                        Console.WriteLine($"1st Banan har lagts till i kundvagnen");
                                        Console.WriteLine("Tryck 'Enter' för att gå vidare");
                                        Console.ReadLine();
                                        break;

                                    case "2":
                                        user.AddToCart(pasta);//Lägger till pasta i kundvagnen
                                        Console.WriteLine($"1st Pasta har lagts till i kundvagnen");
                                        Console.WriteLine("Tryck 'Enter' för att gå vidare");
                                        Console.ReadLine();
                                        break;
                                    case "3":
                                        user.AddToCart(mjölk);//Lägger till mjölk i kundvagnen
                                        Console.WriteLine($"1st Mjölk har lagts till i kundvagnen");
                                        Console.WriteLine("Tryck 'Enter' för att gå vidare");
                                        Console.ReadLine();
                                        break;

                                    case "back"://avbryter menyn och går tillbaka till huvudmenyn
                                        innreMeny = false;
                                        break;

                                    default:
                                        Console.WriteLine("Ogiltligt val");//Felmeddelande
                                        break;
                                }
                            }
                            break;

                        case "2"://Skriva ut Kundvagn
                        var cart = user.GetCart();//anropar GetCart ifrån den inloggande "user"
                        Console.Clear();
                        Console.WriteLine(user.ToString());// skriver ut namn och lösenord på användaren
                        Console.WriteLine("-----------------------------------");
                        
                            if (cart.Count == 0)//Om kundvagnen är tom 
                                {
                                    Console.WriteLine("Din kundvagn är tom.");
                                }
                                else
                                Console.WriteLine("---Din kundvagn innehåller---");
                            
                                foreach (var product in cart)//Loopar igenom användarens Cart och kollar alla produkter i den
                                {
                                Console.WriteLine($"{product.Name}, {product.Price}kr");//Skriver ut både namn och pris
                                }
                                totalaPris = 0;//Sätter priset till 0 igen, annars ökar det för varje gång man går in

                                for (int i = 0; i < cart.Count; i++)//En for loop som ska loopa igenom alla varor och räkna ut priset
                                {
                                var product = cart[i];
                                totalaPris += product.Price;//beräknar kostnaden av allt
                                }
                                Console.WriteLine("---------------------");
                                Console.WriteLine($"Totalt Pris: {totalaPris}kr");//Totala priset i kundvagnen
                                Console.WriteLine("---------------------");
                                Console.WriteLine("Tryck 'ENTER' för att gå tillbaka till Menyn");
                                Console.ReadLine();
                                break;
                        case "3":
                        Console.WriteLine("Välkommen till kassan!");
                        Console.WriteLine($"Din totala kostnad är {totalaPris}kr ");
                        Console.WriteLine("Hur vill du betala? Kort eller Kontant?");
                        string betala = Console.ReadLine();
                        if(betala.ToLower() == "kort")
                        {
                            Console.WriteLine("Sorry plånkan is at home");
                        }
                        else if (betala.ToLower() == "kontant")
                        {
                            Console.WriteLine("Du har inga pengar");
                        }
                        Console.ReadLine();
                        break;
                        case "4":
                        Console.WriteLine("Är du säker på att du vill logga ut? y/n");//Ett val för att logga ut ifrån programmet
                        string userinput = Console.ReadLine();
                        if (userinput.ToLower() == "y")
                        {
                            meny = false;//Menyn blir falskt och återgår till logga in eller skapa användare
                            Console.Clear();
                        }
                        else if (userinput.ToLower() == "n")
                        {
                            break;
                        }
                        break;
                    default: Console.WriteLine("Ogiltligt val");
                        break;
                    }
                

                }
            }
        }
    }

