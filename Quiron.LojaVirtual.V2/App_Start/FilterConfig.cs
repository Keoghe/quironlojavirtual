using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.V2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
