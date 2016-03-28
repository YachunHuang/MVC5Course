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
        //TODO:�N�쥻�g�bController�̪��޿�h�@�h�h����Model�o�̰��A�p�G�޿観�諸�ܫh���ݭn��o�̧Y�i�A��L�I�s���������|�@�֮M�ΡC
        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }
        //TODO:Repository�̪�Delete�p�G�n�諸�ܻݥ���tt�ɸ̭���_�h�|�@���Q�Ƽg���C
        //�粒tt�ɫ�A�ӳo�̼gvirtual�Y�i
        public virtual void Delete(Product entity)
        {
            entity.IsDelete = true;
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}