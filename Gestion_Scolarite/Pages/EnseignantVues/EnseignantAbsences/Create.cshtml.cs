using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gestion_Scolarite.Models;
using Gestion_Scolarite.Data;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Scolarite.Pages.EnseignantVues.EnseignantAbsences
{
    public class CreateModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public CreateModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int IdSe { get; set; }

        [BindProperty]
        public int IdMat { get; set; }

        public List<Absence> Absence2 { get; set; }
        public List<Etudiant> Etudiant2 { get; set; }

        public IActionResult OnGet(int? idMatiere, int? idSeance)
        {
            if (idSeance != null)
            {
                IdSe = (int)idSeance;
                Absence2 = _context.Absences
                    .Include(a => a.Etudiant)
                    .Where(a => a.SeanceID == idSeance)
                    .ToList();     
            }
            if (idMatiere != null)
            {
                IdMat = (int)idMatiere;

                Matiere Mat = new Matiere();
                Mat = _context.Matieres.Find(idMatiere);

                Module Mod = new Module();
                Mod = _context.Modules.Find(Mat.ModuleID);

                Niveau Niv = new Niveau();
                Niv = _context.Nivaux.Find(Mod.NiveauID);

                Etudiant2 = _context.Etudiants
                .Include(e => e.Niveau)
                .Where(e => e.NiveauID == Niv.ID)
                .ToList();
            }

            List<Etudiant> etudiants2 = new List<Etudiant>();
            foreach (var etudiant in Etudiant2)
            {
                bool b = false;
                foreach (Absence absence in Absence2)
                {
                    if (etudiant.ID == absence.EtudiantID)
                        b = true;
                }
                if (b == false)
                {
                    etudiants2.Add(etudiant);
                }
            }
            var etudiants = etudiants2
                .Select(e => new
                {
                    ID = e.ID,
                    FullName = e.Nom + " " + e.Prenom
                })
                .ToList();
            ViewData["EtudiantID"] = new SelectList(etudiants, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Absence Absence { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int? idMatiere, int? idSeance)
        {
            if (idSeance != null)
            {
                IdSe = (int)idSeance;
                Absence.SeanceID = (int)idSeance;
                Absence.Absence_Justifie = "Non";
            }
            if (idMatiere != null)
            {
                IdMat = (int)idMatiere;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _context.Absences.Add(Absence);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { idMatiere = IdMat, idSeance = IdSe });
        }
    }
}
