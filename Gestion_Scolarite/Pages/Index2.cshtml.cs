using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestion_Scolarite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gestion_Scolarite.Pages
{
    public class Index2Model : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public Index2Model(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        public Enseignant Enseignant { get; set; }

        public int? user { get; set; }

        public void OnGet()
        {
            user = HttpContext.Session.GetInt32("user");
            Enseignant = _context.Enseignants.Find(user);
        }
    }
}
