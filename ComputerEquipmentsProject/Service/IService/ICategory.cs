using ComputerEquipmentsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerEquipmentsProject.Service.IService
{
    public interface ICategory
    {
        List<Category> GetCategories();
        Models.Category GetCategory(int id);
        Models.Category CreateCategory(Models.Category model);
        Models.Category UpdateCategory(Models.Category model);
        bool DeleteCategory(int id);
    }
}
