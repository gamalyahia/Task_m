using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_mangment_system.Models;

namespace Task_mangment_system.Controllers
{
    public class TeamMemberController : Controller
    {
        private readonly AppDbContext _context;
        public TeamMemberController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.teamMembers.ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeamMember teamMember)
        {
            await _context.teamMembers.AddAsync(teamMember);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            return View(await _context.teamMembers.Include(x =>x.Tasks).FirstOrDefaultAsync(x =>x.TeamMemberId == id));
        }
        public async Task<IActionResult> Update(int id)
        {
            return View(await _context.teamMembers.FirstOrDefaultAsync(x => x.TeamMemberId == id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(TeamMember teamMember)
        {
            _context.Update(teamMember);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _context.teamMembers.FirstOrDefaultAsync(x => x.TeamMemberId == id));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(TeamMember teamMember)
        {                            
            _context.teamMembers.Remove(teamMember);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
