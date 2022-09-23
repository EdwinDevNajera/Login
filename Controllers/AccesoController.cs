using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Web.Mvc;
using WISTML_FRAMEWORK_.Models;
using System.Security.Cryptography;
using WISTML_FRAMEWORK_.Models.ViewModel;


namespace WISTML_FRAMEWORK_.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            try
            {
                using (UsuariosEntities db = new UsuariosEntities())

                {
                    string ePass = Utils.Encriptacion.GetSHA1(password);
                    var lstUser = from d in db.UsuarioTabla
                                   where d.email == email && d.idEstado == 1
                                   && d.contraseña == ePass
                                   select d;

                    if (lstUser.Count() > 0)

                    {

                        var oUsuarios = lstUser.First();
                        Session["Usuarios"] = oUsuarios;

                        return Content("1");

                    }

                    else

                    {

                        return Content("Error: Contraseña invalida o Usuario");

                    }

                }
            }

            catch(Exception ex)

            {
                return Content("Ocurrio un error" + ex);
            }

        }

        [HttpPost]
        public ActionResult LogOut()

        {

            Session["Usuarios"] = null;

            return Content("1");

        }

        

    }
}