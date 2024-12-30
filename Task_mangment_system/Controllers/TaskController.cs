using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Task_mangment_system.Models;
using Task_mangment_system.ViewModel;

namespace Task_mangment_system.Controllers
{
    public class TaskController : Controller
    {
        private readonly AppDbContext _context;
        public TaskController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tasks.Include(x => x.Project).Include(x => x.teamMember).ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskViewModel taskViewModel = new TaskViewModel()
            {
                projects = await _context.Projects.ToListAsync(),
                teamMembers = await _context.teamMembers.ToListAsync(),
            };
            return View(taskViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(task t)
        {
            //task ts = new task()
            //{
            //    Title = t.Title,
            //    Description = t.Description,
            //    Status = t.Status,
            //    Priority = t.Priority,
            //    Deadline = t.Deadline,
            //    ProjectID = t.ProjectID,
            //    TeamMemberId = t.TeamMemberID
            //};
            await _context.Tasks.AddAsync(t);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var t = await _context.Tasks.FirstOrDefaultAsync(x => x.TaskID == id);
            TaskViewModel taskViewModel = new TaskViewModel()
            {
                Title = t.Title,
                Description = t.Description,
                Status = t.Status,
                Priority = t.Priority,
                Deadline = t.Deadline,
                projects = await _context.Projects.ToListAsync(),
                teamMembers = await _context.teamMembers.ToListAsync(),
                ProjectID = t.ProjectID,
                TeamMemberID = t.TeamMemberId
            };
            return View(taskViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(TaskViewModel task , int id)
        {
            var t = await _context.Tasks.FirstOrDefaultAsync(x => x.TaskID == id);

            t.Title = task.Title;
            t.Description = task.Description;
            t.Status = task.Status;
            t.Priority = task.Priority;
            t.Deadline = task.Deadline;
            t.ProjectID = task.ProjectID;
            t.TeamMemberId = task.TeamMemberID;
            _context.Tasks.Update(t);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        }
}
