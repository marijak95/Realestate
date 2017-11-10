using Microsoft.EntityFrameworkCore;
using Realestate_website.Data.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Realestate_website.Models
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<User> Users { get; set; }

        public UserViewModel(DbSet<User> users)
        {

            Users = new List<User>();


            foreach (var user in users)
            {
                var us = new User()
                {
                    ID = user.ID,
                    Email = user.Email,
                    Password = user.Password

                };

                Users.Add(user);
            }

           
            }
        }

    }
