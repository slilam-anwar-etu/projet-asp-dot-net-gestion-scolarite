using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gestion_Scolarite.Models;
using Gestion_Scolarite.Data;

namespace Gestion_Scolarite.Pages.Enseignants
{
    public class CreateModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public CreateModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int IdDept { get; set; }

        public IActionResult OnGet(int? idDepartement)
        {
            if(idDepartement != null)
            {
                IdDept = (int)idDepartement;
            }
        
        ViewData["RoleID"] = new SelectList(_context.Roles, "ID", "Designation");
        ViewData["DepartementID"] = new SelectList(_context.Departements, "ID", "Designation");
            return Page();
        }

        [BindProperty]
        public Enseignant Enseignant { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int? idDepartement)
        {
            if (idDepartement != null)
            {
                IdDept = (int)idDepartement;
                Enseignant.DepartementID = (int)idDepartement;
                Enseignant.RoleID = 2;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Enseignants.Add(Enseignant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { idDepartement = IdDept });
        }
    }
}
