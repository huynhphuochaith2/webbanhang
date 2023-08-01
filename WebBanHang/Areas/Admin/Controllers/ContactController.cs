using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,NhanVien")]
    public class ContactController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Contact
        public ActionResult Index(int? page)
        {
            var items = db.Contacts.OrderByDescending(x => x.CreatedDate).ToList();
            if (page == null)
            {
                page = 1;
            }
            var pageNumber = page ?? 1;
            var pageSize = 10;
            ViewBag.PageSize = pageSize;
            ViewBag.Page = pageNumber;
            return View(items.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult View(int id)
        {
            var item = db.Contacts.Find(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult phanhoiTT(int id, string phanhoi)
        {
            var item = db.Contacts.Find(id);
            if (item != null)
            {
                db.Contacts.Attach(item);
                item.Message = phanhoi;
                db.Entry(item).Property(x => x.Message).IsModified = true;
                db.SaveChanges();
                return Json(new { message = "Success", Success = true });
            }
            return Json(new { message = "Success", Success = false });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Contacts.Find(id);
            if (item != null)
            {
                db.Contacts.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}