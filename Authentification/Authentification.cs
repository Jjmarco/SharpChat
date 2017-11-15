using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Chat
{
    [Serializable]
    class Authentification : AuthentificationManager
    {
        private Hashtable users;

        public Authentification()
        {
            users = new Hashtable();
        }

        public void addUser(string login, string password)
        {
            if (!users.ContainsKey(login))
            {
                users.Add(login, new User(login, password));
            }
            else throw new UserExistsException(login);
        }

        public void removeUser(string login)
        {
            if (users.ContainsKey(login))
            {
                users.Remove(login);
            }
            else throw new UserUnknownException(login);
        }

        public void authentify(string login, string password)
        {
            if (users.ContainsKey(login))
            {
                if (!((User)users[login]).Password.Equals(password))
                {
                    throw new WrongPasswordException(login);
                }
            }
            else throw new UserUnknownException(login);
        }

        public void load(String path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);

            BinaryFormatter bf = new BinaryFormatter();

            this.users = ((Authentification)bf.Deserialize(fs)).users;

            fs.Close();
        }

        public void save(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);

            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(fs, this);

            fs.Close();
        }
    }
}
