using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestion_Scolarite.Data;
using Gestion_Scolarite.Models;

namespace Gestion_Scolarite.Pages.EnseignantVues.EnseignantNotes
{
    public class DeleteModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public DeleteModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Note Note { get; set; }

        public Matiere Matiere { get; set; }
        [BindProperty]
        public int IdMat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? idMatiere)
        {
            if (idMatiere != null)
            {
                IdMat = (int)idMatiere;
            }

            if (id == null)
            {
                return NotFound();
            }

            Note = await _context.Notes
                .Include(n => n.Etudiant)
                .Include(n => n.Matiere).FirstOrDefaultAsync(m => m.ID == id);

            if (Note == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, int? idMatiere)
        {
            if (idMatiere != null)
            {
                IdMat = (int)idMatiere;
            }

            if (id == null)
            {
                return NotFound();
            }

            Note = await _context.Notes.FindAsync(id);

            if (Note != null)
            {
                _context.Notes.Remove(Note);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { idMatiere = IdMat });
        }
    }
}
