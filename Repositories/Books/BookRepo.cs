using AutoMapper;
using Exceptions;
using IceCreamRecipe.Models;
using Microsoft.EntityFrameworkCore;
using Models.Books;

namespace Repositories.Books;

public class BookRepo : IBookRepo 
{

    private readonly AppDbContext _context;
    
    private readonly IMapper _mapper;

    public BookRepo(AppDbContext context,IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<BookRes>> GetAllBooks() {
        var books = await _context.Books.ToListAsync();
        
        foreach (var book in books)
        {
            // add list bookImages for Book
            var bookImages = _context.BookImages
                .Where(b =>  b.BookId== book.Id)
                .ToList();
            
            book.BookImages = bookImages;
            
        }

        return _mapper.Map<List<BookRes>>(books);
    }

    public async Task<BookRes> GetBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        
        // add list bookImages for Book
        var bookImages = _context.BookImages
            .Where(b =>  b.BookId== book.Id)
            .ToList();
        
        book.BookImages = bookImages;
        
        return _mapper.Map<BookRes>(book) 
               ??
               throw new NotFoundException("Book not found");
    }

    public async Task<BookRes> CreateBook(BookDto dto)
    {
        // Check ISBN is  existing
        var existingBook = await _context.Books.FirstOrDefaultAsync(b => b.ISBN == dto.ISBN);

        if (existingBook != null)
        {
            throw new AlreadyException("ISBN already exists");
        }

        
        // bookDto -> book
        var book = _mapper.Map<Book>(dto);
        
        // save book to db
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        
        // book -> bookRes
        var bookRes = _mapper.Map<BookRes>(book);
        return bookRes;
    }

    public async Task<string> DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id) ?? throw new NotFoundException("Book Not Found");
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return "The book has been deleted";
    }

    public async Task<BookRes> UpdateBook(int id,BookDto dto)
    {
        // Check if the book with given ISBN already exists
        var existingBook = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
    
        if (existingBook == null)
        {
            throw new NotFoundException("Book not found");
        }

        // bookDto -> book
        _mapper.Map(dto, existingBook);
       
        
        // Save changes to the database
        _context.Entry(existingBook).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        // book -> bookRes
        return _mapper.Map<BookRes>(existingBook);
    }
}