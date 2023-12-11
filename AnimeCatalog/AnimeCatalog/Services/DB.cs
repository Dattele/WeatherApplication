using SQLite;
using AnimeCatalog.Models;

namespace AnimeCatalog.Services;
public class DB
{
    private static string DBName = "anime.db";
    public static SQLiteConnection conn;
    static DB()
    {
        OpenConnection();
        conn.CreateTable<AnimeWatchList>();
    }
    public static void OpenConnection()
    {
        string libFolder = FileSystem.AppDataDirectory;
        string fname = System.IO.Path.Combine(libFolder, DBName);
        conn = new SQLiteConnection(fname);
    }
    public static void AddToWatchlist(AnimeWatchList item)
    {
        DB.OpenConnection();
        conn.Insert(item);
        DB.conn.Close();
    }
    public static void UpdateWatchlistItem(AnimeWatchList item)
    {
        DB.OpenConnection();
        conn.Update(item);
        DB.conn.Close();
    }
    public static List<AnimeWatchList> GetWatchlist()
    {
        DB.OpenConnection();
        var allAnime = conn.Table<AnimeWatchList>().ToList();
        DB.conn.Close();
        return allAnime;
    }
    public static int RemoveFromWatchlist(int itemId)
    {
        DB.OpenConnection();
        int animeRemoved = conn.Delete<AnimeWatchList>(itemId);
        DB.conn.Close();
        return animeRemoved;
    }
    public static AnimeWatchList GetAnimeWatchListItem(string title)
    {
        DB.OpenConnection();
        var allAnime = conn.Table<AnimeWatchList>().FirstOrDefault(item => item.AnimeName == title);
        DB.conn.Close();
        return allAnime;
    }
}
