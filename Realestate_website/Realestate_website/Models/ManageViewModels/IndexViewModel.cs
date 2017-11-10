using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Realestate_website.Data.EfModels;
using Microsoft.EntityFrameworkCore;

namespace Realestate_website.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }

        public IList<UserLoginInfo> Logins { get; set; }

        public string PhoneNumber { get; set; }

        public bool TwoFactor { get; set; }

        public bool BrowserRemembered { get; set; }


        public string City { get; set; }

        public string Description { get; set; }

        public string Area { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        public int ID { get; set; }

        public int Price { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "Studio")]
        public bool Studio { get; set; }

        [Display(Name = "One room")]
        public bool OneRoom { get; set; }

        [Display(Name = "Two rooms")]
        public bool TwoRooms { get; set; }

        [Display(Name = "Three rooms")]
        public bool ThreeRooms { get; set; }

        [Display(Name = "By the price - descending")]
        public bool PriceDesc { get; set; }

        [Display(Name = "By the price")]
        public bool PriceAsc { get; set; }

        [Display(Name = "By the date")]
        public bool ByDate { get; set; }

        public string Search { get; set; }

        public List<Advertisement> Advertisements { get; set; }

        public IndexViewModel()
        {


        }

        public IndexViewModel(DbSet<Advertisement> advertisements)
        {

            Advertisements = new List<Advertisement>();

            foreach (var a in advertisements)
            {
                var add = new Advertisement()
                {
                    Address = a.Address,
                    Area = a.Area,
                    ID = a.ID,
                    Date = a.Date,
                    City = a.City,
                    Price = a.Price,
                    Contact = a.Contact,
                    Description = a.Description,
                    OneRoom = a.OneRoom,
                    TwoRooms = a.TwoRooms,
                    ThreeRooms = a.ThreeRooms,
                    Studio = a.Studio,
                    UserID = a.UserID
                };


                Advertisements.Add(add);
            }
        }

    }
}
