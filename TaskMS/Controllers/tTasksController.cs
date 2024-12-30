using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskMS.Models;
using TaskMS.ViewModel;

namespace TaskMS.Controllers
{
    public class tTasksController : Controller
    {
        private readonly AppDbContext _context;

        public tTasksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: tTasks
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.taskk.Include(t => t.teamMember);
            return View(await appDbContext.ToListAsync());
        }

        // GET: tTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tTask = await _context.taskk
                .Include(t => t.teamMember)
                .FirstOrDefaultAsync(m => m.TaskID == id);
            if (tTask == null)
            {
                return NotFound();
            }

            return View(tTask);
        }

        // GET: tTasks/Create
        public async Task<IActionResult> Create()
        {
            var model = new TaskViewModel
            {
                projectts = await _context.projject.ToListAsync(),
                teamMembers = await _context.teammember.ToListAsync(),
            };

            return View(model);
        }

        // POST: tTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(TaskViewModel vm)
        {
            
                var mo = new tTask()
                {
                    TaskTitle = vm.title,
                    TaskDescription = vm.description,
                    TaskStatus = vm.status,
                    TaskPriority = vm.priority,
                    DeadLine = vm.DeadLine,
                    TeamMemberId = vm.memberid,
                    ProjectId = vm.projectid,
                };

                _context.Add(mo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            

        }

        // GET: tTasks/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var fi = await _context.taskk.FirstOrDefaultAsync(x => x.TaskID == id);

            TaskViewModel vm = new TaskViewModel
            {
                title = fi.TaskTitle,
                description = fi.TaskDescription,
                status = fi.TaskStatus,
                priority = fi.TaskPriority,
                DeadLine = fi.DeadLine,
                projectts = await _context.projject.ToListAsync(),
                teamMembers = await _context.teammember.ToListAsync(),
                projectid = fi.ProjectId,
                memberid = fi.TeamMemberId,
            };

            return View(vm);
        }

        // POST: tTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskViewModel taskk)
        {
           var t = await _context.taskk.FirstOrDefaultAsync(t => t.TaskID == id);
            if (t == null)
            {
                return NotFound(); 
            }
            t.TaskTitle = taskk.title;
            t.TaskStatus = taskk.status;
            t.TaskPriority = taskk.priority;
            t.DeadLine = taskk.DeadLine;
            t.TaskDescription = taskk.description;
            t.ProjectId = taskk.projectid;
            t.TeamMemberId = taskk.memberid;

            _context.Update(t);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: tTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tTask = await _context.taskk
                .Include(t => t.teamMember)
                .FirstOrDefaultAsync(m => m.TaskID == id);
            if (tTask == null)
            {
                return NotFound();
            }

            return View(tTask);
        }

        // POST: tTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tTask = await _context.taskk.FindAsync(id);
            if (tTask != null)
            {
                _context.taskk.Remove(tTask);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tTaskExists(int id)
        {
            return _context.taskk.Any(e => e.TaskID == id);
        }
    }
}
