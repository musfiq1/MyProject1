using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerEquipmentsProject.Service.IService
{
    public interface IUser
    {
        List<Models.CustomUser> GetCustomUsers();
        Models.CustomUser GetCustomUser(int id);
        Models.CustomUser CreateCustomUser(Models.CustomUser model);
        Models.CustomUser UpdateCustomUser(Models.CustomUser model);
        bool DeleteCustomUser(int id);
    }
}
