using System.Web;
using System.Web.Optimization;

namespace Quiron.LojaVirtual.V2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-1.*"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));

            //bundles.Add(new StyleBundle("~/Content/css")
            //    .Include(
            //    "~/Content/bootstrap.css",
            //    "~/Content/bootstrap-min.css",
            //    "~/Content/ErroEstilo.css"
            //    ));


            bundles.Add(new StyleBundle("~/css").Include(
                "~/css/*.css"));
            bundles.Add(new ScriptBundle("~/js").Include(
                "~/js/jquery.js" ,
                "~/js/bootstrap.js"
                ));
            bundles.Add(new StyleBundle("~/Content/startmenu").Include(
                "~/Content/sm-core-css.css",
                //ESTILOS DE MENU
                //"~/Content/sm-simple/sm-simple.css"
                "~/Content/sm-mint/sm-mint.css"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/startmenus").Include(
                "~/Scripts/jquery.smartmenus.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/jsprojetos").Include(
                "~/Scripts/menu.js"
                ));
            bundles.Add(new ScriptBundle("~/Scripts/navgoco").Include(
                "~/js/jquery.navgoco.js"
                ));

            BundleTable.EnableOptimizations = false;
        }
    }
}
