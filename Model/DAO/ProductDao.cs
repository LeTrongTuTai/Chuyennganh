using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using System.Collections;
using System.Data.Entity;
using Model.ViewModel;

namespace Model.DAO
{
    public class ProductDao
    {
        ShopOnlineDbContext db = null;
        public ProductDao()
        {
            db = new ShopOnlineDbContext();
        }
        public List<PRODUCT> TopHot(int top)
        {
            return db.PRODUCT.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public IEnumerable<PRODUCT> ListAll(string sort)
        {
            var query = db.PRODUCT./*Include("PRODUCTCATEGORY").*/Where(x => x.Status == true);
            switch (sort)
            {
                case "price-ascending":
                    query = query.OrderBy(x => x.PromotionPrice.HasValue ? x.PromotionPrice : x.Price);
                    break;

                case "price-descending":
                    query = query.OrderByDescending(x => x.PromotionPrice.HasValue ? x.PromotionPrice : x.Price);
                    break;

                case "title-ascending":
                    query = query.OrderBy(x => x.Name);
                    break;

                case "title-descending":
                    query = query.OrderByDescending(x => x.Name);
                    break;

                case "created-ascending":
                    query = query.OrderBy(x => x.ModifiedDate);
                    break;

                case "created-descending":
                    query = query.OrderByDescending(x => x.ModifiedDate);
                    break;
                default:
                    query = query.OrderByDescending(x => x.ModifiedDate);
                    break;
            }
            return query;
        }
        public List<PRODUCT> NewProduct(int top)
        {
            return db.PRODUCT.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<PRODUCT> BuyBestProduct(int top)
        {
            return db.PRODUCT.Where(x => x.Status == true).OrderBy(x => x.Quantity).Take(top).ToList();
        }
        //public List<PRODUCT> ListByCategoryId(long categoryId)
        //{
        //    return db.PRODUCT.Where(x => x.CategoryID == categoryId).ToList();
        //}

        public List<PRODUCT> ListRelatedProduct(long productID)
        {
            var product = db.PRODUCT.Find(productID);
            return db.PRODUCT.Where(x => x.ID != productID).ToList();
        }
        public PRODUCT ViewDetail(long id)
        {
            return db.PRODUCT.Find(id);
        }
        public IEnumerable<PRODUCT> AllBuyBestProduct(string sort)
        {
            var order = from a in db.ORDERDETAIL
                        group a by a.Quantity into gr
                        select gr;
            IEnumerable<PRODUCT> query = Enumerable.Empty<PRODUCT>();
            foreach (var item in order)
            {
                foreach (var jitem in item)
                {
                    query = query.Concat(db.PRODUCT.Where(x => x.ID == jitem.ProductID));
                }

            }
            query = query.Distinct();
            switch (sort)
            {
                case "price-ascending":
                    query = query.OrderBy(x => x.PromotionPrice.HasValue ? x.PromotionPrice : x.Price);
                    break;

                case "price-descending":
                    query = query.OrderByDescending(x => x.PromotionPrice.HasValue ? x.PromotionPrice : x.Price);
                    break;

                case "title-ascending":
                    query = query.OrderBy(x => x.Name);
                    break;

                case "title-descending":
                    query = query.OrderByDescending(x => x.Name);
                    break;

                case "created-ascending":
                    query = query.OrderBy(x => x.ModifiedDate);
                    break;

                case "created-descending":
                    query = query.OrderByDescending(x => x.ModifiedDate);
                    break;
                default:
                    query = query.OrderByDescending(x => x.ModifiedDate);
                    break;
            }
            return query;
        }
        public IEnumerable<PRODUCT> ProductMoi(string sort)
        {
            var query = db.PRODUCT.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate);
            switch (sort)
            {
                case "price-ascending":
                    query = query.OrderBy(x => x.PromotionPrice.HasValue ? x.PromotionPrice : x.Price);
                    break;

                case "price-descending":
                    query = query.OrderByDescending(x => x.PromotionPrice.HasValue ? x.PromotionPrice : x.Price);
                    break;

                case "title-ascending":
                    query = query.OrderBy(x => x.Name);
                    break;

                case "title-descending":
                    query = query.OrderByDescending(x => x.Name);
                    break;

                case "created-ascending":
                    query = query.OrderBy(x => x.ModifiedDate);
                    break;

                case "created-descending":
                    query = query.OrderByDescending(x => x.ModifiedDate);
                    break;
                default:
                    query = query.OrderByDescending(x => x.ModifiedDate);
                    break;
            }
            return query;
        }
        public IEnumerable<PRODUCT> ProductView(string sort)
        {
            var query = db.PRODUCT.Where(x => x.Status == true && x.ViewCount.HasValue);
            switch (sort)
            {
                case "price-ascending":
                    query = query.OrderBy(x => x.PromotionPrice.HasValue ? x.PromotionPrice : x.Price);
                    break;

                case "price-descending":
                    query = query.OrderByDescending(x => x.PromotionPrice.HasValue ? x.PromotionPrice : x.Price);
                    break;

                case "title-ascending":
                    query = query.OrderBy(x => x.Name);
                    break;

                case "title-descending":
                    query = query.OrderByDescending(x => x.Name);
                    break;

                case "created-ascending":
                    query = query.OrderBy(x => x.ModifiedDate);
                    break;

                case "created-descending":
                    query = query.OrderByDescending(x => x.ModifiedDate);
                    break;
                default:
                    query = query.OrderByDescending(x => x.ModifiedDate);
                    break;
            }
            return query;

        }
        public IEnumerable<PRODUCT> ProductSale(string sort)
        {
            var query = db.PRODUCT.Where(x => x.Status == true && x.PromotionPrice.HasValue);
            switch (sort)
            {
                case "price-ascending":
                    query = query.OrderBy(x => x.PromotionPrice.HasValue ? x.PromotionPrice : x.Price);
                    break;

                case "price-descending":
                    query = query.OrderByDescending(x => x.PromotionPrice.HasValue ? x.PromotionPrice : x.Price);
                    break;

                case "title-ascending":
                    query = query.OrderBy(x => x.Name);
                    break;

                case "title-descending":
                    query = query.OrderByDescending(x => x.Name);
                    break;

                case "created-ascending":
                    query = query.OrderBy(x => x.ModifiedDate);
                    break;

                case "created-descending":
                    query = query.OrderByDescending(x => x.ModifiedDate);
                    break;
                default:
                    query = query.OrderByDescending(x => x.ModifiedDate);
                    break;
            }
            return query;
        }
        public void InsertView(long id)
        {
            var product = db.PRODUCT.Find(id);
            if (product.ViewCount.HasValue)
                product.ViewCount += 1;
            else
                product.ViewCount = 1;
            db.SaveChanges();
        }
        public void InsertLike(long id)
        {
            var product = db.PRODUCT.Find(id);
            if (product.Like.HasValue)
                product.Like += 1;
            else
                product.Like = 1;
            db.SaveChanges();
        }
        public List<string> ListName(string keyword)
        {
            return db.PRODUCT.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }
        public List<ProductViewModel> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.PRODUCT.Where(x => x.Name == keyword).Count();
            var model = (from a in db.PRODUCT
                         where a.Name.Contains(keyword)
                         select new
                         {
                             CateMetaTitle = a.Metatitle,
                             CateName = a.Name,
                             CreatedDate = a.CreatedDate,
                             ID = a.ID,
                             Images = a.Image,
                             Name = a.Name,
                             MetaTitle = a.Metatitle,
                             Price = a.Price
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             CateMetaTitle = x.MetaTitle,
                             CateName = x.Name,
                             CreatedDate = x.CreatedDate,
                             ID = x.ID,
                             Images = x.Images,
                             Name = x.Name,
                             MetaTitle = x.MetaTitle,
                             Price = x.Price
                         });
            model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
    }
}
