using System.Web;
using System.Web.Optimization;

namespace Proyecto
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //PLUGINS

            bundles.Add(new ScriptBundle("~/bundles/Plugins/css").Include(
                        "~/Content/datatable/css/jquery.dataTables.min.css",
                        "~/Content/datatable/css/responsive.dataTables.min.css",
                        "~/Content/datatable/css/buttons.dataTables.min.css",
                        "~/Content/fontawesome/css/all.css"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/Plugins/js").Include(
                        "~/Content/datatable/js/jquery.dataTables.min.js",
                        "~/Content/datatable/js/dataTables.responsive.min.js",
                        "~/Content/datatable/js/dataTables.buttons.min.js",
                        "~/Content/fontawesome/js/all.js"
                        ));

        }
    }
}
