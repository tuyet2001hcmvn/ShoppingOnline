using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class MenuAndFooterDAO
    {
        ShoppingOnlineDBContext db = new ShoppingOnlineDBContext();
        public List<Menu> listByGroupID (int groupID)
        {
            return db.Menus.Where(x => x.TypeID == groupID && x.Status == true).OrderBy(x=>x.DisplayOrder).ToList();
        }

        public Footer GetFooter()
        {
            return db.Footers.SingleOrDefault(x => x.Status == true && x.ID == 1);
        }

        public List<Slide> GetSlide()
        {
            return db.Slides.Where(x => x.Status == true).ToList();
        }

        public List<ProductCategory> GetProductCategories()
        {
            return db.ProductCategories.Where(x=> x.Status == true && x.ShowOnHome == true && x.Type == 1).OrderBy(x=>x.DisplayOrder).ToList();
        }
    }
}
