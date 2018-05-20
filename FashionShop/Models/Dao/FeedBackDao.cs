using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class FeedBackDao
    {

        FashionShopDbContext db = null;
        public FeedBackDao()
        {
            db = new FashionShopDbContext();
        }
       


      
        public object ListALLPaging(int page, object pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feedback> ListALLPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Feedback> model = db.Feedbacks;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Phone.Contains(searchString)).OrderByDescending(x => x.CreatedDate);
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public Feedback GetById(string name)
        {
            return db.Feedbacks.SingleOrDefault(x => x.Name == name);
        }
        public Feedback ViewDetail(int id)
        {
            return db.Feedbacks.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var feedback = db.Feedbacks.Find(id);
                db.Feedbacks.Remove(feedback);
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
