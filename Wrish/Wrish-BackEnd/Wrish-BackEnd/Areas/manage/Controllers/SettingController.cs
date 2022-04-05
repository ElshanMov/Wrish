using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Helper;
using Wrish_BackEnd.Models;

namespace Wrish_BackEnd.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class SettingController : Controller
    {
        DataContext _context;
        IWebHostEnvironment _env;

        public SettingController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index(int page = 1)
        {
            var query = _context.Settings.AsQueryable();
            ViewBag.SelectedPage = page;
            return View(PagenatedList<Setting>.Create(query, page, 8));
        }


        public IActionResult Edit(int id)
        {
            Setting setting = _context.Settings.FirstOrDefault(x => x.Id == id);
            if (setting == null)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(setting);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(Setting setting)
        {
            Setting existSetting = _context.Settings.FirstOrDefault(x => x.Id == setting.Id);
            if (existSetting==null)
            {
                return RedirectToAction("notfound", "error");
            }

            if (setting.ImageFile!=null)
            {
                if (setting.ImageFile.Length> 2097152)
                {
                    ModelState.AddModelError("Value", "ImageFile max size is 2MB");
                }
                else if (setting.ImageFile.ContentType != "image/jpeg" && setting.ImageFile.ContentType != "image/png" && setting.ImageFile.ContentType != "image/jpg")
                {
                    ModelState.AddModelError("Value", "The file type is incorrect");
                }

                FileManager.Delete(_env.WebRootPath, "uploads/settings", existSetting.Value);
                existSetting.Value = FileManager.Save(_env.WebRootPath, "uploads/settings", setting.ImageFile);

            }
            else
            {
                existSetting.Value = setting.Value;
            }
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
