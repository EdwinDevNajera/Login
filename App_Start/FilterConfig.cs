using System.Web;
using System.Web.Mvc;
using WISTML_FRAMEWORK_.Filtro;

namespace WISTML_FRAMEWORK_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new VerificacionSesion());
        }
    }
}
