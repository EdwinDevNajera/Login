using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WISTML_FRAMEWORK_.Models.ViewModel;
using WISTML_FRAMEWORK_.Models;
using System.Security.Cryptography;

namespace WISTML_FRAMEWORK_.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new UsuariosEntities())
            {
                UsuarioTabla oUsuarios = new UsuarioTabla();
                //string ePass = Utils.CrearEncriptacion.encriptar(password);
                string ePass = Utils.Encriptacion.GetSHA1(model.contraseña);
                oUsuarios.idEstado = 1;
                oUsuarios.usuario = model.usuario;
                oUsuarios.email = model.email;

                oUsuarios.contraseña = ePass;

                //oUsuarios.contraseña = model.contraseña;

                oUsuarios.sexo = model.sexo;
                oUsuarios.fecha = System.DateTime.Now;


                db.UsuarioTabla.Add(oUsuarios);

                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Home/Index"));
        }

        public ActionResult Editar(int id)
        {
            EditarUsuarioViewModel model = new EditarUsuarioViewModel();

            using (var db = new UsuariosEntities())
            {
                var ousuario = db.UsuarioTabla.Find(id);
                //string ePass = Utils.Encriptacion.GetSHA1(model.contraseña);
                //string ePass2 = Utils.Encriptacion.GetSHA1(ePass);

                model.id = ousuario.id;
                model.usuario = ousuario.usuario;
                model.email = ousuario.email;
                //model.contraseña = ousuario.contraseña;
                //ePass2 = ousuario.contraseña;
                model.sexo = ousuario.sexo;

            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(EditarUsuarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new UsuariosEntities())
            {
                var ousuario = db.UsuarioTabla.Find(model.id);
                string ePass = Utils.Encriptacion.GetSHA1(model.contraseña);
                //string ePass2 = Utils.Encriptacion.GetSHA1(ePass);
                ousuario.usuario = model.usuario;
                ousuario.email = model.email;
                //ousuario.contraseña = model.contraseña;
                ousuario.contraseña = ePass;
                ousuario.sexo = model.sexo;

                if (ePass != null && ePass.Trim() != "")
                {
                    ousuario.contraseña = ePass;
                }

                db.Entry(ousuario).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Redirect(Url.Content("~/Home/Index"));
        }


        [HttpPost]
        public ActionResult Inactivo(int id)
        {

            using (var db = new UsuariosEntities())
            {
                var ousuario = db.UsuarioTabla.Find(id);

                ousuario.idEstado = 0;

                db.Entry(ousuario).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Content("6");
        }
    }
}