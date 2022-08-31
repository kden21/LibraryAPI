using AutoMapper;
using Contracts.Book.CreateBook;
using Contracts.Book.DeleteBook;
using Contracts.Book.Dto;
using Contracts.Book.GetBookById;
using Contracts.Book.GetBooks;
using Contracts.Book.UpdateBook;
using DataAccess.Repositories;
using Domain;
using Microsoft.Extensions.Configuration;

namespace AppServices.Book.Services;

  public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    public BookService(IBookRepository bookRepository, IConfiguration configuration, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<GetBooksResponse> GetBooks(GetBooksRequest request, CancellationToken cancellation)
    {
        var books = _bookRepository.GetAll();

        return new GetBooksResponse
        {
            Books = _mapper.Map<IEnumerable<BookEntity>, IEnumerable<BookDto>>(books)
        };
    }

    public async Task<CreateBookResponse> CreateBook(CreateBookRequest request, CancellationToken cancellationToken)
    {
        var book = _mapper.Map<BookEntity>(request);

        if (book.Birthday > DateTime.Today)
        {
            throw new Exception("Дата рождения не может быть больше текущей");
        }
        
        var bookId = await _bookRepository.AddAsync(book, cancellationToken);

        var createBookResponse = _mapper.Map<CreateBookResponse>(request);
        createBookResponse.Id = bookId;

        return createBookResponse;
    }
    
    public async Task<DeleteBookResponse> DeleteBook(DeleteBookRequest request, CancellationToken cancellationToken)
    {
        await _bookRepository.DeleteAsync(request.Id, cancellationToken);
        
        return new DeleteBookResponse();
    }
    
    public async Task<UpdateBookResponse> UpdateBook(UpdateBookRequest request, CancellationToken cancellationToken)
    {
        var book = _mapper.Map<BookEntity>(request);
        
        if (book.Birthday > DateTime.Today)
        {
            throw new Exception("Дата рождения не может быть больше текущей");
        }
        
        await _bookRepository.UpdateAsync(book, cancellationToken);

        return _mapper.Map<UpdateBookResponse>(request);
    }

    public async Task<GetBookByIdResponse> GetBookById(GetBookByIdRequest request, CancellationToken cancellation)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id, cancellation);
        
        return _mapper.Map<GetBookByIdResponse>(book);
    }

}