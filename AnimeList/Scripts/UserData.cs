using Newtonsoft.Json;

namespace AnimeList.Scripts
{
    public class UserData
    {
        private static UserData _instance;
        public static UserData Instance { get { return _instance; } private set { } }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string login { get; set; }
        public int UserRoleId { get => (int)_userRole; set => _userRole = (UserRole)value; }

        private UserRole _userRole = UserRole.Guest;

        public void SetInfo(string json)
        {
            _instance = JsonConvert.DeserializeObject<UserData>(json);
        }
    }

    enum UserRole
    {
        Admin = 1,
        User,
        Guest
    }
}
