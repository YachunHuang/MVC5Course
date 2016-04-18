using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi1.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        //TODO:[JsonIgnore]加上後在Get資料時不會顯示這個欄位
        public decimal Price { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}