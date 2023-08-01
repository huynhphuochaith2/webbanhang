using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class IntroController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Intro
        public ActionResult Index(string id)
        {
            var item = db.Posts.FirstOrDefault(x => x.Alias == id);
            return View(item);
        }
    }
}