using System.Web;
using System.Web.Mvc;

namespace Evoke.Rnd.Solr.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}