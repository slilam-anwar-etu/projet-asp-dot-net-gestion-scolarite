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
    public class IndexModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public IndexModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        public IList<Note> Note { get;set; }

        public Matiere Matiere { get; set; }
        [BindProperty]
        public int IdMat { get; set; }

        public IList<Etudiant> Etudiant { get; set; }

        public async Task OnGetAsync(int? idMatiere)
        {
            Etudiant = await _context.Etudiants
                .Include(e => e.Niveau)
                .ToListAsync();
            Note = await _context.Notes
                .Include(n => n.Etudiant)
                .Include(n => n.Matiere).ToListAsync();
            
            if (idMatiere != null)
            {
                Note = Note.Where(e => e.MatiereID == idMatiere).ToList();
                IdMat = (int)idMatiere;
                Matiere = await _context.Matieres.FindAsync(idMatiere);

                Matiere Mat = new Matiere();
                Mat = _context.Matieres.Find(idMatiere);

                Module Mod = new Module();
                Mod = _context.Modules.Find(Mat.ModuleID);

                Niveau Niv = new Niveau();
                Niv = _context.Nivaux.Find(Mod.NiveauID);

                Etudiant = Etudiant.Where(e => e.NiveauID == Niv.ID).ToList();
            }

            foreach (Etudiant etudiant in Etudiant)
            {
                bool b = false;
                foreach (Note note in Note)
                {
                    if(etudiant.ID == note.EtudiantID)
                        b = true;
                }
                if (b == false)
                {
                    Note Note2 = new Models.Note();
                    Note2.EtudiantID = etudiant.ID;
                    Note2.MatiereID = (int)idMatiere;
                    _context.Notes.Add(Note2);
                }
                    
            }
            await _context.SaveChangesAsync();
            Note = await _context.Notes
                .Include(n => n.Etudiant)
                .Include(n => n.Matiere).ToListAsync();
            Note = Note.Where(e => e.MatiereID == idMatiere).OrderBy(n => n.Etudiant.Nom).ToList();
        }
    }
}
