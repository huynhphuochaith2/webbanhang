using System.Web;
using System.Web.Optimization;

namespace WebBanHang
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.validate.unobtrusive*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/Content/js").Include(
                      "~/Content/bootstrap.js", "~/Content/jquery-3.2.1.min.js", "~/Content/popper.js", "~/Content/bootstrap.min.js", "~/Content/isotope.pkgd.min.js", "~/Content/owl.carousel.js", "~/Content/easing.js", "~/Content/custom.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css", "~/Content/font-awesome.min.css", "~/Content/bootstrap.min.css", "~/Content/owl.carousel.css", "~/Content/owl.theme.default.css", "~/Content/animate.css", "~/Content/main_styles.css", "~/Content/responsive.css"));
            // file css hay js regis o day nhe.

        }
    }
}
