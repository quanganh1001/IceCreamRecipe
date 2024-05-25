
using Models.Books;

namespace Repositories.Books;

public interface IBookRepo {
    
    Task<List<BookRes>> GetAllBooks();
    
    Task<BookRes> GetBook(int id);
    
    Task<BookRes> CreateBook(BookDto dto);
    
    Task<string> DeleteBook(int id);
    
    Task<BookRes> UpdateBook(int id,BookDto dto);
    
}