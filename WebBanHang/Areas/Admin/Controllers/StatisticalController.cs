using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,NhanVien")]
    public class StatisticalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Statistical
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetStatistical(string fromDate,string toDate)
        {
            var query = from o in db.Orders
                        join od in db.orderDetails
                        on o.Id equals od.OrderId
                        join p in db.Products
                        on od.ProductId equals p.Id
                        select new
                        {// đầu tiên nó tạo ra một truy vấn LINQ để lấy ra các chi tiết đơn hàng, bao gồm các thuộc tính CreateDate , Quantity, Price, OriginalPrice.
                            CreateDate = o.CreatedDate,
                            Quantity = od.Quantity,
                            Price = od.Price,
                            OriginalPrice = p.OriginalPrice
                        };
            if(!string.IsNullOrEmpty(fromDate))
            {
                DateTime starDate = DateTime.ParseExact(fromDate, "dd/MM/yyyy",null);
                query = query.Where(x => x.CreateDate >= starDate);
            }
            if (!string.IsNullOrEmpty(toDate))
            {
                DateTime endDate = DateTime.ParseExact(toDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.CreateDate < endDate);
            }
            var result = query.GroupBy(x => DbFunctions.TruncateTime(x.CreateDate)).Select(x => new
            {// truy vấn được nhóm theo ngày và tính tổng số tiền bán được (TotalSell) và tổng chi phí mua hàng (TotalBuy) trong mỗi ngày.
             // Cuối cùng, kết quả được trả về dưới dạng một đối tượng JSON chứa một mảng các đối tượng, mỗi đối tượng chứa thông tin về ngày, doanh thu và lợi nhuận của ngày đó.
                Date = x.Key.Value,
                TotalBuy = x.Sum(y => y.Quantity * y.OriginalPrice),
                TotalSell = x.Sum(y => y.Quantity * y.Price),

            }).Select(x => new
            {
                Date = x.Date,
                DoanhThu = x.TotalSell,
                LoiNhuan = x.TotalSell - x.TotalBuy
            });
            return Json(new { Date = result.ToList() }, JsonRequestBehavior.AllowGet);
        }
    }
}