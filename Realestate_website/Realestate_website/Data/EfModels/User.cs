
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Realestate_website.Data.EfModels
{
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        

        public User(){

        }

        


    }
}
