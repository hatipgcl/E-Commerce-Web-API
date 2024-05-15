using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>()
            {
                new Product{ProductID=1,ProductName="Bardak",CategoryID=1,UnitPrice=15,UnitsInStock=15},
                new Product{ProductID=2,ProductName="Kamera",CategoryID=1,UnitPrice=500,UnitsInStock=15},
                new Product{ProductID=3,ProductName="Telefon",CategoryID=2,UnitPrice=5000,UnitsInStock=15},
                new Product{ProductID=4,ProductName="Klavye",CategoryID=2,UnitPrice=500,UnitsInStock=15},
                new Product{ProductID=5,ProductName="Fare",CategoryID=2,UnitPrice=200,UnitsInStock=15}

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryID == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.ProductID = product.ProductID;
            productToUpdate.UnitPrice=product.UnitPrice;
            productToUpdate.UnitsInStock=product.UnitsInStock;
            productToUpdate.CategoryID = product.CategoryID;


        }
    }
}
