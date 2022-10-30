using AdminEmpl.Modelos;
using AdminEmpl.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace AdminEmpl.Web.ViewComponents
{
    public class CabContViewComponent : ViewComponent
    {
        private readonly IEmpleadoRepo empleadoRepo;

        public CabContViewComponent(IEmpleadoRepo empleadoRepo)
        {
            this.empleadoRepo = empleadoRepo;
        }
        public IViewComponentResult Invoke(Departamento? departNom = null)
        {
            var result = empleadoRepo.ContDepatEmpl(departNom);
            return View(result);
        }
    }
}
