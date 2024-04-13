using CQRSPattern.Domain.Enums;

namespace CQRSPattern.Domain.Entities;

public sealed class Book
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required EGender Gender { get; set; }
    public required DateTime PublicationDate { get; set; }
}
