using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WISTML_FRAMEWORK_.Models.ViewModel
{
    public class TablaUsuariosViewModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string usuario { get; set; }
        public string email { get; set; }
        public string sexo { get; set; }
        //public string contraseña { get; set; }
        public int idEstado { get; set; }
        public System.DateTime fecha { get; set; }

        public virtual EstadoUsuario EstadoUsuario { get; set; }
    }
}