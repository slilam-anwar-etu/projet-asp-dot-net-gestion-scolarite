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
    public class Index1Model : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public Index1Model(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        public Admin Admin { get; set; }

        public int? user { get; set; }

        public void OnGet()
        {
            user = HttpContext.Session.GetInt32("user");
            Admin = _context.Admins.Find(user);
        }
    }
}
