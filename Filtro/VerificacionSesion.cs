using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WISTML_FRAMEWORK_.Controllers;
using WISTML_FRAMEWORK_.Models;
using WISTML_FRAMEWORK_.Filtro;

namespace WISTML_FRAMEWORK_.Filtro
{
    public class VerificacionSesion : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            UsuarioTabla oUsuario = (UsuarioTabla)HttpContext.Current.Session["Usuarios"];

            if (oUsuario == null)

            {

                if (filterContext.Controller is AccesoController == false)

                {

                    filterContext.HttpContext.Response.Redirect("/Acceso/Index");

                }

            }

            base.OnActionExecuting(filterContext);
        }

    }
}