using System.Globalization;
using Microsoft.Extensions.Configuration;

namespace ITVDaw.Config;

public static class Configuracion
{
    private static readonly IConfiguration Config;

    static Configuracion()
    {
        Config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", false, true)
            .Build();
    }

    public static double NotaAprobado => Config.GetValue<double>("Academica:NotaAprobado");

    public static CultureInfo Locale => CultureInfo.GetCultureInfo("es-ES");

    public static string DataFolder => Path.Combine(Environment.CurrentDirectory, "data");

    // Propiedad que devuelve el tipo de almacenamiento configurado
    public static string StorageType => Config.GetValue<string>("Storage:Type") ?? "json";

    public static string RepositoryType
    {
        get
        {
            var type = Config.GetValue<string>("Repository:Type") ?? "memory";
            return type.ToLower() switch
            {
                "memory" => "memory",
                "binary" => "binary",
                "json" => "json",
                "adonet" => "adonet",
                "dapper" => "dapper",
                "efcore" => "efcore",
                _ => "memory"
            };
        }
    }

    public static string ItvFile
    {
        get
        {
            var extension = StorageType.ToLower() switch
            {
                "json" => "json",
                "xml" => "xml",
                "csv" or "csv-alt" => "csv",
                "txt" or "text" => "txt",
                "bin" => "bin",
                _ => "json"
            };
            return Path.Combine(DataFolder, $"academia.{extension}");
        }
    }

    public static int CacheSize => Config.GetValue("Cache:Size", 10);

    public static bool DropData => Config.GetValue("Repository:DropData", false);

    public static bool SeedData => Config.GetValue("Repository:SeedData", true);

    public static string BackUpFormat
    {
        get
        {
            var Format = Config.GetValue<string>("BackUp:Format") ?? "json";
            return Format.ToLower() switch
            {
                "json" => "json",
                "xml" => "xml",
                "csv" or "csv-alt" => "csv",
                "txt" or "text" => "txt",
                "bin" => "bin",
                "zip" => "zip",
                _ => "zip"
            };
        }
    }
}