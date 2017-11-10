using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Realestate_website.Data.EfModels
{
    public class Advertisement
    {
     
        public int ID { get; set; }

        public string UserID { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Area { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        public bool Studio { get; set; }

        public bool OneRoom { get; set; }

        public bool TwoRooms { get; set; }

        public bool ThreeRooms { get; set; }


        [Required]
        
        public int Price { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public List<Comment> Comments { get; set; }
        

        public Advertisement()
        {

        }
        
        public Advertisement(DbSet<Comment> comments)
        {
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
