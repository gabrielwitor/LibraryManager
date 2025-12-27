using LibraryManager.Models;

namespace LibraryManager.Repository.Interface
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBookById(int bookId);
        Task<Book> AddBook(Book book);
    }
}
