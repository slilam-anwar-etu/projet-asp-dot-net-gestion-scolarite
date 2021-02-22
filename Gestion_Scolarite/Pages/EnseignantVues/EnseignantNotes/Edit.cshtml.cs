using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestion_Scolarite.Data;
using Gestion_Scolarite.Models;

namespace Gestion_Scolarite.Pages.EnseignantVues.EnseignantNotes
{
    public class EditModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public EditModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Note Note { get; set; }

        public Matiere Matiere { get; set; }
        [BindProperty]
        public int IdMat { get; set; }

        public int theId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? idMatiere)
        {
            theId = (int)id;
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
            var etudiants =
               _context.Etudiants
                 .Where(e => e.ID == Note.EtudiantID)
                 .Select(e => new
                 {
                     ID = e.ID,
                     FullName = e.Nom + " " + e.Prenom
                 })
                 .ToList();
            ViewData["EtudiantID"] = new SelectList(etudiants, "ID", "FullName");
            
            return Page();
        }

        public IList<Absence> Absence { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? idMatiere)
        {
            if (idMatiere != null)
            {
                IdMat = (int)idMatiere;
                Note.MatiereID = (int)idMatiere;
                Absence = await _context.Absences
                    .Include(a => a.Seance)
                        .ThenInclude(a => a.Matiere)
                    .Include(a => a.Etudiant)
                    .Where(a => a.EtudiantID == Note.EtudiantID && a.Seance.MatiereID == idMatiere && a.Absence_Justifie == "Non")
                    .ToListAsync();
                Note.Note_Finale = Note.Note_Initiale - Absence.Count * 2;
            }
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(Note.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { idMatiere = IdMat });
        }

        private bool NoteExists(int id)
        {
            return _context.Notes.Any(e => e.ID == id);
        }
    }
}
