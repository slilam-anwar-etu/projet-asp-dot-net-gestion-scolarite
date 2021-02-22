using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gestion_Scolarite.Models;
using Gestion_Scolarite.Data;

namespace Gestion_Scolarite.Pages.Seances
{
    public class CreateModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public CreateModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int IdMat { get; set; }

        [BindProperty]
        public int IdMod { get; set; }

        [BindProperty]
        public int IdNiv { get; set; }

        [BindProperty]
        public int IdFil { get; set; }

        public List<SelectListItem> Types { get; set; }
        public IActionResult OnGet(int? idModule, int? idNiveau, int? idFiliere, int? idMatiere)
        {
            if (idMatiere != null)
            {
                IdMat = (int)idMatiere;
            }
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
            Types = new List<SelectListItem>
            {
                new SelectListItem{ Text="Cours", Value = "Cours", Selected = true },
                new SelectListItem{ Text="TD", Value = "TD" },
                new SelectListItem{ Text="TP", Value = "TP" },
            };
            ViewData["Type"] = new SelectList(Types, "Value", "Text");
            return Page();
        }

        [BindProperty]
        public Seance Seance { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int? idModule, int? idNiveau, int? idFiliere, int? idMatiere)
        {
            if (idMatiere != null)
            {
                IdMat = (int)idMatiere;
                Seance.MatiereID = (int)idMatiere;
            }
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Seances.Add(Seance);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { idFiliere = IdFil, idNiveau = IdNiv, idModule = IdMod, idMatiere = IdMat });
        }
    }
}
