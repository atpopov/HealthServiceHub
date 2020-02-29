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
        string loggedId;
        Dictionary<string, string> usPassDict = new Dictionary<string, string>();
        public LogInPage()
        {
            InitializeComponent();
        }

        private async void LogInProcedure(object sender, EventArgs e)
        {
            string tempPass;
            if(usPassDict.ContainsKey(EntryUserKey.Text))
            {
                usPassDict.TryGetValue(EntryUserKey.Text, out tempPass);
                if (tempPass == EntryPassword.Text) { await DisplayAlert("Успешен вход!", "Добре дошли!", "ОК"); loggedId = EntryUserKey.Text; await Navigation.PushAsync(new MainPage()); }
                else await DisplayAlert("Неуспешен вход!", "Грешна парола. Моля опитайте отново!", "ОК");
            }
            else await DisplayAlert("Неуспешен вход!", "Грешен код!", "ОК");
        }

        private void RegisterProcedure(object sender, EventArgs e)
        {
            if (usPassDict.ContainsKey(EntryUserKey.Text)) DisplayAlert("Грешка", "Кодът е вече зает.", "OK");
            else
            {
                usPassDict.Add(EntryUserKey.Text, EntryPassword.Text);
                DisplayAlert("Успех", "Регистрацията Ви е успешна!", "ОК");
            }
        }
    }
}