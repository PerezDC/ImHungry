using System.Web;
using System.Web.Optimization;

namespace ImHungryApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/sass").Include(
                      "~/dist/css/styles.css"));

            bundles.Add(new ScriptBundle("~/bundles/start").Include(
                "~/dist/"));
        }
    }
}
