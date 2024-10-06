using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_2_Melvin_Friberg
{

    class Kund//skapar en klass kund
    {
        public string Name { get; set; }
        public string Password { get; set; }
        private List<Product> Cart { get; set; }//en privat kundvagn för kunderna

        public Kund(string name, string password)
        {
            Name = name;
            Password = password;
            Cart = new List<Product>();
        }

        //public List<Kund> Kunds { get; set; } = new List<Kund>();
        public void AddToCart(Product product)//Gör en Addtocart metod som sparar produkter i kundernas carts
        {
            Cart.Add(product);
        }
        public List<Product> GetCart()//Skapar en getter som ska hämta innehållet ifrån kundvagnen
        {
            return Cart;
        }
        public override string ToString()//En Tostring metod som kommer skriva ut kundens inloggningsuppgifter i kundvagnen
        {
            string cartContents = Cart.Count > 0 ? string.Join(", ", Cart) : "Kundvagnen är tom";
            return $"Kund Användarnamn: {Name}\nLösenord: {Password}";
        }

    }
    
    public class Product//Skapar en produkt klass som har namn ock pris
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}




