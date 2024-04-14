using CQRSPattern.Application.Books.Commands.CreateBook;
using CQRSPattern.Application.Books.Commands.DeleteBook;
using CQRSPattern.Application.Books.Commands.UpdateBook;
using CQRSPattern.Application.Books.Queries.GetAllBooks;
using CQRSPattern.Application.Books.Queries.GetBookById;
using CQRSPattern.CrossCutting.Settings.NotificationSettings;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSPattern.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class BookController(ISender sender) : ControllerBase
{
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task AddAsync([FromBody] CreateBookCommand createBookCommand) =>
        sender.Send(createBookCommand);

    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task UpdateAsync([FromBody] UpdateBookCommand updateBookCommand) =>
        sender.Send(updateBookCommand);

    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task DeleteAsync([FromQuery] int id)
    {
        var deleteBookCommand = new DeleteBookCommand(id);

        return sender.Send(deleteBookCommand);
    }

    [HttpGet("get-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookByIdResponse))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<BookByIdResponse> GetByIdAsync([FromQuery] int id)
    {
        var getBookByIdQuery = new GetBookByIdQuery(id);

        return sender.Send(getBookByIdQuery);
    }

    [HttpGet("get-all")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookGetAllResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<IEnumerable<BookGetAllResponse>> GetAllAsync()
    {
        var getAllBooksQuery = new GetAllBooksQuery();

        return sender.Send(getAllBooksQuery);
    }
}
