using System.Data;
using VictorKrogh.Data.Database.Models;
using VictorKrogh.Data.Providers;

namespace VictorKrogh.Data.Database.Providers;

public interface IDbProvider : IProvider
{
    string GetQualifiedTableName<TModel>() where TModel : Model;

    ValueTask<TModel?> GetAsync<TModel, TKey>(TKey key, int? commandTimeout = null)
        where TModel : Model
        where TKey : notnull;

    ValueTask<IEnumerable<TModel?>> GetAllAsync<TModel>(int? commandTimeout = null)
        where TModel : Model;

    ValueTask<bool> InsertAsync<TModel>(TModel model, int? commandTimeout = null)
        where TModel : Model;

    ValueTask<bool> UpdateAsync<TModel>(TModel model, int? commandTimeout = null)
        where TModel : Model;

    ValueTask<bool> DeleteAsync<TModel>(TModel model, int? commandTimeout = null)
        where TModel : Model;

    ValueTask<bool> DeleteAllAsync<TModel>(int? commandTimeout = null)
        where TModel : Model;

    ValueTask<TModel> QuerySingleAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
        where TModel : Model;

    ValueTask<TModel?> QuerySingleOrDefaultAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
        where TModel : Model;

    ValueTask<TModel> QueryFirstAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
        where TModel : Model;

    ValueTask<TModel?> QueryFirstOrDefaultAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
        where TModel : Model;

    ValueTask<IEnumerable<TModel?>> QueryAsync<TModel>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null)
        where TModel : Model;

    ValueTask<int> ExecuteAsync(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null);
    ValueTask<T?> ExecuteScalarAsync<T>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null);
    ValueTask<T?> ExecuteSingleOrDefaultAsync<T>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null);
    ValueTask<IEnumerable<T?>> ExecuteQueryAsync<T>(string sql, object? parameters = null, int? commandTimeout = null, CommandType? commandType = null);
}
