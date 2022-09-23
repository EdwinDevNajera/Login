using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WISTML_FRAMEWORK_.Models;
using WISTML_FRAMEWORK_.Models.ViewModel;

namespace WISTML_FRAMEWORK_.Controllers
{
    public class TablaUsuariosController : Controller
    {
        // GET: TablaUsuarios
        public ActionResult Tabla()
        {
            List<TablaUsuariosViewModel> lts;

            using (UsuariosEntities entities = new UsuariosEntities())

            {
                lts = (from d in entities.UsuarioTabla

                      where d.idEstado == 1 

                       orderby d.id
                      
                       select new TablaUsuariosViewModel
                      {
                          id = d.id,
                          usuario = d.usuario,
                          email = d.email,
                          sexo = d.sexo,
                          nombre = d.EstadoUsuario.nombre,
                          fecha = d.fecha

                      }).ToList();
            }

            return View(lts);

        }
    }
}