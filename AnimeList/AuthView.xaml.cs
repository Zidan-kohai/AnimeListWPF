using AnimeList.Scripts;
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
            RestClient client = new RestClient();

            object data = new { userName = login.Text, login = pasword.Text };
            var response = client.Post("User/LogIn/", data);

            MessageBox.Show(response);
        }
    }
}
