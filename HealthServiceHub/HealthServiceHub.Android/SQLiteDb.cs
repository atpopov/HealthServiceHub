using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using HelloWorld.Droid;
using HealthServiceHub;

[assembly: Dependency(typeof(SQLiteDb))]

namespace HelloWorld.Droid
{
	public class SQLiteDb : ISQLiteDb
	{
		public SQLiteConnection GetConnection()
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(documentsPath, "MySQLite.db3");

			return new SQLiteConnection(path);
		}
	}
}