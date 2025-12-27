using LibraryManager.Data;
using LibraryManager.Models;
using LibraryManager.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Repository.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        async Task<Book> IBookRepository.AddBook(Book book)
        {
            var result = await appDbContext.Books.AddAsync(book);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        async Task<Book> IBookRepository.GetBookById(int bookId)
        {
            return await appDbContext.Books.FirstOrDefaultAsync(b => b.BookId == bookId);
        }

        async Task<IEnumerable<Book>> IBookRepository.GetBooks()
        {
            return await appDbContext.Books.ToListAsync();
        }
    }
}
