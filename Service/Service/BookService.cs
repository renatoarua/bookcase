using Repository.Interface;
using Repository.Models;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        public BookService(IBookRepository bookRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> bookDelete(int bookId, int userId)
        {
            var book = await _bookRepository.bookTake(bookId);

            if (book != null && book.UserId == userId)
                return await _bookRepository.bookDelete(book);

            return false;
        }

        public async Task<bool> bookSave(TabBook book)
        {
            return await _bookRepository.bookSave(book);
        }

        public async Task<IEnumerable<TabBook>> booksTake(string username)
        {
            var user = await _userRepository.userTakeByUsername(username);

            if (user == null) return null;

            return await _bookRepository.booksTake(user.UserId);
        }

        public async Task<TabBook> bookTake(int bookId)
        {
            return await _bookRepository.bookTake(bookId);
        }

        public async Task<bool> bookUpdate(TabBook newBook, int userId)
        {
            var book = await _bookRepository.bookTake(newBook.BookId);

            if (book != null && book.UserId == userId)
            {
                book = updateBook(newBook, book);
                return book != null ? await _bookRepository.bookUpdate(book) : false;
            }

            return false;
        }

        private static TabBook updateBook(TabBook newBook, TabBook book)
        {
            try
            {
                book.BookTitle = newBook.BookTitle;
                book.BookAuthor = newBook.BookAuthor;
                book.BookPublished = newBook.BookPublished;
                book.BookPages = newBook.BookPages;
                book.BookRate = newBook.BookRate;
                book.BookBrief = newBook.BookBrief;
                book.BookGenre = newBook.BookGenre;
                book.BookJoinDate = newBook.BookJoinDate;
                book.BookImg64 = newBook.BookImg64;

                return book;
            }
            catch
            {
                return null;
            }
        }
    }
}
