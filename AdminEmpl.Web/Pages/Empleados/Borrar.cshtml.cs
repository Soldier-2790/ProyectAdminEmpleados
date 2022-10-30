using AdminEmpl.Modelos;
using AdminEmpl.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminEmpl.Web.Pages.Empleados
{
    public class BorrarModel : PageModel
    {
        private readonly IEmpleadoRepo empleadoRepo;
        public BorrarModel(IEmpleadoRepo empleadoRepo)
        {
            this.empleadoRepo = empleadoRepo;
        }
        [BindProperty]
        public Empleado Empleado { get; set; }
        public IActionResult OnGet(int id)
        {
            Empleado = empleadoRepo.ObtEmpleado(id);
            if (Empleado == null)
            {
                return RedirectToPage("/EmplNoEncont");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            Empleado empleadoBorr = empleadoRepo.BorrEmpleado(Empleado.Id);
            if (empleadoRepo == null)
            {
                return RedirectToPage("/EmplNoEncont");
            }
            return RedirectToPage("Index");
        }
    }
}
