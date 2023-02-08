using Model.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CateDAO
    {
        ShoppingOnlineDBContext db = new ShoppingOnlineDBContext();
        public IEnumerable<Category> Paging(string strSearch, int page, int pagesize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(strSearch))
                model = model.Where(x => x.Name.Contains(strSearch) || x.MetaKeywords.Contains(strSearch) || x.MetaTitle.Contains(strSearch));
            return model.OrderBy(x => x.ID).ToPagedList(page, pagesize);
        }

        public List<Category> selectAllCate()
        {
            var model = db.Categories.Where(x=>x.Status == true).ToList();
            return model;
        }
    }
}
