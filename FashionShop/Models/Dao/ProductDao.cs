﻿using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        FashionShopDbContext db = null;
        public ProductDao()
        {
            db = new FashionShopDbContext();
        }
        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(Product entity)
        {
            try
            {

                var product = db.Products.Find(entity.ID);
                product.Name = entity.Name;
                product.Code = entity.Code;
                product.MetaTitle = entity.MetaTitle;
                product.Description = entity.Description;
                product.Image = entity.Image;
                product.MoreImages = entity.MoreImages;
                product.Price = entity.Price;
                product.IncludedVAT = entity.IncludedVAT;
                product.Quantity = entity.Quantity;
                product.CategoryID = entity.CategoryID;
                product.Detail = entity.Detail;
                product.Warranty = entity.Warranty;
                product.CreatedDate = DateTime.Now;
                product.CreatedBy = entity.CreatedBy;
                product.Status = entity.Status;
                product.TopHot = entity.TopHot;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }

        public object ListALLPaging(int page, object pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> ListALLPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString)).OrderByDescending(x => x.CreatedDate);
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public Product GetById(string ProductName)
        {
            return db.Products.SingleOrDefault(x => x.Name == ProductName);
        }

    }
}