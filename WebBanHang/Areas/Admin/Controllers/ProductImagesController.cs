using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using WebBanHang.Models.EF;

namespace WebBanHang.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,NhanVien")]
    public class ProductImagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProductImages
        public ActionResult Index(int id)
        {
            ViewBag.ProductId = id;
            var items = db.ProductImages.Where(x => x.ProductId == id).ToList();
            return View(items);
        }

        [HttpPost]
        public ActionResult AddImage(int productId,string url)
        {
            db.ProductImages.Add(new ProductImage
            {
                ProductId = productId,
                Image=url,
                IsDefault=false
            });
            db.SaveChanges();
            return Json(new { Success = true });
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.ProductImages.Find(id);
            if (item.IsDefault)
            {
                var listImage = db.ProductImages.Where(f => f.ProductId == item.ProductId && f.Id != item.Id).FirstOrDefault();
                if(listImage != null)
                {
                    listImage.IsDefault = true;
                    db.SaveChanges();
                }
            }
            db.ProductImages.Remove(item);
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
}