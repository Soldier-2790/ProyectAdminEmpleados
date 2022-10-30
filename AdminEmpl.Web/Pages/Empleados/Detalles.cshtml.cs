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
        //La propiedad BindProperty puede ayudar a obtener par�metros sin que pase por el m�todo OnGet
        //Esto puede funcionar para diversas tareas
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public Empleado Empleado { get; private set; }
        //Normalmente el m�todo OnGet no tiene un retorno de dato, por lo que siempre aparecer� un void por el molde de la p�gina
        //Podemos cambiar que retorne la p�gina en cuesti�n de la siguiente manera: debemos cambiar la palabra clave del m�todo.
        //void -> IActionResult esto retornar� la interface de resultado de acciones
        //Debemos a�adir el retorno el cual ser� el constructor Page o RedirectToPage
        //Page es el constructor correspondiente a la p�gina que se quiere acceder
        //RedirectToPage es el constructor correspondiente a la p�gina que se redirigir� en caso de que no encuentre el empleado
        //Si queremos hacer m�s din�mico los sitios web se usa el routin para obtener datos como mensajes.
        //[BindProperty(SupportsGet =true)]
        //S� queremos que la variable tome datos temporales de manera autom�tica podemos usar la propiedad de [TempData]
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
