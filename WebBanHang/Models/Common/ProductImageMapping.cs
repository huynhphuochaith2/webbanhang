using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHang.Models.EF;

namespace WebBanHang.Models.Common
{
    public class ProductImageMapping
    {
        public Product Product { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}