using AdminEmpl.Modelos;
using AdminEmpl.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace AdminEmpl.Web.Pages.Empleados
{
    public class IndexModel : PageModel
    {
        private readonly IEmpleadoRepo empleadoRepo;
        public IEnumerable<Empleado> Empleados { get; set; }
        [BindProperty(SupportsGet = true)]
        public string TermBusq { get; set; }
        public IndexModel(IEmpleadoRepo empleadoRepo)
        {
            this.empleadoRepo = empleadoRepo;
        }
        public void OnGet()
        {
            Empleados = empleadoRepo.BuscEmpl(TermBusq);
        }
    }
}
