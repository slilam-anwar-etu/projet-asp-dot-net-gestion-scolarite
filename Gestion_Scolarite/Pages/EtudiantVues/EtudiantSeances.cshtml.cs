using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestion_Scolarite.Data;
using Gestion_Scolarite.Models;

namespace Gestion_Scolarite.Pages.EtudiantVues
{
    public class EtudiantSeancesModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public EtudiantSeancesModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        public IList<Seance> Seance { get;set; }

        public Matiere Matiere { get; set; }
        [BindProperty]
        public int IdMat { get; set; }

        [BindProperty]
        public int IdMod { get; set; }

        public async Task OnGetAsync(int? idModule, int? idMatiere)
        {
            Seance = await _context.Seances
                .Include(s => s.Matiere).ToListAsync();
            if (idMatiere != null)
            {
                Seance = Seance.Where(e => e.MatiereID == idMatiere).ToList();
                IdMat = (int)idMatiere;
                Matiere = await _context.Matieres.FindAsync(idMatiere);
            }
            if (idModule != null)
            {
                IdMod = (int)idModule;
            }
        }
    }
}
