using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestion_Scolarite.Models;
using Gestion_Scolarite.Data;

namespace Gestion_Scolarite.Pages.Seances
{
    public class IndexModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public IndexModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        public IList<Seance> Seance { get;set; }

        public Matiere Matiere { get; set; }
        [BindProperty]
        public int IdMat { get; set; }

        [BindProperty]
        public int IdMod { get; set; }

        [BindProperty]
        public int IdNiv { get; set; }

        [BindProperty]
        public int IdFil { get; set; }

        public async Task OnGetAsync(int? idModule, int? idNiveau, int? idFiliere, int? idMatiere)
        {
            Seance = await _context.Seances
                .Include(s => s.Matiere).ToListAsync();
            if (idMatiere != null)
            {
                Seance = Seance.Where(e => e.MatiereID == idMatiere).OrderBy(e => e.Date_Seance).ToList();
                IdMat = (int)idMatiere;
                Matiere = await _context.Matieres.FindAsync(idMatiere);
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
        }
    }
}
