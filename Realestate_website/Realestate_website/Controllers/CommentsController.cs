using System;
using System.Collections.Generic;
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

namespace Realestate_website.Controllers
{
    public class CommentsController : Controller
    {
        private readonly AdContext _context;
        private static string _userName;

        public CommentsController(AdContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userName = httpContextAccessor.HttpContext.User.Identity.Name;
        }


        [Authorize]
        // GET: Comments
        public async Task<IActionResult> Index()
        {
            var comments = _context.Comments;

            var model = new CommentViewModel(comments);
            return View("~/Views/Comments/Index.cshtml", model);
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .SingleOrDefaultAsync(m => m.CommentID == id);
            if (comment == null)
            {
                return NotFound();
            }

            var model = new CommentViewModel(comment);
            return View(model);
        }

        // GET: Comments/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Comments/Create
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id, [Bind("CommentID,UserId,AdvertisementID,DateOfComent,Text,Like,Dislike")] Comment comment)
        {
            //if (ModelState.IsValid)
            //{
            comment.UserId = _userName;
            comment.AdvertisementID = (int)id;
            comment.DateOfComent = DateTime.Now;
            comment.Like = 0;
            comment.Dislike = 0;
            _context.Add(comment);
            await _context.SaveChangesAsync();
            // return RedirectToAction("Index");
            //}
            var comments = _context.Comments;

            var model = new CommentViewModel(comments);
            return View("~/Views/Comments/Index.cshtml", model);
        }


        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.SingleOrDefaultAsync(m => m.CommentID == id);
            if (comment == null)
            {
                return NotFound();
            }

            var model = new CommentViewModel(comment);
            return View(model);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]                            
        public async Task<IActionResult> Edit(int id, [Bind("CommentID,UserId,AdvertisementID,DateOfComent,Text,Like,Dislike")] Comment comment)
        {

           // if (comment.UserId == _userName)
            //{
                if (id != comment.CommentID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        
                        comment.UserId = _userName;
                        _context.Update(comment);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CommentExists(comment.CommentID))
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
            //}
            return View(comment);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            // if (comment.UserId == _userName)
            //{
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .SingleOrDefaultAsync(m => m.CommentID == id);
            if (comment == null)
            {
                return NotFound();
            }
            var model = new CommentViewModel(comment);
            return View(model);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // if (comment.UserId == _userName)
            //{
            var comment = await _context.Comments.SingleOrDefaultAsync(m => m.CommentID == id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.CommentID == id);
        }

        public async Task<IActionResult> Like(int? id)
        {
            var comment = await _context.Comments.SingleOrDefaultAsync(m => m.CommentID == id);
            comment.Like++;
            _context.Update(comment);
            await _context.SaveChangesAsync();

            var advertisement = await _context.Advertisements
                .SingleOrDefaultAsync(m => m.ID == comment.AdvertisementID);

            var comments = from c in _context.Comments
                           select c;

            comments = comments.Where(m => m.AdvertisementID == advertisement.ID);

            var model = new PutAdViewModel(advertisement, comments);
            //var model = comments.ToList();
            return View("~/Views/Advertisements/Details.cshtml", model);


        }

        public async Task<IActionResult> Dislike(int? id)
        {
            var comment = await _context.Comments.SingleOrDefaultAsync(m => m.CommentID == id);
            // var model = new CommentViewModel(comment);
            comment.Dislike++;
            _context.Update(comment);
            await _context.SaveChangesAsync();

            var advertisement = await _context.Advertisements
                .SingleOrDefaultAsync(m => m.ID == comment.AdvertisementID);

            var comments = from c in _context.Comments
                           select c;

            comments = comments.Where(m => m.AdvertisementID == advertisement.ID);

            var model = new PutAdViewModel(advertisement, comments);
            return View("~/Views/Advertisements/Details.cshtml", model);
        }

        public async Task<IActionResult> AddComment(string textButton, int ad_id)
        {
            Comment comment = new Comment();
            comment.UserId = _userName;
            comment.AdvertisementID = ad_id;
            comment.DateOfComent = DateTime.Now;
            comment.Like = 0;
            comment.Dislike = 0;
            comment.Text = textButton;
            _context.Add(comment);
            await _context.SaveChangesAsync();

            var comments = from c in _context.Comments
                           select c;

            comments = comments.Where(m => m.AdvertisementID == ad_id);

            var advertisement = await _context.Advertisements
                .SingleOrDefaultAsync(m => m.ID == comment.AdvertisementID);

            var listModel = comments.ToList();


            var model = new PutAdViewModel(advertisement, comments);
            //return View("~/Views/Advertisements/Details.cshtml", model);

            return PartialView("~/Views/Shared/_DetailsPartial.cshtml", listModel);
        }




    }
}
