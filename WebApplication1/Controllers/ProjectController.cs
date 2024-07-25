using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Diagnostics;

namespace Project.Controllers
{
    public class ProjectController : Controller
    {
        public ProjectDbContext _context;

        public ProjectController(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Set<project>().ToListAsync());
        }
        public async Task<IActionResult> AddEdit(int id)
        {
            project student = new project();
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(project project)
        {
            await _context.AddAsync(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
