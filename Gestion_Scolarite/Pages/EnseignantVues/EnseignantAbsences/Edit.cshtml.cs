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

namespace Gestion_Scolarite.Pages.EnseignantVues.EnseignantAbsences
{
    public class EditModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public EditModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Absence Absence { get; set; }

        [BindProperty]
        public int IdSe { get; set; }

        [BindProperty]
        public int IdMat { get; set; }

        public List<SelectListItem> Abs { get; set; }

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
            var etudiants =
               _context.Etudiants
                 .Where(e => e.ID == Absence.EtudiantID)
                 .Select(e => new
                 {
                     ID = e.ID,
                     FullName = e.Nom + " " + e.Prenom
                 })
                 .ToList();
            ViewData["EtudiantID"] = new SelectList(etudiants, "ID", "FullName");
            Abs = new List<SelectListItem>
            {
                new SelectListItem{ Text="Oui", Value = "Oui" },
                new SelectListItem{ Text="Non", Value = "Non" },
            };
            ViewData["Absence_Justifie"] = new SelectList(Abs, "Value", "Text");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? idMatiere, int? idSeance)
        {
            if (idSeance != null)
            {
                IdSe = (int)idSeance;
                Absence.SeanceID = (int)idSeance;
            }
            if (idMatiere != null)
            {
                IdMat = (int)idMatiere;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Absence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbsenceExists(Absence.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { idMatiere = IdMat, idSeance = IdSe });
        }

        private bool AbsenceExists(int id)
        {
            return _context.Absences.Any(e => e.ID == id);
        }
    }
}
