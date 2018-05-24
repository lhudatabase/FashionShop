using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
   public class ProductCategoryDao
    {
        FashionShopDbContext db = null;
        public ProductCategoryDao()
        {
            db = new FashionShopDbContext();
        }
        public long Insert(ProductCategory entity)
        {
            db.ProductCategories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(ProductCategory entity)
        {
            try
            {
                var productCategory = db.ProductCategories.Find(entity.ID);
                productCategory.Name = entity.Name;
                productCategory.ParentID = entity.ParentID;
                productCategory.MetaTitle = entity.MetaTitle;
                productCategory.DisplayOrder = entity.DisplayOrder;
                productCategory.CreatedBy = entity.CreatedBy;
                productCategory.Status = entity.Status;
                productCategory.ModifiedBy = entity.ModifiedBy;
                productCategory.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        // Chi tiết trong category
        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }

        public object ListALLPaging(int page, object pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCategory> ListALLPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ProductCategory> model = db.ProductCategories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.MetaTitle.Contains(searchString)).OrderByDescending(x => x.CreatedDate);
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public ProductCategory GetById(string ProductCategoryName)
        {
            return db.ProductCategories.SingleOrDefault(x => x.Name == ProductCategoryName);
        }

        public bool Delete(int id)
        {
            try
            {
                var productCategory = db.ProductCategories.Find(id);
                db.ProductCategories.Remove(productCategory);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
