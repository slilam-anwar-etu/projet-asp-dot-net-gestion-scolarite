using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gestion_Scolarite.Models;
using Gestion_Scolarite.Data;

namespace Gestion_Scolarite.Pages.Enseignants
{
    public class IndexModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public IndexModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        public IList<Enseignant> Enseignant { get;set; }

        public Departement Departement { get; set; }
        

        [BindProperty]
        public int IdDept { get; set; }

        public async Task OnGetAsync(int? idDepartement)
        {
            Enseignant = await _context.Enseignants
                .Include(e => e.Role)
                .Include(e => e.Departement).ToListAsync();
            if (idDepartement != null)
            {
                Enseignant = Enseignant.Where(e => e.DepartementID == idDepartement).ToList();
                IdDept = (int)idDepartement;
                Departement = await _context.Departements.FindAsync(idDepartement);
            }
            
        }
    }
}
