using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AdminEmpl.Modelos;
using AdminEmpl.Servicios;

namespace AdminEmpl.Web.Pages.EFCRUDEmpl
{
    public class CreateModel : PageModel
    {
        private readonly AdminEmpl.Servicios.AppDbContext _context;

        public CreateModel(AdminEmpl.Servicios.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Empleado Empleado { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Empleados.Add(Empleado);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
