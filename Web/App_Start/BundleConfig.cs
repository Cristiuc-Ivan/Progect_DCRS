using System.Security.Policy;
using System.Web.Optimization;

namespace Web.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css")
                .Include("~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/jquery/css")
                .Include("~/Content/jquery-ui.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/genresStyles/css")
                .Include("~/Vendor/genresStyles.css", new CssRewriteUrlTransform()));



            bundles.Add(new StyleBundle("~/bundles/login/css")
                .Include("~/Vendor/stylinn_login.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/registration/css")
                .Include("~/Vendor/stylinn_registration.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/mainStyle/css")
                .Include("~/Vendor/mainStyle.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/stylinn/css")
                .Include("~/Vendor/stylinn.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/swiper/css")
                .Include("~/Vendor/swiper-bundle.min.css", new CssRewriteUrlTransform()));


            bundles.Add(new StyleBundle("~/bundles/footer/css")
                .Include("~/Vendor/footer.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/forum_comments/css")
                .Include("~/Vendor/forum_comments.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/forum_input_topicsform/css")
                .Include("~/Vendor/forum_input_topicsform.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/forum_topics/css")
                .Include("~/Vendor/forum_topics.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/header/css")
                .Include("~/Vendor/header.css", new CssRewriteUrlTransform()));



            bundles.Add(new Bundle("~/bundles/bootstrap/js")
                .Include("~/Scripts/bootstrap.min.js"));

            bundles.Add(new Bundle("~/bundles/jquery/js")
                .Include("~/Scripts/jquery-3.6.3.min.js"));

            bundles.Add(new Bundle("~/bundles/addTopG/js")
                .Include("~/Vendor/Scripts/addtopG.js"));

            bundles.Add(new Bundle("~/bundles/addTrending/js")
                .Include("~/Vendor/Scripts/addTrending.js"));

            bundles.Add(new Bundle("~/bundles/addUpcoming/js")
                .Include("~/Vendor/Scripts/addUpcoming.js"));

            bundles.Add(new Bundle("~/bundles/addForm/js")
                .Include("~/Vendor/Scripts/addForm.js"));

            bundles.Add(new Bundle("~/bundles/getForm/js")
                .Include("~/Vendor/Scripts/getForm.js"));

            bundles.Add(new Bundle("~/bundles/getGenresTop/js")
                .Include("~/Vendor/Scripts/getGenresTop.js"));

            bundles.Add(new Bundle("~/bundles/getTrending/js")
                .Include("~/Vendor/Scripts/getTrending.js"));

            bundles.Add(new Bundle("~/bundles/getUpcoming/js")
                .Include("~/Vendor/Scripts/getUpcoming.js"));

            bundles.Add(new Bundle("~/bundles/PostersAnimation/js")
                .Include("~/Vendor/Scripts/PostersAnimation.js"));

            bundles.Add(new Bundle("~/bundles/swiper/js")
                .Include("~/Vendor/Scripts/swiper.js"));

            bundles.Add(new Bundle("~/bundles/swiper-bundle/js")
                .Include("~/Vendor/Scripts/swiper-bundle.min.js"));

            bundles.Add(new Bundle("~/bundles/jquery-ui/js")
                .Include("~/Scripts/jquery-ui.js"));

        }
    }
}