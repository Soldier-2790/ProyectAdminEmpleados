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
    public class IndexModel : PageModel
    {
        private readonly AdminEmpl.Servicios.AppDbContext _context;

        public IndexModel(AdminEmpl.Servicios.AppDbContext context)
        {
            _context = context;
        }

        public IList<Empleado> Empleado { get;set; }

        public async Task OnGetAsync()
        {
            Empleado = await _context.Empleados.ToListAsync();
        }
    }
}
