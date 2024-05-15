using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{//NuGet paketlerin olduğu yer yazılımların.
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {// IDispossable pattern ipmlemention of c#
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);//git benim entitymin referansını yakala eşleştir
                addedEntity.State = EntityState.Added; //Bu eklenen entitym
                context.SaveChanges(); //Bunu Ekle
            }//bellekte işlem sonrası siliniyor northwind
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);//git benim entitymin referansını yakala eşleştir
                deletedEntity.State = EntityState.Deleted; //Bu silinecek entitym
                context.SaveChanges(); //Bunu sil
            }//bellekte işlem sonrası siliniyor northwind
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);//tek b,r veri getirri
            }

        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
         using(NorthwindContext context = new NorthwindContext())
            {
                return filter == null
                    ? context.Set<Product>().ToList()
                    : context.Set<Product>().Where(filter).ToList();
            //null ise sol, null değil ise sağ taraf çalışır.yukarıda tüm veriyi getirir
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);//git benim entitymin referansını yakala eşleştir
                updatedEntity.State = EntityState.Modified; //Bu Günecellenen olacak entitym
                context.SaveChanges(); //Bunu Güncelle
            }//bellekte işlem sonrası siliniyor northwind
        }
    }
}
