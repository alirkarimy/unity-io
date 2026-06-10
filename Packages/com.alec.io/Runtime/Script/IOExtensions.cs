

public static class IOExtensions
{
    public static string CheckAndCorrectDBPath(this string dbPath)
    {
        return dbPath.StartsWith('/') ? dbPath : $"/{dbPath}"; 
    }

}
