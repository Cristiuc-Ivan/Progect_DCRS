using System.Security.Policy;
using System.Web.Optimization;

namespace Web.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // keep it 
            bundles.Add(new StyleBundle("~/bundles/genresStyles/css")
                .Include("~/Content/css/genresStyles.css", new CssRewriteUrlTransform()));
            // keep it
            bundles.Add(new StyleBundle("~/bundles/login/css")
                .Include("~/Content/css/stylinn_login.css", new CssRewriteUrlTransform()));
            // keep it
            bundles.Add(new StyleBundle("~/bundles/registration/css")
                .Include("~/Content/css/stylinn_registration.css", new CssRewriteUrlTransform()));
            // keep it
            bundles.Add(new StyleBundle("~/bundles/mainStyle/css")
                .Include("~/Content/css/mainStyle.css", new CssRewriteUrlTransform()));
            // keep it
            bundles.Add(new StyleBundle("~/bundles/stylinn/css")
                .Include("~/Content/css/stylinn.css", new CssRewriteUrlTransform()));
            // keep it
            bundles.Add(new StyleBundle("~/bundles/swiper/css")
                .Include("~/Content/css/swiper-bundle.min.css", new CssRewriteUrlTransform()));
            // keep it
            bundles.Add(new StyleBundle("~/bundles/footer/css")
                .Include("~/Content/css/footer.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include
                (
                "~/Vendor/css/bootstrap.min.css",
                "~/Vendor/css/jquery-ui.css"
                ));

            bundles.Add(new StyleBundle("~/bundles/forum/css").Include
                (
                "~/Content/css/forum_comments.css",
                "~/Content/css/forum_input_topicsform.css",
                "~/Content/css/forum_topics.css",
                "~/Content/css/forum_personalprofile.css",
                "~/Content/css/forum_searchform.css"
                ));

            bundles.Add(new StyleBundle("~/bundles/header_neaut/css")
                .Include("~/Content/css/header_neaut.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/header_aut/css")
                            .Include("~/Content/css/header_aut.css", new CssRewriteUrlTransform()));

            bundles.Add(new Bundle("~/bundles/bootstrap/js").Include
                (
                "~/Vendor/js/bootstrap.bundle.min.js",
                "~/Vendor/js/jquery-3.7.0.min.js",
                "~/Vendor/js/jquery-ui.js"
                ));

            // keep it
            bundles.Add(new Bundle("~/bundles/addGenresTop/js").Include
                (
                "~/Content/js/addtopG.js",
                "~/Content/js/getGenresTop.js"
                ));

            bundles.Add(new Bundle("~/bundles/addTrending/js").Include
                (
                "~/Content/js/getTrending.js",
                "~/Content/js/addTrending.js"
                ));

            bundles.Add(new Bundle("~/bundles/addUpcoming/js").Include
              (
              "~/Content/js/getUpcoming.js",
              "~/Content/js/addUpcoming.js"
              ));

            bundles.Add(new Bundle("~/bundles/processForm/js")
                .Include("~/Content/js/processForm.js"));

            bundles.Add(new Bundle("~/bundles/PostersAnimation/js")
                .Include("~/Content/js/PostersAnimation.js"));

            bundles.Add(new Bundle("~/bundles/forum_addactors/js")
               .Include("~/Content/js/forum_addactors.js"));

            bundles.Add(new Bundle("~/bundles/vanilla-tilt/js")
               .Include("~/Content/js/vanilla-tilt.js"));

            bundles.Add(new Bundle("~/bundles/swiper/js")
                .Include("~/Content/js/swiper.js"));

            bundles.Add(new Bundle("~/bundles/swiper-bundle/js")
                .Include("~/Content/js/swiper-bundle.min.js"));




            // Enable minification
            BundleTable.EnableOptimizations = true;

        }
    }
}