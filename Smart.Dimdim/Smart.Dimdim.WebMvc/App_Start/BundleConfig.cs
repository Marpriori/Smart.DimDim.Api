using System.Web.Optimization;

namespace Smart.Dimdim.WebMvc.App_Start
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
          
             bundles.Add(new StyleBundle("~/style/global").Include(
                "~/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                "~/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                "~/assets/global/plugins/bootstrap/css/bootstrap.min.css", 
                "~/assets/global/plugins/uniform/css/uniform.default.css"));       

             bundles.Add(new StyleBundle("~/style/login").Include(
                "~/assets/admin/pages/css/login3.css",
                "~/assets/global/plugins/select2/select2.css"));

             bundles.Add(new StyleBundle("~/style/theme").Include(
                "~/assets/global/css/components-md.css" ,
                "~/assets/global/css/plugins-md.css",
                "~/assets/admin/layout/css/layout.css",
                "~/assets/admin/layout/css/themes/default.css",
                "~/assets/admin/layout/css/custom.css" ));

            bundles.Add(new ScriptBundle("~/scripts/ie9").Include(
                "~/assets/global/plugins/respond.min.js",
                "~/assets/global/plugins/excanvas.min.js"));

            bundles.Add(new ScriptBundle("~/scripts/core").Include(
                "~/assets/global/plugins/jquery.min.js" ,
                "~/assets/global/plugins/jquery-migrate.min.js" ,
                "~/assets/global/plugins/bootstrap/js/bootstrap.min.js",
                "~/assets/global/plugins/jquery.blockui.min.js" ,
                "~/assets/global/plugins/uniform/jquery.uniform.min.js",
                "~/assets/global/plugins/jquery.cokie.min.js"));
        
            bundles.Add(new ScriptBundle("~/scripts/page-plugin").Include(
                "~/assets/global/plugins/jquery-validation/js/jquery.validate.min.js",
                "~/assets/global/plugins/select2/select2.min.js"));

             bundles.Add(new ScriptBundle("~/scripts/page-script").Include(
                "~/assets/global/scripts/metronic.js",
                "~/assets/admin/layout/scripts/layout.js" ,
                "~/assets/admin/layout/scripts/demo.js",
                "~/assets/admin/pages/scripts/login.js"));

        }
    }
}