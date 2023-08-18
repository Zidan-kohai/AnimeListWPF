using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AnimeList.UserController;
using System.Windows.Media.Imaging;
using AnimeList.Scripts;

namespace AnimeList
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }


        public void Init()
        {
            UserData data = new UserData();

            var client = new RestClient();
            string response = client.Get("Anime/GetAll");

            JObject jobject = JObject.Parse(response);
            List<Anime> animies = new List<Anime>();
            if ((bool)jobject["isOK"])
            {
                animies = JsonConvert.DeserializeObject<List<Anime>>(jobject["data"].ToString());
            }

            foreach (var anime in animies)
            {
                AnimeView view = new AnimeView();
                view.animeName.Text = anime.animeName;
                view.animeImage.ImageUrl = anime.imageURL;
                Image image = new Image();
                image.Source = new BitmapImage(new System.Uri("\\Logo\\noimage.png", System.UriKind.Relative));
                view.animeImage.ToolTip = image;
                view.Margin = new Thickness(10, 5, 10, 5);
                MainStack.Children.Add(view);
            } 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AuthView authView = new AuthView();
            authView.ShowDialog();
        }
    }

    

}
