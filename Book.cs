using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Book
    {
        private string title;
        private string author;
        private DateOnly creationDate;
        private decimal price;
        private int quantity;
        private BookGenre genre;

        public int CountOfPages { get; private set; } = 100;
        public string Title
        {
            get => title;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    title = value;
                else
                    throw new ArgumentException("Назва книги не може бути порожньою.");
            }
        }
        public string Author
        {
            get => author; 
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    author = value;
                else
                    throw new ArgumentException("Автор не може бути порожнім.");
            }
        }
        public DateOnly CreationDate
        {
            get => creationDate;
            set
            {
                if (value > DateOnly.FromDateTime(DateTime.Today))
                    throw new ArgumentException("Дата створення не може бути пізніше сьогоднішньої.");

                creationDate = value;
            }
        }
        public decimal Price
        {
            get => price;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Ціна не може бути від’ємною.");
                price = value;
            }
        }
        public int Quantity
        {
            get => quantity;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Кількість не може бути від’ємною.");

                quantity = value;
            }
        }
        public BookGenre Genre
        {
            get => genre;
            set
            {
                if (!Enum.IsDefined(typeof(BookGenre), value))
                    throw new ArgumentException("Невірне значення жанру книги.");
                genre = value;
            }
        }
        public decimal FullCost
        {
            get { return quantity * price; }
        }

        public Book(string title, string author, DateOnly creationDate, int countOfPages, decimal price, int quantity, BookGenre genre)
        {
            Title = title;
            Author = author;
            CreationDate = creationDate;
            SetCountOfPages(countOfPages);
            ChangePrice(price);
            Quantity = quantity;
            Genre = genre;
        }

        public decimal ChangePrice(decimal newPrice)
        {
            Price = newPrice;
            return Price;
        }

        public int IncreaseQuantity()
        {
            Quantity++;
            return Quantity;
        }

        public int DecreaseQuantity()
        {
            if (Quantity > 0)
                Quantity--;
            return Quantity;
        }
        
        public int CompareTo(Book? other)
        {
            if (other == null) return 1;
            return this.creationDate.CompareTo(other.creationDate);
        }
        public void SetCountOfPages(int value)
        {
            if (value <= 0)
                throw new ArgumentException("Кількість сторінок має бути більше нуля.");
            CountOfPages = value;
        }

        public override string ToString()
        {
            return $"{title,-20} | {author,-18} | {creationDate:dd.MM.yyyy} | {CountOfPages,5} | {price,8} USD | {quantity,5} | {genre,-10}";
        }
    }
}
