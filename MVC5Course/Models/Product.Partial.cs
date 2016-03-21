namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //TODO:複雜的驗證邏輯可以寫在這裡IValidatableObject
            //這個驗證會套用在create & update
            //欄位的驗證過了之後才會做這個模型驗證(關注點分離)

            //TODO:用來判斷是新增還是更新時的驗證default(欄位型態)
            if (this.ProductId == default(int))
            {
                //create only
            }
            else
            {
                //update only
            }

            if (this.Price < 100)
            {
                yield return new ValidationResult("Price error(模型驗證IValidatableObject)", 
                    new string[] { "Price"});
            }

            if (this.Stock > 10)
            {
                yield return new ValidationResult("Price error 2",
                    new string[] { "Stock" });
            }
        }
    }

    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
        
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
        [Required]
        [產品名稱至少包含兩個空白字元( ErrorMessage = "產品名稱至少包含兩個空白字元")]
        [產品名稱至少包含一個大寫字元( ErrorMessage = "產品名稱至少包含一個大寫字元")]
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<decimal> Stock { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
