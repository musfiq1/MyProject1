using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerEquipmentsProject.Service.IService
{
    public interface IBrand
    {
        List<Models.Brand> GetBrands();
        Models.Brand GetBrand(int id);
        Models.Brand CreateBrand(Models.Brand model);
        Models.Brand UpdateBrand(Models.Brand model);
        bool DeleteBrand(int id);
    }
}
