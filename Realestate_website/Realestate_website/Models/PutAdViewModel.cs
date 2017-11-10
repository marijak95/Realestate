using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Realestate_website.Data;
using Realestate_website.Data.EfModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Realestate_website.Models
{
    public class PutAdViewModel
    {
        public string ID { get; set; }
       
        public string City { get; set; }

        public string UserID { get; set; }

        [Required]
        public string Area { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Description { get; set; }
     
        public IFormFile Image { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Contact { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "Studio")]
        public bool Studio { get; set; }

        [Display(Name = "One room")]
        public bool OneRoom { get; set; }

        [Display(Name = "Two rooms")]
        public bool TwoRooms { get; set; }

        [Display(Name = "Three rooms")]
        public bool ThreeRooms { get; set; }

        public List<Advertisement> Advertisements { get; set; }

        public List<Comment> Comments { get; set; }

        //
        IHttpContextAccessor httpContextAccessor;

        public PutAdViewModel()
        {

        }

        public PutAdViewModel(DbSet<Advertisement> advertisements)
        {
            Random r = new Random();

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

        public PutAdViewModel(Advertisement advertisements)
        {
            Comments = advertisements.Comments;
            foreach(var c in Comments)
            {
                if (c.AdvertisementID == advertisements.ID)
                {
                    Comments.Add(c);
                }
            }
           
        }

        public PutAdViewModel(Advertisement advertisements, IQueryable<Comment> comments)
        {

            City = advertisements.City;
            Area = advertisements.Area;
            Address = advertisements.Address;
            Description = advertisements.Description;
            Studio = advertisements.Studio;
            OneRoom = advertisements.OneRoom;
            TwoRooms = advertisements.TwoRooms;
            ThreeRooms = advertisements.ThreeRooms;
            Price = advertisements.Price;
            Contact = advertisements.Contact;
            ID = advertisements.ID.ToString();

            Comments = new List<Comment>();
            foreach (var comment in comments)
            {
                var c = new Comment()
                {
                    AdvertisementID = comment.AdvertisementID,
                    CommentID = comment.CommentID,
                    DateOfComent = comment.DateOfComent,
                    Dislike = comment.Dislike,
                    Like = comment.Like,
                    Text = comment.Text,
                    UserId = comment.UserId
                };
                Comments.Add(c);

            }
        }

    }
}
