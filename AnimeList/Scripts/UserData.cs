﻿using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AnimeList.Scripts
{
    public class UserDataController
    {
        private static UserDataController _instance;
        public static UserDataController Instance { get { return _instance; } private set { } }

        private string path = AppDomain.CurrentDomain.BaseDirectory + "/UserData.txt";

        private UserData userData = new UserData();



        public UserDataController() 
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
            try { 
                _instance.userData = JsonConvert.DeserializeObject<UserData>(json);
            }
            catch {
                throw new Exception("Exception on deserialize UserData");
            }
            Save();
        }

        private async void Save()
        {
            await Task.Run(() =>
            {
                using (StreamWriter  sw = new StreamWriter(Path.Combine(path)))
                {
                    try { 

                        string str = JsonConvert.SerializeObject(this, Formatting.Indented);
                        sw.WriteLine(str);

                    }
                    catch {

                        throw new Exception("Exception on serialize UserData");

                    }
                }
            });

        }

        private async void Load()
        {
            await Task.Run(() =>
            {
                if (!File.Exists(path)) return;

                using (StreamReader sr = new StreamReader(Path.Combine(path)))
                {
                    string str = sr.ReadToEnd();
                    try
                    {
                        _instance.userData = JsonConvert.DeserializeObject<UserData>(str);
                    }
                    catch
                    {
                        throw new Exception("Exception on deserialize UserData");
                    }
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


    public class UserData
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string login { get; set; }
        public int UserRoleId { get => (int)_userRole; set => _userRole = (UserRole)value; }

        private UserRole _userRole = UserRole.Guest;
    }
}
