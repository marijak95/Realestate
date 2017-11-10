using Microsoft.EntityFrameworkCore;
using Realestate_website.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Realestate_website.Data.EfModels
{
    public class Comment
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key]
        public int CommentID { get; set; }

        public string UserId { get; set; }            //author

        public int AdvertisementID { get; set; }                 //on wich ad is the comment

        [DataType(DataType.Date)]

        public DateTime DateOfComent { get; set; }

        public string Text { get; set; }

        public int Like { get; set; }

        public int Dislike { get; set; }

        public List<Comment> Comments { get; set; }

        public Comment() 
        {



            
        }

        public Comment(DbSet<Comment> comments)
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
