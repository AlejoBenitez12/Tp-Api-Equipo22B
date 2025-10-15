using System.Web;
using System.Web.Mvc;

namespace TP_API_Progra_3_equipo_22B
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
