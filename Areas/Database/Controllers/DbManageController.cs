using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Areas.Database.Controllers
{
    [Area("database")]
    [Route("/database-manage/{action}")]
    public class DbManageController : Controller
    {
        private readonly AppDbContext _dbcontext;

        public DbManageController(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [TempData]
        public string StatusMessage{set;get;}

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DeleteDB()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteDBAsync()
        {
            var success  =await _dbcontext.Database.EnsureDeletedAsync();
            StatusMessage = success ?"Xóa Thành công " : "không xóa được";
            return RedirectToAction(nameof(Index));
        }
         [HttpPost]
        public async Task<IActionResult> MigrateAsync()
        {
              await _dbcontext.Database.MigrateAsync();
            StatusMessage = "Update Success";
            return RedirectToAction(nameof(Index));
        }
    
    }
}