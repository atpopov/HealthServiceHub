using SQLite;

namespace HealthServiceHub
{
    public interface ISQLiteDb
    {
        SQLiteConnection GetConnection();
    }
}