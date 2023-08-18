using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace AnimeList.Scripts
{
    public class UserData
    {
        private static UserData _instance;
        public static UserData Instance { get { return _instance; } private set { } }

        private string path = System.AppDomain.CurrentDomain.BaseDirectory + "/UserData.txt";

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string login { get; set; }
        public int UserRoleId { get => (int)_userRole; set => _userRole = (UserRole)value; }

        private UserRole _userRole = UserRole.Guest;


        private UserData() 
        {
            if(_instance != null)
            {
                return;
            }

            Load();
            _instance = this;
        }

        public void SetInfo(string json)
        {
            _instance = JsonConvert.DeserializeObject<UserData>(json);
            Save();
        }

        private async void Save()
        {
            await Task.Run(() =>
            {
                using (StreamWriter  sw = new StreamWriter(Path.Combine(path)))
                {

                    string str = JsonConvert.SerializeObject(this, Formatting.Indented);
                    sw.WriteLine(str);

                }
            });

        }

        private async void Load()
        {
            await Task.Run(() =>
            {
                using (StreamReader sr = new StreamReader(Path.Combine(path)))
                {
                    string str = sr.ReadToEnd();
                    _instance = JsonConvert.DeserializeObject<UserData>(str);
                }
            });
        }
    }

    enum UserRole
    {
        Admin = 1,
        User,
        Guest
    }
}
