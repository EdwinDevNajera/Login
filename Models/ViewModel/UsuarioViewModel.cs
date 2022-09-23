using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WISTML_FRAMEWORK_.Models.ViewModel
{
    public class UsuarioViewModel
    {
        //[Required(ErrorMessage = "Usuario Requerido")]
        //[MinLength(7, ErrorMessage = "Longitud mínima 7 caracteres")]
        //public string usuario { get; set; }
        [Required(ErrorMessage = "usuario Requerido")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "Email Requerido")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string email { get; set; }
        [Required(ErrorMessage = "tipo de sexualidad Requerido")]
        public string sexo { get; set; }

        [Required(ErrorMessage = "Password Requerido")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{10,25}$", ErrorMessage = "Necesitas minimo 10 caracteres, 1 digito, 1 Mayuscula, 1 Minuscula, 1 Simbolo")]
        public string contraseña { get; set; }
        
        [Compare("contraseña", ErrorMessage ="No es igual")]
        public string confirmcontraseña { get; set; }

        //[RegularExpression("^true", ErrorMessage = "error expresion")]
        public int idEstado { get; set; }
        public System.DateTime fecha { get; set; }

        public virtual EstadoUsuario EstadoUsuario { get; set; }
    }

    public class EditarUsuarioViewModel
    {
        //[Required(ErrorMessage = "Usuario Requerido")]
        //[MinLength(7, ErrorMessage = "Longitud mínima 7 caracteres")]
        //public string usuario { get; set; }

        public int id { get; set; }

        public string usuario { get; set; }

        [Required(ErrorMessage = "Email Requerido")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string email { get; set; }
        public string sexo { get; set; }

        [Required(ErrorMessage = "Password Requerido")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{10,25}$", ErrorMessage = "error expresion")]
        public string contraseña { get; set; }
        //public Nullable<int> idEstado { get; set; }
        //public Nullable<System.DateTime> fecha { get; set; }
        [Compare("contraseña", ErrorMessage = "No es igual")]
        public string confirmcontraseña { get; set; }

        public virtual EstadoUsuario EstadoUsuario { get; set; }
    }

}