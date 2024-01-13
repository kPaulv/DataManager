namespace DataManager.Utils;

using Microsoft.Extensions.Configuration;

public class ConfigurationHelper {
    private static readonly IConfiguration _configuration = new ConfigurationBuilder()
                                                        .SetBasePath(Directory.GetCurrentDirectory())
                                                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                                        .Build();

    public static string ParseConnectionString(string connectionName) {
        return _configuration.GetConnectionString(connectionName) ?? "";
    }

    public static DbSettings? ParseDbSettings(){
        var section = _configuration.GetSection("DbSettings");
        DbSettings? settings = null;
        if(section.Exists()){
            settings = section.Get<DbSettings>();
        }
        return settings;
    }
    
}