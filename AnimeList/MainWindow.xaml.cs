using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;

using AnimeList.UserController;
using System.Windows.Media.Imaging;

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
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://azerlord.bsite.net/api/Anime/GetAll");
                JObject jobject = JObject.Parse(json);
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
                    image.Source = new BitmapImage(new System.Uri("\\Logo\\noimage.png",System.UriKind.Relative));
                    view.animeImage.ToolTip = image;
                    view.Margin = new Thickness(10, 5, 10, 5);
                    MainStack.Children.Add(view);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AuthView authView = new AuthView();
            authView.ShowDialog();
        }
    }

    

}
