using System.Data;
using VictorKrogh.Data.Database.Models;
using VictorKrogh.Data.Providers;

namespace VictorKrogh.Data.Database.Providers;

public interface IDbProvider : IProvider
{
    string GetQualifiedTableName<TModel>() where TModel : Model;

    Task<TModel?> GetAsync<TModel, TKey>(TKey key, int? commandTimeout = null)
        where TModel : Model
        where TKey : notnull;

    Task<IEnumerable<TModel?>> GetAllAsync<TModel>(int? commandTimeout = null)
        where TModel : Model;

    Task<bool> InsertAsync<TModel>(TModel model, int? commandTimeout = null)
        where TModel : Model;

    Task<bool> UpdateAsync<TModel>(TModel model, int? commandTimeout = null)
        where TModel : Model;

    Task<bool> DeleteAsync<TModel>(TModel model, int? commandTimeout = null)
        where TModel : Model;

    Task<bool> DeleteAllAsync<TModel>(int? commandTimeout = null)
        where TModel : Model;

    Task<TModel> QuerySingleAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
        where TModel : Model;

    Task<TModel?> QuerySingleOrDefaultAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
        where TModel : Model;

    Task<TModel> QueryFirstAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
        where TModel : Model;

    Task<TModel?> QueryFirstOrDefaultAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
        where TModel : Model;

    Task<IEnumerable<TModel?>> QueryAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
        where TModel : Model;

    Task<int> ExecuteAsync(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null);
    Task<T?> ExecuteScalarAsync<T>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null);
    Task<T?> ExecuteSingleOrDefaultAsync<T>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null);
    Task<IEnumerable<T?>> ExecuteQueryAsync<T>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null);
}
