using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestion_Scolarite.Models;
using Gestion_Scolarite.Data;

namespace Gestion_Scolarite.Pages.Enseignants
{
    public class EditModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public EditModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Enseignant Enseignant { get; set; }

        [BindProperty]
        public int IdDept { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? idDepartement)
        {
            if (idDepartement != null)
            {
                IdDept = (int)idDepartement;
            }

            if (id == null)
            {
                return NotFound();
            }

            Enseignant = await _context.Enseignants
                .Include(e => e.Role)
                .Include(e => e.Departement).FirstOrDefaultAsync(m => m.ID == id);

            if (Enseignant == null)
            {
                return NotFound();
            }
           ViewData["RoleID"] = new SelectList(_context.Roles, "ID", "Designation");
           ViewData["DepartementID"] = new SelectList(_context.Departements, "ID", "Designation");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
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

            _context.Attach(Enseignant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnseignantExists(Enseignant.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { idDepartement = IdDept });
        }

        private bool EnseignantExists(int id)
        {
            return _context.Enseignants.Any(e => e.ID == id);
        }
    }
}
