using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gestion_Scolarite.Models;
using Gestion_Scolarite.Data;

namespace Gestion_Scolarite.Pages.Matieres
{
    public class CreateModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public CreateModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int IdMod { get; set; }

        [BindProperty]
        public int IdNiv { get; set; }

        [BindProperty]
        public int IdFil { get; set; }

        public IActionResult OnGet(int? idModule, int? idNiveau, int? idFiliere)
        {
            if (idModule != null)
            {
                IdMod = (int)idModule;
            }
            if (idNiveau != null)
            {
                IdNiv = (int)idNiveau;
            }
            if (idFiliere != null)
            {
                IdFil = (int)idFiliere;
            }

            var enseignants = _context.Enseignants
                .Select(e => new
                {
                    ID = e.ID,
                    FullName = e.Nom + " " + e.Prenom
                })
                .ToList();

            ViewData["EnseignantID"] = new SelectList(enseignants, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Matiere Matiere { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int? idModule, int? idNiveau, int? idFiliere)
        {
            if (idModule != null)
            {
                IdMod = (int)idModule;
                Matiere.ModuleID = (int)idModule;
            }
            if (idNiveau != null)
            {
                IdNiv = (int)idNiveau;
            }
            if (idFiliere != null)
            {
                IdFil = (int)idFiliere;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Matieres.Add(Matiere);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { idFiliere = IdFil, idNiveau = IdNiv, idModule = IdMod });
        }
    }
}
