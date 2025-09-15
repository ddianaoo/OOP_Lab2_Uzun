using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Book
    {
        public string title;
        public string author;
        private DateOnly creationDate;
        private int countOfPages;
        private decimal price;
        private int quantity;
        public Genre genre;

        public Book(string title, string author, DateOnly creationDate, int countOfPages, decimal price, int quantity, Genre genre)
        {
            this.title = title;
            this.author = author;
            this.creationDate = creationDate;
            this.countOfPages = countOfPages;
            this.price = price;
            this.quantity = quantity;
            this.genre = genre;
        }

        public decimal ChangePrice(decimal newPrice)
        {
            if (newPrice >= 0)
            {
                price = newPrice;
            }
            return price;
        }

        public int IncreaseQuantity()
        {
            quantity++;
            return quantity;
        }

        public int DecreaseQuantity()
        {
            if (quantity > 0)
            {
                quantity--;
            }
            return quantity;
        }
        public int CompareTo(Book? other)
        {
            if (other == null) return 1;
            return this.creationDate.CompareTo(other.creationDate);
        }

        public override string ToString()
        {
            return $"{title,-20} | {author,-18} | {creationDate:dd.MM.yyyy} | {countOfPages,5} | {price,8} USD | {quantity,5} | {genre,-10}";
        }
    }
}
