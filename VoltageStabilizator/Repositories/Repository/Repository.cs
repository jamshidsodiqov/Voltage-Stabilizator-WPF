using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Voltage_Stablizer.Entities;
using Voltage_Stablizer.Repositories.IRepository;

namespace Voltage_Stablizer.Repositories.Repository
{
    public class Repository : IRepositories
    {

        Methods method = new Methods();

        private readonly string  DataPath = "../../../Data/datafile.json";
        public User Create(User user)
        {
            var users = GetAll();

            if (users.LastOrDefault() == null)
                user.Id = 1;
            else
                user.Id = users.LastOrDefault().Id + 1;
            users.Add(user);

            string jsonUser = JsonConvert.SerializeObject(users, Formatting.Indented);

            StreamWriter streamWriter = new StreamWriter(DataPath);
            streamWriter.Write(jsonUser);
            streamWriter.Close();
            return user;
        }

        public List<User> GetAll(Func<User, bool> predicate = null)
        {
            var data = method.Reader();

            if(string.IsNullOrEmpty(data))
            {
                StreamWriter writer = new StreamWriter(DataPath);
                writer.Write("[]");
                writer.Close();
                return new List<User>();
            }

            return JsonConvert.DeserializeObject<List<User>>(data);
        }
    }
}
