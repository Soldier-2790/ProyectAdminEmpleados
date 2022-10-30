using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AdminEmpl.Modelos;
using AdminEmpl.Servicios;

namespace AdminEmpl.Web.Pages.EFCRUDEmpl
{
    public class DetailsModel : PageModel
    {
        private readonly AdminEmpl.Servicios.AppDbContext _context;

        public DetailsModel(AdminEmpl.Servicios.AppDbContext context)
        {
            _context = context;
        }

        public Empleado Empleado { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Empleado = await _context.Empleados.FirstOrDefaultAsync(m => m.Id == id);

            if (Empleado == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
