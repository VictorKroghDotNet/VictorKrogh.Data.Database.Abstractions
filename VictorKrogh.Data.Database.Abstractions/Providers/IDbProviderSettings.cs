namespace VictorKrogh.Data.Database.Providers;

public interface IDbProviderSettings
{
    string? ConnectionString { get; set; }
}
