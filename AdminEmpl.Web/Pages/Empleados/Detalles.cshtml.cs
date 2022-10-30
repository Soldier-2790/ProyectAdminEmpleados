using AdminEmpl.Modelos;
using AdminEmpl.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace AdminEmpl.Web.Pages.Empleados
{
    public class DetallesModel : PageModel
    {
        private readonly IEmpleadoRepo empleadoRepo;
        public DetallesModel(IEmpleadoRepo empleadoRepo)
        {
            this.empleadoRepo = empleadoRepo;
        }
        //La propiedad BindProperty puede ayudar a obtener parámetros sin que pase por el método OnGet
        //Esto puede funcionar para diversas tareas
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public Empleado Empleado { get; private set; }
        //Normalmente el método OnGet no tiene un retorno de dato, por lo que siempre aparecerá un void por el molde de la página
        //Podemos cambiar que retorne la página en cuestión de la siguiente manera: debemos cambiar la palabra clave del método.
        //void -> IActionResult esto retornará la interface de resultado de acciones
        //Debemos añadir el retorno el cual será el constructor Page o RedirectToPage
        //Page es el constructor correspondiente a la página que se quiere acceder
        //RedirectToPage es el constructor correspondiente a la página que se redirigirá en caso de que no encuentre el empleado
        //Si queremos hacer más dinámico los sitios web se usa el routin para obtener datos como mensajes.
        //[BindProperty(SupportsGet =true)]
        //Sí queremos que la variable tome datos temporales de manera automática podemos usar la propiedad de [TempData]
        [TempData]
        public string Msg { get; set; }
        public IActionResult OnGet(int id)
        {
            Id = id;
            Console.WriteLine($"Empleado con ID: {Id}");
            Empleado = empleadoRepo.ObtEmpleado(id);
            if (Empleado == null)
            {
                return RedirectToPage("/EmplNoEncont");
            }
            return Page();
        }
    }
}
