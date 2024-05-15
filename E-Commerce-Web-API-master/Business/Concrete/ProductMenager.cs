using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductMenager : IProductService
    {
        IProductDal _produtDal;

        public ProductMenager(IProductDal produtDal)
        {
            _produtDal = produtDal;
        }

        public List<Product> GetAll()
        {
            //iş kodları yazılır
            //yetkisi var mı o zaman aşağıdakini ver
            return _produtDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _produtDal.GetAll(p => p.CategoryID == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _produtDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max);
        }
    }
}
