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

namespace Gestion_Scolarite.Pages.Modules
{
    public class EditModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public EditModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Module Module { get; set; }

        [BindProperty]
        public int IdNiv { get; set; }

        [BindProperty]
        public int IdFil { get; set; }

        public List<SelectListItem> Semestres { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? idNiveau, int? idFiliere)
        {
            if (idNiveau != null)
            {
                IdNiv = (int)idNiveau;
            }
            if (idFiliere != null)
            {
                IdFil = (int)idFiliere;
            }

            if (id == null)
            {
                return NotFound();
            }

            Module = await _context.Modules
                .Include(r => r.Responsable)
                .Include(n => n.Niveau).FirstOrDefaultAsync(m => m.ID == id);

            if (Module == null)
            {
                return NotFound();
            }

            var enseignants = _context.Enseignants
                .Select(e => new
                {
                    ID = e.ID,
                    FullName = e.Nom + " " + e.Prenom
                })
                .ToList();

            ViewData["Responsable"] = new SelectList(enseignants, "ID", "FullName");

            Semestres = new List<SelectListItem>
            {
                new SelectListItem{ Text="Semestre 1", Value = "S1" },
                new SelectListItem{ Text="Semestre 2", Value = "S2" },
            };
            ViewData["Semestre"] = new SelectList(Semestres, "Value", "Text");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? idNiveau, int? idFiliere)
        {
            if (idNiveau != null)
            {
                IdNiv = (int)idNiveau;
                Module.NiveauID = (int)idNiveau;
            }
            if (idFiliere != null)
            {
                IdFil = (int)idFiliere;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Module).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(Module.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { idFiliere = IdFil, idNiveau = IdNiv });
        }

        private bool ModuleExists(int id)
        {
            return _context.Modules.Any(e => e.ID == id);
        }
    }
}
