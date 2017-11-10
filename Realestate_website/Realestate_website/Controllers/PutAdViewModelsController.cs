using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Realestate_website.Data;
using Realestate_website.Models;
using Realestate_website.Data.EfModels;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
//using System.Drawing

namespace Realestate_website.Controllers
{
    public class PutAdViewModelsController : Controller
    {
        private readonly AdContext _context;

        public PutAdViewModelsController(AdContext context)
        {
            _context = context;
        }


        // GET: PutAdViewModels
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: PutAdViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var putAdViewModel = await _context.PutAdViewModel
            //    .SingleOrDefaultAsync(m => m.ID == id);
            //if (putAdViewModel == null)
            //{
            //    return NotFound();
            //}

            return View();
        }

        // GET: PutAdViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PutAdViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, City,Area,Address,Description,Studio,OneRoom,TwoRooms,ThreeRooms,Price,Contact,Date")] PutAdViewModel putad, IFormFile upload)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(putAdViewModel);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}
            //return View(putAdViewModel);


            if (ModelState.IsValid)
            {


                //if (upload != null && upload.Length > 0)
                //{
                //    //Models.File fileIn = new Models.File();
                //    Data.EfModels.UploadImage Imagein = new UploadImage();
                //    var fileName = ContentDispositionHeaderValue.Parse(upload.ContentDisposition).FileName.Trim('"');

                //    byte[] fileBytes = null;
                //    using (var fileStream = upload.OpenReadStream())
                //    using (var ms = new MemoryStream())
                //    {
                //        fileStream.CopyTo(ms);
                //        fileBytes = ms.ToArray();
                //        //string s = Convert.ToBase64String(fileBytes);
                //        // act on the Base64 data
                //    }


                //    Imagein.Imagename = fileName;
                //    Imagein.ContentType = upload.ContentType;
                //    Imagein.Content = fileBytes;
                //    _context.Add(Imagein);
                //    await _context.SaveChangesAsync();
                //    _context.Add(Imagein);
                //}

                _context.Add(putad);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewData["ID"] = new SelectList(_context.Users, "ID", "ID", advertisement.ID);
            return View(putad);

        }

        // GET: PutAdViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            return View();
        }

        // POST: PutAdViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,City,Area,Address,Description,Price,Contact,Date,Studio,OneRoom,TwoRooms,ThreeRooms")] PutAdViewModel putAdViewModel)
        {
            if (id.ToString() != putAdViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(putAdViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PutAdViewModelExists(putAdViewModel.ID))
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
            return View(putAdViewModel);
        }

        // GET: PutAdViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var putAdViewModel = await _context.PutAdViewModel
            //    .SingleOrDefaultAsync(m => m.ID == id);
            //if (putAdViewModel == null)
            //{
            //    return NotFound();
            //}

            return View();
        }

        // POST: PutAdViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var putAdViewModel = await _context.PutAdViewModel.SingleOrDefaultAsync(m => m.ID == id);
            //_context.PutAdViewModel.Remove(putAdViewModel);
            //await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PutAdViewModelExists(string id)
        {
            return true;//_context.PutAdViewModel.Any(e => e.ID == id);
        }

    }
}
