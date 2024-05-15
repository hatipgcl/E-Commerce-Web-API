using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{//iş yapan classalrın interfacesi olmalıdır.
    //bşaka bir katman kullanmak istersek referans veririz

    public interface IProductDal :IEntityeRepository<Product>
    {

    }
}
