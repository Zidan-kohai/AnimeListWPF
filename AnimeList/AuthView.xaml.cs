using AnimeList.Scripts;
using Newtonsoft.Json.Linq;
using System.Windows;

namespace AnimeList
{
    public partial class AuthView : Window
    {
        public AuthView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RestClient client = new RestClient();

            object data = new { userName = login.Text, login = pasword.Text };
            var response = client.Post("User/LogIn/", data);

            JObject jobject = JObject.Parse(response);
            if ((bool)jobject["isOK"] == true)
            {
                UserData.Instance.SetInfo(response);
                MessageBox.Show(response);
            }
        }
    }
}
