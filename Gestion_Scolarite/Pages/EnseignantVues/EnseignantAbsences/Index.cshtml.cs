﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public IndexModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        public IList<Absence> Absence { get;set; }

        [BindProperty]
        public int IdSe { get; set; }

        [BindProperty]
        public int IdMat { get; set; }

        public async Task OnGetAsync(int? idMatiere, int? idSeance)
        {
            Absence = await _context.Absences
                .Include(a => a.Etudiant)
                .Include(a => a.Seance).ToListAsync();
            if (idSeance != null)
            {
                Absence = Absence.Where(e => e.SeanceID == idSeance).OrderBy(e => e.Etudiant.Nom).ToList();
                IdSe = (int)idSeance;
            }
            if (idMatiere != null)
            {
                IdMat = (int)idMatiere;
            }
        }

        public async Task<IActionResult> OnPostDownloadAsync(int? id)
        {
            var Abs = await _context.Absences
                .Include(a => a.Etudiant)
                .Include(a => a.Seance)
                   .ThenInclude(a => a.Matiere)
                .FirstOrDefaultAsync(a => a.ID == id);
            if (Abs == null)
            {
                return NotFound();
            }

            if (Abs.Fichier == null)
            {
                return Page();
            }
            else
            {
                byte[] byteArr = Abs.Fichier;
                string mimeType = "application/pdf";
                return new FileContentResult(byteArr, mimeType)
                {
                    FileDownloadName = $"Justification {Abs.Seance.Matiere.Code} {Abs.Etudiant.Nom} {Abs.Etudiant.Prenom} Seance_{Abs.Seance.Date_Seance}.pdf"
                };
            }

        }
    }
}
