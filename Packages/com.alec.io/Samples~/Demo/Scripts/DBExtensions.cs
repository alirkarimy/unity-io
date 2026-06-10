

public static class DBExtensions 
{
    public static string CheckAndCorrectDBPath(this string dbPath)
    {
        return dbPath.StartsWith('/') ? dbPath : $"/{dbPath}"; 
    }

}
