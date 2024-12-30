using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskMS.Models;

namespace TaskMS.Controllers
{
    public class ProjecttsController : Controller
    {
        private readonly AppDbContext _context;

        public ProjecttsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Projectts
        public async Task<IActionResult> Index()
        {
            return View(await _context.projject.ToListAsync());
        }

        // GET: Projectts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var li = await _context.projject.Include(x => x.tasks).ThenInclude(x => x.teamMember).FirstOrDefaultAsync(x => x.ProjectId == id);
            return View(li);
        }

        // GET: Projectts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projectts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(Projectt projectt)
        {

            _context.Add(projectt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Projectts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectt = await _context.projject.FindAsync(id);
            if (projectt == null)
            {
                return NotFound();
            }
            return View(projectt);
        }

        // POST: Projectts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Projectt projectt)
        {
            if (id != projectt.ProjectId)
            {
                return NotFound();
            }

            _context.Update(projectt);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Projectts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectt = await _context.projject
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (projectt == null)
            {
                return NotFound();
            }

            return View(projectt);
        }

        // POST: Projectts/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(Projectt proj)
        {
            var projectt = await _context.projject.FindAsync(proj.ProjectId);
            if (projectt != null)
            {
                _context.projject.Remove(projectt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool ProjecttExists(int id)
        //{
        //    return _context.projject.Any(e => e.ProjectId == id);
        //}
    }
}
