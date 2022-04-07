using System.Web;
using System.Web.Mvc;

namespace Streaming_Movie_App_MVC_CSharp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
