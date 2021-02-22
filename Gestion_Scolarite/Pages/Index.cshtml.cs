using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestion_Scolarite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Gestion_Scolarite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Gestion_Scolarite.Data.Gestion_ScolariteContext _context;

        public IndexModel(Gestion_Scolarite.Data.Gestion_ScolariteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int Role { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Msg { get; set; }

        public new List<User> User { get; set; }

        public IActionResult OnGet()
        {
            ViewData["Role"] = new SelectList(_context.Roles, "ID", "Designation");
            return Page();
        }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            ViewData["Role"] = new SelectList(_context.Roles, "ID", "Designation");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            User = _context.Users
                .Include(r => r.Role).ToList();
            bool b = false;
            foreach (User user in User)
            {
                if (Role == 1 && Role == user.RoleID && Email == user.Email && Password == user.Password)
                {
                    HttpContext.Session.SetInt32("user", user.ID);
                    b = true;
                    return RedirectToPage("/Index1");
                }

                if (Role == 2 && Role == user.RoleID && Email == user.Email && Password == user.Password)
                {
                    HttpContext.Session.SetInt32("user", user.ID);
                    b = true;
                    return RedirectToPage("/Index2");
                }

                if (Role == 3 && Role == user.RoleID && Email == user.Email && Password == user.Password)
                {
                    HttpContext.Session.SetInt32("user", user.ID);
                    b = true;
                    return RedirectToPage("/Index3");
                }
            }

            if (b == false)
            {
                Msg = "Invalid Email or Password";
            }

            return Page();
        }
    }
}
