using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Windows;

namespace AnimeList
{
    /// <summary>
    /// Логика взаимодействия для AuthView.xaml
    /// </summary>
    public partial class AuthView : Window
    {
        public AuthView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";
                JObject jobject = new JObject();
                jobject["userName"] = login.Text;
                jobject["login"] = pasword.Text;

                var response = client.UploadString("https://azerlord.bsite.net/api/user/LogIn/", jobject.ToString());

                MessageBox.Show(response);
            }
        }
    }
}
