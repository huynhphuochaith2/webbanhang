using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using WebBanHang.Models.Common;
using WebBanHang.Models.EF;
using Newtonsoft.Json.Linq;

namespace WebBanHang.Controllers
{
    public class ContactController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Contact
       
        public ActionResult Index(string id)
        {
            var item = db.Contacts.FirstOrDefault(x => x.Alias == id);
            return View(item);
        }
        public async Task<JsonResult> Create(Contact model)
        {
            model.IsRead = false;
            model.CreatedDate = DateTime.Now;
            model.ModifiedDate = DateTime.Now;

            db.Contacts.Add(model);
            db.SaveChanges();


            var body = new StringBuilder();
            body.AppendLine("Name: " + model.Name);
            body.AppendLine("Email: " + model.Email);
            body.AppendLine("Phone: " + model.Phone);
            body.AppendLine("Message: " + model.Message);

            var isSsend = Common.SendMail(model.Name, "Contact Form Submission", body.ToString(), "hphai_20th@student.agu.edu.vn");



            return Json(new { status = "success" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(Contact model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var body = new StringBuilder();
                body.AppendLine("Name: " + model.Name);
                body.AppendLine("Email: " + model.Email);
                body.AppendLine("Phone: " + model.Phone);
                body.AppendLine("Message: " + model.Message);

                var message = new MailMessage();
                message.To.Add(new MailAddress("hphai_20th@student.agu.edu.vn"));  
                message.Subject = "Thông tin liên hệ";
                message.Body = body.ToString();

                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    ViewBag.Message = "Tin nhắn của bạn đã được gửi!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Xin lỗi, đã xảy ra lỗi khi gửi tin nhắn của bạn. Vui lòng thử lại sau.";
            }

            return View();
        }
        //[HttpPost]
        //public ActionResult FormSubmit()
        //{
        //    var response = Request["g-recaptcha-response"];
        //    string secretKey = "6Ld2csQlAAAAAPybABWLn4di_QW0_DjFnT_WP0yE";
        //    var client = new WebClient();
        //    var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
        //    var obj = JObject.Parse(result);
        //    var status = (bool)obj.SelectToken("success");
        //    ViewBag.Message = status ? "Google recaptcha validation success" : "Google recaptcha validation success failed";
        //    return View("Index");
        //}
    }
}
