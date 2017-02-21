using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dec2ndWSAD1
{
    public class BookList : List<Book> 
    {
        public BookList()
        {
            this.Add(new Book() { BookId = 1, Title = "Algorithm", PublicationDate = Convert.ToDateTime("2007-06-12"), Downloads = 1100, Price = 13.9, ImagePath = "ms-appx:///Assets/covers/book-algorithm.jpg" });

            this.Add(new Book() { BookId = 2, Title = "Code Complete", PublicationDate = Convert.ToDateTime("2014-10-27"), Downloads = 10000, Price = 10.99, ImagePath = "ms-appx:///Assets/covers/book-code.jpg" });

            this.Add(new Book() { BookId = 3, Title = "Programming C#", PublicationDate = Convert.ToDateTime("2016-09-30"), Downloads = 11000, Price = 10.99, ImagePath = "ms-appx:///Assets/covers/book-csharp.jpg" });

            this.Add(new Book() { BookId = 4, Title = "Hackers and Painters", PublicationDate = Convert.ToDateTime("2003-03-25"), Downloads = 1200, Price = 9.99, ImagePath = "ms-appx:///Assets/covers/book-hackers.jpg" });

            this.Add(new Book() { BookId = 5, Title = "iOS Programming", PublicationDate = Convert.ToDateTime("1991-09-24"), Downloads = 10000, Price = 11.9, ImagePath = "ms-appx:///Assets/covers/book-ios.jpg" });

            this.Add(new Book() { BookId = 6, Title = "Java", PublicationDate = Convert.ToDateTime("2012-04-01"), Downloads = 1100, Price = 12.9, ImagePath = "ms-appx:///Assets/covers/book-java.jpg" });

            this.Add(new Book() { BookId = 7, Title = "PHP", PublicationDate = Convert.ToDateTime("2016-04-23"), Downloads = 10000, Price = 11.9, ImagePath = "ms-appx:///Assets/covers/book-php.jpg" });

            this.Add(new Book() { BookId = 8, Title = "Python", PublicationDate = Convert.ToDateTime("2013-05-03"), Downloads = 1100, Price = 12.9, ImagePath = "ms-appx:///Assets/covers/book-python.jpg" });

            this.Add(new Book() { BookId = 9, Title = "Twenty Five", PublicationDate = Convert.ToDateTime("2015-11-20"), Downloads = 10000, Price = 9.99, ImagePath = "ms-appx:///Assets/covers/book-unix.jpg" });

        }
    }
}
