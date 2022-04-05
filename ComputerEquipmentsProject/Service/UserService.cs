using ComputerEquipmentsProject.Data;
using ComputerEquipmentsProject.Models;
using ComputerEquipmentsProject.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerEquipmentsProject.Service
{
    public class UserService : IUser
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public CustomUser CreateCustomUser(CustomUser model)
        {
            _context.CustomUsers.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteCustomUser(int id)
        {
            throw new NotImplementedException();
        }

        public CustomUser GetCustomUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<CustomUser> GetCustomUsers()
        {
            throw new NotImplementedException();
        }

        public CustomUser UpdateCustomUser(CustomUser model)
        {
            throw new NotImplementedException();
        }
    }
}
