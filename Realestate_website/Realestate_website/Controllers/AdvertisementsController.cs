using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Realestate_website.Data;
using Realestate_website.Data.EfModels;
using Realestate_website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;

namespace Realestate_website.Controllers
{
    public class AdvertisementsController : Controller
    {
        private readonly AdContext _context;
        private static string _userName;
        private readonly IHostingEnvironment _hostingEnvironment;


        public object Reporter { get; private set; }
        public object ToolsStrings { get; private set; }

        public AdvertisementsController(AdContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userName = httpContextAccessor.HttpContext.User.Identity.Name;
        }

        [Authorize]
        // GET: Advertisements
        public async Task<IActionResult> Index()
        {
            var advertisements = _context.Advertisements;
            var model = new PutAdViewModel(advertisements);
            //model.UserID = _userName;
            return View("~/Views/Home/Ads.cshtml", model);
        }

        // GET: Advertisements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Advertisements.SingleOrDefaultAsync(m => m.ID == id);
            if (advertisement == null)
            {
                return NotFound();
            }

            var comments = from c in _context.Comments
                           select c;
            comments = comments.Where(c => c.AdvertisementID == id);

            if (comments == null)
            {
                return NotFound();
            }

            var model = new PutAdViewModel(advertisement, comments);
            return View(model);
        }


        [Authorize]
        // GET: Advertisements/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID");
            return View();
        }

        // POST: Advertisements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]                                  //"ID,UserId,City,Area,Address,Description,Studio,OneRoom,TwoRooms,ThreeRooms,Price,Contact,Date, Apartment
        public async Task<IActionResult> Create([Bind("ID,UserId,City,Area,Address,Description,Studio,OneRoom,TwoRooms,ThreeRooms,Price,Contact,Date")] Advertisement advertisement)
        {
          
            if (ModelState.IsValid)
            {

                advertisement.UserID = _userName;
                advertisement.Date = DateTime.Now;              
                _context.Add(advertisement);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", advertisement.UserID);
            return View(advertisement);
        }

        //GET: Advertisements/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var advertisement = await _context.Advertisements.SingleOrDefaultAsync(m => m.ID == id);
            if (advertisement == null)
            {
                return NotFound();
            }

            if (advertisement.UserID != _userName)
            {
                return RedirectToAction("Index");
            }

            //if (advertisement.UserID != _userName)
            //{
            //    return RedirectToAction("Warning");
            //}

            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", advertisement.UserID);
            return View(advertisement);
        }

        //POST: Advertisements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,City,Area,Address,Description,Studio,OneRoom,TwoRooms,ThreeRooms,Price,Contact,Date")] Advertisement advertisement)
        {
            if (id != advertisement.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (advertisement.UserID==_userName)
                    {
                        advertisement.UserID = _userName;
                        advertisement.Date = DateTime.Now;
                        _context.Update(advertisement);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        //warning
                        //Reporter.Error.WriteLine(ToolsStrings.DesktopCommandsRequiresWindows(framework.GetShortFolderName());
                        return RedirectToAction("Index");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvertisementExists(advertisement.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", advertisement.UserID);
            return View(advertisement);
        }

        // GET: Advertisements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advertisement = await _context.Advertisements
                .SingleOrDefaultAsync(m => m.ID == id);
            if (advertisement == null)
            {
                return NotFound();
            }

            return View(advertisement);
        }

        // POST: Advertisements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advertisement = await _context.Advertisements.SingleOrDefaultAsync(m => m.ID == id);
            _context.Advertisements.Remove(advertisement);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AdvertisementExists(int id)
        {
            return _context.Advertisements.Any(e => e.ID == id);
        }

       public IActionResult Warning()
        {
            return View();
        }


       




    }
}
