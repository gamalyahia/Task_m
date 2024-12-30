using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_mangment_system.Models;

namespace Task_mangment_system.Controllers
{
    public class ProjectController : Controller
    {
        public  AppDbContext _context;
        public ProjectController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projects.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _context.Projects.Include(x => x.Tasks).ThenInclude(x => x.teamMember).FirstOrDefaultAsync(x =>x.ProjectID == id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            await _context.AddAsync(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            return View( await _context.Projects.FirstOrDefaultAsync(x => x.ProjectID == id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(Project project)
        {
             _context.Update(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _context.Projects.FirstOrDefaultAsync(x => x.ProjectID == id));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Project project)
        {
            
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
