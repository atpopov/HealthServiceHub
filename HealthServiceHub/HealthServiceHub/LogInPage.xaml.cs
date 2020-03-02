using Microsoft.Data.Sqlite;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthServiceHub
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage : ContentPage
    {
        private SQLiteConnection connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        public LogInPage()
        {
            InitializeComponent();

            connection.CreateTable<User>();
        }
        private  void LogInProcedure(object sender, EventArgs e)
        {
            User user = new User { PhNumber = EntryUserKey.Text, Password = EntryPassword.Text };
            
        }

        private void RegisterProcedure(object sender, EventArgs e)
        {
            User user = new User {Position=PositionPicker.Items[PositionPicker.SelectedIndex], PhNumber = EntryUserKey.Text, Password = EntryPassword.Text };
            SQLiteCommand cmd = new SQLiteCommand(connection);

            

            cmd.CommandText = $"SELECT * FROM User Where PhNumber = {user.PhNumber}";
            int count = 0;
            SqliteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                count++;
            }
            if(count == 1)
            {
                DisplayAlert("Грешка", "Номерът е вече регистриран.", "OK");
            }
            else
            {
                cmd.CommandText = $"INSERT INTO User(Position, PhNumber, Password) VALUES ('{user.Position}','{user.PhNumber}','{user.Password}')";
                cmd.ExecuteNonQuery();
                DisplayAlert("Успех", "Регистрацията Ви е успешна!", "ОК");
            }
        }
    }
}