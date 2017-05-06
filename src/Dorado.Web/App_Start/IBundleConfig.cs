using System.Web.Optimization;

namespace Dorado.Web
{
    public interface IBundleConfig
    {
        void RegisterBundles(BundleCollection bundles);
    }
}