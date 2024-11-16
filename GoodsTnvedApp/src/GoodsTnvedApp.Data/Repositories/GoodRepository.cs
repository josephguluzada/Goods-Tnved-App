using System.Data.SqlClient;
using Dapper;
using GoodsTnvedApp.Core.Entities;
using GoodsTnvedApp.Core.Repositories;
using GoodsTnvedApp.Data.SQLQueries;
using Microsoft.Extensions.Configuration;

namespace GoodsTnvedApp.Data.Repositories;

public class GoodRepository: IGoodRepository
{
    private readonly IConfiguration _configuration;
    private string _connectionString = string.Empty;
    private SqlConnection _sqlConnection = null;
    public GoodRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("Default");
        _sqlConnection = new SqlConnection(_connectionString);
    }
    
    public async Task<Good> GetAll(string code)
    {
        await _sqlConnection.OpenAsync();

        var goodsList = (await _sqlConnection.QueryAsync<Good>(SQL.GetGoods, new { Code = code })).Distinct().ToList();

        var lookup = goodsList.ToLookup(x => x.ParentId);

        foreach (var item in goodsList)
        {
            if (item.Children is null)
            {
                item.Children = new List<Good>();
            }

            item.Children = lookup[item.ID]
                .Where(child => !item.Children.Any(x => x.ID == child.ID)) 
                .ToList();
        }

        var root = goodsList.FirstOrDefault(x=> x.ParentId == 0);

        return root;
    }
}