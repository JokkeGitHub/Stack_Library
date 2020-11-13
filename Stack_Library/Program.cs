using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            // Here we create our collections
            List<Book> library = new List<Book>();
            Stack<Book> loanersCart = new Stack<Book>();

            // Here we create our "Book" objects
            Book book1 = new Book("How to clean your Pokemon", "Ying Lee");
            Book book2 = new Book("Kettle of the Witch", "Anders Bo Nielsen");
            Book book3 = new Book("How glass is made", "Dick Butthead");
            Book book4 = new Book("When the dogs conquered the Moon", "Steven Fails the third");
            Book book5 = new Book("How to live for dummies", "Morgan Freeman");
            Book book6 = new Book("Failed Life", "Lise Lisen");
            Book book7 = new Book("How to destroy the world for dummies", "William Andersen");
            Book book8 = new Book("Dance for downers", "Anders Fogh Rasmussen");
            Book book9 = new Book("How to properly eat banana-mallow", "Bent Bendtsen");

            // Here we add our objects to the library list
            library.Add(book1);
            library.Add(book2);
            library.Add(book3);
            library.Add(book4);
            library.Add(book5);
            library.Add(book6);
            library.Add(book7);
            library.Add(book8);
            library.Add(book9);

            Console.WriteLine("Hello! Welcome to the library.");

            do
            {
                LibraryShelf();
            } while (true);

            // This method is the simulates the UI of our library and our book cart
            void LibraryShelf()
            {
                Console.Clear();
                Console.WriteLine("\n********** Books currently on the shelf **********\n");

                foreach (Book book in library)
                {
                    Console.WriteLine($"{library.IndexOf(book) + 1}. {book.Title}, written by {book.Author}");
                }

                Console.WriteLine("\n********** Books in the loaners cart **********\n");

                if (loanersCart.Count != 0)
                {
                    foreach (Book book in loanersCart)
                    {
                        Console.WriteLine($"{book.Title}, written by {book.Author}");
                    }
                }

                UserChoice();
            }

            // Here we are able to select whether we want to loan or check out
            void UserChoice()
            {
                if (library.Count != 0)
                {
                    Console.WriteLine("\n1. Loan\n2. Check Out");
                    string tempInput = Console.ReadLine();
                    switch (tempInput)
                    {
                        case "1":
                            ChooseBooksToLoan();
                            break;

                        case "2":
                            CheckOut();
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    CheckOut();
                }
            }

            // In this method we can choose the books we want to loan
            void ChooseBooksToLoan()
            {
                Console.WriteLine("\nWhich books would you like to loan?\n");
                int tempIndex = int.Parse(Console.ReadLine());

                if (tempIndex > library.Count)
                {
                    Console.WriteLine("Wrong input");
                }
                else
                {
                    foreach (Book book in library)
                    {
                        if (tempIndex - 1 == library.IndexOf(book))
                        {
                            loanersCart.Push(book);
                        }
                    }
                    library.RemoveAt(tempIndex - 1);
                }
            }

            // In this method we confirm the loans and then we leave the library, but if the "loanersCart" is empty we return to the bookshelf
            void CheckOut()
            {
                Console.WriteLine("\nDo you have any books you would like to loan?\n");

                if (loanersCart.Count != 0)
                {
                    int amountOfBooksToLoan = loanersCart.Count;

                    for (int i = 0; i < amountOfBooksToLoan; i++)
                    {
                        Console.WriteLine($"You have registered the book {loanersCart.Peek().Title}, written by {loanersCart.Peek().Author}, as a loan.");
                        loanersCart.Peek();
                        loanersCart.Pop();
                    }
                    Console.WriteLine("\nThank you for using this library, please come again!\n");

                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("\nIt seems that you have no books in your cart. Feel free to get some books.\n");
                    Console.ReadLine();
                }
            }
        }
    }
}
