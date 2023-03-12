using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MovieForum.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                     "~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/jquery/css").Include(
                      "~/Content/jquery-ui.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/genresStyles/css").Include(
                    "~/Vendor/genresStyles.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/login/css").Include(
                    "~/Vendor/stylinn_login.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/registration/css").Include(
                   "~/Vendor/stylinn_registration.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/mainStyle/css").Include(
                   "~/Vendor/mainStyle.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/stylinn/css").Include(
                    "~/Vendor/stylinn.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/swiper/css").Include(
                   "~/Vendor/swiper-bundle.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new Bundle("~/bundles/bootstrap/js").
                Include("~/Scripts/bootstrap.min.js"));

            bundles.Add(new Bundle("~/bundles/jquery/js").
                Include("~/Scripts/jquery-3.6.0.min.js"));

            bundles.Add(new Bundle("~/bundles/addTopG/js").
                Include("~/Vendor/Scripts/addtopG.js"));

            bundles.Add(new Bundle("~/bundles/addTrending/js").
               Include("~/Vendor/Scripts/addTrending.js"));

            bundles.Add(new Bundle("~/bundles/addUpcoming/js").
               Include("~/Vendor/Scripts/addUpcoming.js"));

            bundles.Add(new Bundle("~/bundles/getForm/js").
               Include("~/Vendor/Scripts/getForm.js"));

            bundles.Add(new Bundle("~/bundles/getGenresTop/js").
               Include("~/Vendor/Scripts/getGenresTop.js"));

            bundles.Add(new Bundle("~/bundles/getTrending/js").
               Include("~/Vendor/Scripts/getTrending.js"));

            bundles.Add(new Bundle("~/bundles/getUpcoming/js").
               Include("~/Vendor/Scripts/getUpcoming.js"));

            bundles.Add(new Bundle("~/bundles/swiper/js").
                Include("~/Vendor/Scripts/swiper.js"));

            bundles.Add(new Bundle("~/bundles/swiper-bundle/js").
                Include("~/Vendor/Scripts/swiper-bundle.min.js"));

            bundles.Add(new Bundle("~/bundles/jquery-ui/js").
                Include("~/Scripts/jquery-ui.js"));

        }
    }
}