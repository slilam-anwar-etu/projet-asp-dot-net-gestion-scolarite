using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gestion_Scolarite.Models;
using Gestion_Scolarite.Data;

namespace Gestion_Scolarite.Pages.Modules
{
    public class CreateModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public CreateModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int IdNiv { get; set; }

        [BindProperty]
        public int IdFil { get; set; }

        public List<SelectListItem> Semestres { get; set; }

        public IActionResult OnGet(int? idNiveau, int? idFiliere)
        {
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

            ViewData["Responsable"] = new SelectList(enseignants, "ID", "FullName");

            Semestres = new List<SelectListItem>
            {
                new SelectListItem{ Text="Semestre 1", Value = "S1", Selected = true },
                new SelectListItem{ Text="Semestre 2", Value = "S2" },
            };
            ViewData["Semestre"] = new SelectList(Semestres, "Value", "Text");
            return Page();
        }

        [BindProperty]
        public Module Module { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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

            _context.Modules.Add(Module);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { idFiliere = IdFil, idNiveau = IdNiv });
        }
    }
}
