using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestion_Scolarite.Models;
using Gestion_Scolarite.Data;

namespace Gestion_Scolarite.Pages.EnseignantVues.EnseignantAbsences
{
    public class DeleteModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public DeleteModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Absence Absence { get; set; }

        [BindProperty]
        public int IdSe { get; set; }

        [BindProperty]
        public int IdMat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? idMatiere, int? idSeance)
        {
            if (idSeance != null)
            {
                IdSe = (int)idSeance;
            }
            if (idMatiere != null)
            {
                IdMat = (int)idMatiere;
            }

            if (id == null)
            {
                return NotFound();
            }

            Absence = await _context.Absences
                .Include(a => a.Etudiant)
                .Include(a => a.Seance).FirstOrDefaultAsync(m => m.ID == id);

            if (Absence == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, int? idMatiere, int? idSeance)
        {
            if (idSeance != null)
            {
                IdSe = (int)idSeance;
            }
            if (idMatiere != null)
            {
                IdMat = (int)idMatiere;
            }

            if (id == null)
            {
                return NotFound();
            }

            Absence = await _context.Absences.FindAsync(id);

            if (Absence != null)
            {
                _context.Absences.Remove(Absence);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { idMatiere = IdMat, idSeance = IdSe });
        }
    }
}
