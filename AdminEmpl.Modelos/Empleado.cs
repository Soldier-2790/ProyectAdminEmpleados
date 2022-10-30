using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace AdminEmpl.Modelos
{
    public class Empleado
    {
        [Display(Name = "Identificador")]
        public int Id { get; set; }
        //Sí queremos que un parámetro sea requerido debimos haber instalado el paquete de System.ComponentModel.DataAnnotations
        //El cual nos permitirá darle propiedades a las variables que tienen nuestras clases que representan modelos.
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Nombre es requerido")]
        [MinLength(3, ErrorMessage = "El nombre debe ser de al menos 3 carácteres")]
        public string Nombre { get; set; }
        [Display(Name = "Correo Electronico")]
        [Required(ErrorMessage = "Correo electronico es requerido")]
        [RegularExpression(@"[a-zA-z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9.]+$", ErrorMessage = "Formato del correo electronico invalido")]
        public string CorreoE { get; set; }
        [Display(Name = "Foto de perfil")]
        public string FotoDir { get; set; }
        [
            Required(ErrorMessage = "Departamento es requerido"),
            Display(Name = "Departamento")
        ]
        public Departamento? Depart { get; set; }
    }
}
