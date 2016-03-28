using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public override IQueryable<Product> All()
        {
            return base.All().Where(p => p.IsDelete == false);
        }
        //TODO:將原本寫在Controller裡的邏輯多一層搬移到Model這裡做，如果邏輯有改的話則指需要改這裡即可，其他呼叫的頁面都會一併套用。
        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }
        //TODO:Repository裡的Delete如果要改的話需先到tt檔裡面改否則會一直被複寫掉。
        //改完tt檔後再來這裡寫virtual即可
        public virtual void Delete(Product entity)
        {
            entity.IsDelete = true;
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}