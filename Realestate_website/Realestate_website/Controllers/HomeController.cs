using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Realestate_website.Data.EfModels;
using Microsoft.EntityFrameworkCore;
using Realestate_website.Models.ManageViewModels;
using Realestate_website.Data;
using Realestate_website.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Realestate_website.Controllers
{
    public class HomeController : Controller
    {
        private readonly AdContext _context;
        private static string _userName;

        public HomeController(AdContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userName = httpContextAccessor.HttpContext.User.Identity.Name;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListOfAdds(string search)

        {
            var adv = from a in _context.Advertisements
                      select a;
           

            if (!String.IsNullOrEmpty(search))
            {
                adv = adv.Where(a => a.City.ToUpper().Contains(search.ToUpper()));
            }

            adv = adv.OrderBy(a => a.City);
            var model = adv.ToList();
            return PartialView("~/Views/Home/_IndexPartial.cshtml", model);
        }


        public IActionResult Filter(bool studio, bool oneroom, bool tworooms, bool threerooms, bool price, bool date, string search)

        {
            var adv = from a in _context.Advertisements
                      select a;

            if (!String.IsNullOrEmpty(search))
            {
                adv = adv.Where(a => a.City.ToUpper().Contains(search.ToUpper()));
            }

            if (price)
            {
                adv = adv.OrderBy(a => a.Price);
            }
            else if (date)
            {
                adv = adv.OrderBy(a => a.Date);
            }
            else
            {
                adv = adv.OrderBy(a => a.City);
            }

            if(!studio && !oneroom && !tworooms && !threerooms)
            {
                var model1 = adv.ToList();
            }
            else
            {
                adv = adv.Where(a => a.Studio == studio && a.OneRoom == oneroom && a.TwoRooms == tworooms && a.ThreeRooms == threerooms);
            }

            var model = adv.ToList();
            return PartialView("~/Views/Home/_IndexPartial.cshtml", model);
        }




        public async Task<IActionResult> Details(int? id)
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

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return RedirectToAction("Contact");
        }

        [Authorize]
        public IActionResult Ads()
        {

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
