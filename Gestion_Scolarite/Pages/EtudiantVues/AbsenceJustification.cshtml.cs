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
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Gestion_Scolarite.Pages.EtudiantVues
{
    public class AbsenceJustificationModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public AbsenceJustificationModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Absence Absence { get; set; }

        public int? IdEtud { get; set; }
        public int? IdSea { get; set; }

        [BindProperty]
        public IFormFile file { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? idEtudiant, int? idSeance)
        {
            if (idEtudiant != null)
            {
                IdEtud = idEtudiant;
            }

            if (idSeance != null)
            {
                IdSea = idSeance;
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (file != null)
            {
                if (file.Length > 0 && file.Length < 300000)
                {
                    using (var target = new MemoryStream())
                    {
                        file.CopyTo(target);
                        Absence.Fichier = target.ToArray();
                    }
                }

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

            return RedirectToPage("./EtudiantAbsences");
        }

        private bool AbsenceExists(int id)
        {
            return _context.Absences.Any(e => e.ID == id);
        }
    }
}
