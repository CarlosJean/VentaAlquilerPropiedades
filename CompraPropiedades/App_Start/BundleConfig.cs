using System.Web;
using System.Web.Optimization;

namespace CompraPropiedades
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {
            //Scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery_ui_touch_punch").Include(
                        "~/Scripts/jquery_ui_punch_touch.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                      "~/Scripts/popper.js"));

            bundles.Add(new ScriptBundle("~/bundles/Buscar.js").Include(
                        "~/Scripts/Buscar/Buscar.js"));

            bundles.Add(new ScriptBundle("~/bundles/Publication.js").Include(
                        "~/Scripts/Publication/Publication.js"));

            bundles.Add(new ScriptBundle("~/bundles/Post.js").Include(
                        "~/Scripts/Post/Post.js"));

            bundles.Add(new ScriptBundle("~/bundles/MyPosts.js").Include(
                        "~/Scripts/MyPosts/MyPosts.js"));

            //Estilos
            bundles.Add(new StyleBundle("~/bundles/bootstrap.min.css").Include(
                        "~/Content/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/bundles/jquery-ui.min.css").Include(
                        "~/Content/themes/base/jquery-ui.min.css"));

            bundles.Add(new StyleBundle("~/bundles/Buscar.css").Include(
                        "~/Content/Buscar/Buscar.css"));

            bundles.Add(new StyleBundle("~/bundles/Styles.css").Include(
                        "~/Content/Styles.css"));

            bundles.Add(new StyleBundle("~/bundles/Publication.css").Include(
                        "~/Content/Publication/Publication.css"));

            bundles.Add(new StyleBundle("~/bundles/Detail.css").Include(
                        "~/Content/Detail/Detail.css"));

            bundles.Add(new StyleBundle("~/bundles/Post.css").Include(
                        "~/Content/Post/Post.css"));

            bundles.Add(new StyleBundle("~/bundles/SavedPost.css").Include(
                        "~/Content/Post/SavedPost.css"));

            bundles.Add(new StyleBundle("~/bundles/MyPublications.css").Include(
                        "~/Content/MyPublications/MyPublications.css"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
