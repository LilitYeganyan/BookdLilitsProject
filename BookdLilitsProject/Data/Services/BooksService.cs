using BookdLilitsProject.Data.Models;
using BookdLilitsProject.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookdLilitsProject.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }
        public List<Book> GetAllBooks() => _context.Books.ToList();
        public BookWithAuthorsVM GetBookById(int bookId) 
        {
          var _bookWithAuthors = _context.Books.Where(n=>n.Id==bookId).Select(book => new BookWithAuthorsVM()
          {
              Title = book.Title,
              Description = book.Description,
              IsRead = book.IsRead,
              DateRead = book.IsRead ? book.DateRead.Value : null,
              Rate = book.IsRead ? book.Rate.Value : null,
              Genre = book.Genre,
              CoverUral = book.CoverUral,
              PublisherName = book.Publisher.Name,
              AuthorsNames = book.Book_Authors.Select(n=>n.Author.FullName).ToList()
          }).FirstOrDefault();

            return _bookWithAuthors;
        }
        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUral = book.CoverUral,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AuthorsIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Books_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }

        public Book UpdatBookById(int bookId, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id == bookId);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genre = book.Genre; 
                _book.CoverUral = book.CoverUral;

                _context.SaveChanges();
            }
            return _book;
        }

        public void DeletebyId(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(x => x.Id == bookId);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }

        }
    }
}
