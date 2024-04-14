using CQRSPattern.CrossCutting.Interfaces.DataLayer.Repositories.Books;
using CQRSPattern.CrossCutting.Options;
using CQRSPattern.Domain.Entities;
using Dapper;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace CQRSPattern.DataAccessLayer.Repositories;

public sealed class BookQueryRepository(IOptions<ConnectionStringsOptions> connectionStringsOptions) : IBookQueryRepository
{
    private readonly string _connectionString = connectionStringsOptions.Value.ConnectionString;

    public async Task<Book?> GetByIdAsync(int id)
    {
        using var sqlConnection = new SqlConnection(_connectionString);

        await sqlConnection.OpenAsync();

        const string getByIdQuery = @"SELECT 
            id,
            title,
            author,
            gender,
            publication_date AS 'PublicationDate'

            FROM Books 
            WHERE id = @Id";

        var getByIdParameters = new
        {
            Id = id
        };

        return await sqlConnection.QueryFirstOrDefaultAsync<Book>(getByIdQuery, getByIdParameters);
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        using var sqlConnection = new SqlConnection(_connectionString);

        await sqlConnection.OpenAsync();

        const string getAllQuery = @"SELECT 
            id,
            title,
            author,
            gender,
            publication_date AS 'PublicationDate'

            FROM Books";

        return await sqlConnection.QueryAsync<Book>(getAllQuery);
    }
}
