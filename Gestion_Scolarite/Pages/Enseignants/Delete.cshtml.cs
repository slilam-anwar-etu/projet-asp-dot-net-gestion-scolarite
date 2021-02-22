using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestion_Scolarite.Models;
using Gestion_Scolarite.Data;

namespace Gestion_Scolarite.Pages.Enseignants
{
    public class DeleteModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public DeleteModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, int? idDepartement)
        {
            if (idDepartement != null)
            {
                IdDept = (int)idDepartement;
            }

            if (id == null)
            {
                return NotFound();
            }

            Enseignant = await _context.Enseignants.FindAsync(id);

            if (Enseignant != null)
            {
                _context.Enseignants.Remove(Enseignant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { idDepartement = IdDept });
        }
    }
}
