using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voltage_Stablizer.Entities;

namespace Voltage_Stablizer.Repositories.IRepository
{
    public interface IRepositories
    {
        public User Create(User user);
        public List<User> GetAll(Func<User,bool> predicate = null);
    }
}
