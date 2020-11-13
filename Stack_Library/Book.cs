using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Library
{
    class Book
    {
        // Here we have our properties
        private string _title;
        private string _author;

        // Here we use the encapsulation method
        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
            }
        }

        // Here we use the encapsulation method again
        public string Author
        {
            get
            {
                return this._author;
            }
            set
            {
                this._author = value;
            }
        }

        // Here we have our constructor
        public Book(string _title, string _author)
        {
            Title = _title;
            Author = _author;
        }
    }
}
