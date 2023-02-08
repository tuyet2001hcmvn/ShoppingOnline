using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ProductDAO
    {
        ShoppingOnlineDBContext db = new ShoppingOnlineDBContext();

        public List<Product> lstNewProduct()
        {
            return db.Products.Where(x=>x.Type == 1).OrderByDescending(y => y.CreatedDate).Take(4).ToList();
        }

        public List<Product> lstFeaturedProduct()
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot < DateTime.Now && x.Type == 1).OrderByDescending(x=>x.CreatedDate).Take(4).ToList();
        }

        public List<Product> lstRelatedProduct(int productID)
        {
            var product = db.Products.Where(x=>x.ID == productID).SingleOrDefault();
            return db.Products.Where(x => x.ID != productID && x.CategoryID == product.CategoryID && x.Type == 1).OrderByDescending(x => x.CreatedDate).Take(3).ToList();
        }

        public Product ItemDetail(int id)
        {
            return db.Products.SingleOrDefault(x=>x.ID == id);
        }

        public ProductCategory CateItem(int id)
        {
            return db.ProductCategories.SingleOrDefault(x => x.ID == id);
        }

    }
}
