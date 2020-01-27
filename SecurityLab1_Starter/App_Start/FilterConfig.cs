using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
                filters.Add(new HandleErrorAttribute());
        }
    }
}
