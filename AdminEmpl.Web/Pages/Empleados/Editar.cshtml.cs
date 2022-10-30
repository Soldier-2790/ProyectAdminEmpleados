using AdminEmpl.Modelos;
using AdminEmpl.Servicios;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System;

namespace AdminEmpl.Web.Pages.Empleados
{
    public class EditarModel : PageModel
    {
        private readonly IEmpleadoRepo empleadoRepo;
        private readonly IWebHostEnvironment ambientHostWeb;
        public EditarModel(IEmpleadoRepo empleadoRepo, IWebHostEnvironment ambientHostWeb)
        {
            this.empleadoRepo = empleadoRepo;
            this.ambientHostWeb = ambientHostWeb;
        }
        //Variable empleados que deriva de Empleado, no tiene las propiedades de requerido
        //public Empleado Empleado { get; set; }
        //Aquí ya aplica las propiedades del método
        [BindProperty]
        public Empleado Empleado { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Empleado = empleadoRepo.ObtEmpleado(id.Value);
            }
            else
            {
                Empleado = new Empleado();
            }
            if (Empleado == null)
            {
                return RedirectToPage("/EmplNoEncont");
            }
            return Page();
        }
        /*
        Podemos usar la propiedad de la variable [BindProperty] como se muestra a continuación
        [BindProperty]
        public Empleado Empleado { get; set; }
         */
        /*
        Para poder asignar una foto a una variable se declara una variable de la interface IFormFile
        Lo que hace al ser llamado para un formulario dectecta el dato que recibirá
         */
        [BindProperty]
        public IFormFile foto { get; set; }
        [BindProperty]
        public bool Notif { get; set; }
        public string Msg { get; set; }
        public IActionResult OnPostActNotifPref(int id)
        {
            if (Notif)
            {
                Msg = "Gracias por encender las notificaciones.";
            }
            else
            {
                Msg = "Has desactivado las notificaciones.";
            }
            //Empleado = empleadoRepo.ObtEmpleado(id);
            TempData["Msg"] = Msg;
            //return RedirectToPage("Detalles", new { id = id, Msg = Msg });
            return RedirectToPage("Detalles", new { id = id });
        }
        //Sin validar
        /*
        public IActionResult OnPost(Empleado empleado)
        {
                if (foto != null)
                {
                    if (empleado.FotoDir != null)
                    {
                        string archDir = Path.Combine(ambientHostWeb.WebRootPath, "images", empleado.FotoDir);
                        System.IO.File.Delete(archDir);
                    }
                    empleado.FotoDir = ProcSubirFoto();
                }
                Empleado = empleadoRepo.EditEmpleado(empleado);
                return RedirectToPage("Index");
        }
        */
        //Con validación
        //Con este método nos saldrá una excepción
        /*
        public IActionResult OnPost(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                if (foto != null)
                {
                    if (empleado.FotoDir != null)
                    {
                        string archDir = Path.Combine(ambientHostWeb.WebRootPath, "images", empleado.FotoDir);
                        System.IO.File.Delete(archDir);
                    }
                    empleado.FotoDir = ProcSubirFoto();
                }
                Empleado = empleadoRepo.EditEmpleado(empleado);
                return RedirectToPage("Index");
            }
            return Page();
        }
        */
        //Sin excepciones
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (foto != null)
                {
                    if (Empleado.FotoDir != null)
                    {
                        string archDir = Path.Combine(ambientHostWeb.WebRootPath, "images", Empleado.FotoDir);
                        System.IO.File.Delete(archDir);
                    }
                    Empleado.FotoDir = ProcSubirFoto();
                }
                if (Empleado.Id > 0)
                {
                    Empleado = empleadoRepo.EditEmpleado(Empleado);
                }
                else
                {
                    Empleado = empleadoRepo.AgregEmpleado(Empleado);
                }
                return RedirectToPage("Index");
            }
            return Page();
        }
        private string ProcSubirFoto()
        {
            string unicoNomFot = null;//Iniciamos la variable en donde estará la dirección del archivo
            if (foto != null)
            {
                string subirCarp = Path.Combine(ambientHostWeb.WebRootPath, "images");
                unicoNomFot = Guid.NewGuid().ToString() + "_" + foto.FileName;
                string archDir = Path.Combine(subirCarp, unicoNomFot);
                using (var flujArch = new FileStream(archDir, FileMode.Create))
                {
                    foto.CopyTo(flujArch);
                }
            }
            return unicoNomFot;
        }
    }
}
