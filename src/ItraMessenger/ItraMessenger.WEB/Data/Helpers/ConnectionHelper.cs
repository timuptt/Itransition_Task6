using Npgsql;

namespace ItraMessenger.WEB.Data.Helpers;

public static class ConnectionHelper
{
    public static string GetConnectionString(IConfiguration configuration)
    {
        #if DEBUG
        return configuration.GetConnectionString("DefaultConnection");
        #else
        return BuildConnectionString(Environment.GetEnvironmentVariable("DATABASE_URL"));
        #endif
    }
    
    private static string BuildConnectionString(string databaseUrl)
    {
        var databaseUri = new Uri(databaseUrl);
        var userInfo = databaseUri.UserInfo.Split(':');
        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = databaseUri.Host,
            Port = databaseUri.Port,
            Username = userInfo[0],
            Password = userInfo[1],
            Database = databaseUri.LocalPath.TrimStart('/'),
            SslMode = SslMode.Require,
            TrustServerCertificate = true
        };
        return builder.ToString();
    }
}