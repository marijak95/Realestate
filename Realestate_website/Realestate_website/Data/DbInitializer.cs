using Realestate_website.Data.EfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Realestate_website.Data
{
    public class DbInitializer
    {
        public static void Initialize(AdContext context)
        {
            context.Database.EnsureCreated();       

            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{Email="email1@gmail.com", Password="pass1"},
                new User{Email="email2@gmail.com", Password="pass2"},
                new User{Email="email3@gmail.com", Password="pass3"},
                new User{Email="email4@gmail.com", Password="pass4"},
                new User{Email="email5@gmail.com", Password="pass5"},
                new User{Email="email6@gmail.com", Password="pass6"},
                new User{Email="email7@gmail.com", Password="pass7"},
                new User{Email="email8@gmail.com", Password="pass8"},
                new User{Email="email9@gmail.com", Password="pass9"},
                new User{Email="email10@gmail.com", Password="pass10"}
            };

            foreach (User u in users)
            {
                context.Users.Add(u);
            }

            context.SaveChanges();

            //var ads = new Advertisement[]
            //{
            //    new Advertisement{UserID=1, City="City1", Area="area1", Address="Address1", Description="Description1", Studio=true, OneRoom=false, TwoRooms= false, ThreeRooms = false, Price=30000, Contact="123456789", Date=DateTime.Parse("2017-09-01") },
            //    new Advertisement{UserID=1, City="City1", Area="area2", Address="Address2", Description="Description2", Studio=false, OneRoom=true, TwoRooms= false, ThreeRooms = false, Price=35000, Contact="123456789", Date=DateTime.Parse("2017-09-11") },
            //    new Advertisement{UserID=2, City="City1", Area="area3", Address="Address3", Description="Description3", Studio=false, OneRoom=false, TwoRooms= true, ThreeRooms = false, Price=40000, Contact="145556789", Date=DateTime.Parse("2017-08-01") },
            //    new Advertisement{UserID=3, City="City2", Area="area4", Address="Address4", Description="Description4", Studio=true, OneRoom=false, TwoRooms= false, ThreeRooms = false, Price=32000, Contact="123455555", Date=DateTime.Parse("2017-07-21") },
            //    new Advertisement{UserID=3, City="City2", Area="area4", Address="Address5", Description="Description5", Studio=true, OneRoom=false, TwoRooms= false, ThreeRooms = false, Price=34000, Contact="123455555", Date=DateTime.Parse("2017-07-25") },
            //    new Advertisement{UserID=3, City="City2", Area="area5", Address="Address6", Description="Description6", Studio=false, OneRoom=true, TwoRooms= false, ThreeRooms = false, Price=40000, Contact="123455555", Date=DateTime.Parse("2017-07-21") },
            //    new Advertisement{UserID=3, City="City2", Area="area6", Address="Address7", Description="Description7", Studio=false, OneRoom=false, TwoRooms= false, ThreeRooms = true, Price=60000, Contact="123455555", Date=DateTime.Parse("2017-06-27") },
            //    new Advertisement{UserID=4, City="City3", Area="area7", Address="Address8", Description="Description8", Studio=false, OneRoom=false, TwoRooms= true, ThreeRooms = false, Price=52000, Contact="111122222", Date=DateTime.Parse("2017-07-05") },
            //    new Advertisement{UserID=5, City="City2", Area="area4", Address="Address9", Description="Description9", Studio=true, OneRoom=false, TwoRooms= false, ThreeRooms = false, Price=31000, Contact="123444455", Date=DateTime.Parse("2017-10-16") },
            //    new Advertisement{UserID=6, City="City3", Area="area8", Address="Address10", Description="Description10", Studio=false, OneRoom=false, TwoRooms= true, ThreeRooms = false, Price=46000, Contact="111115555", Date=DateTime.Parse("2017-09-21") }
            //};

            var ads = new Advertisement[]
            {
                new Advertisement{UserID="1", City="City1", Area="area1", Address="Address1", Description="Description1", Studio=true, OneRoom=false, TwoRooms= false, ThreeRooms = false, Price=30000, Contact="123456789", Date=DateTime.Parse("2017-09-01") },
                new Advertisement{UserID="1", City="City1", Area="area2", Address="Address2", Description="Description2", Studio=false, OneRoom=true, TwoRooms= false, ThreeRooms = false, Price=35000, Contact="123456789", Date=DateTime.Parse("2017-09-11") },
                new Advertisement{UserID="2", City="City1", Area="area3", Address="Address3", Description="Description3", Studio=false, OneRoom=false, TwoRooms= true, ThreeRooms = false, Price=40000, Contact="145556789", Date=DateTime.Parse("2017-08-01") },
                new Advertisement{UserID="3", City="City2", Area="area4", Address="Address4", Description="Description4", Studio=true, OneRoom=false, TwoRooms= false, ThreeRooms = false, Price=32000, Contact="123455555", Date=DateTime.Parse("2017-07-21") },
                new Advertisement{UserID="3", City="City2", Area="area4", Address="Address5", Description="Description5", Studio=true, OneRoom=false, TwoRooms= false, ThreeRooms = false, Price=34000, Contact="123455555", Date=DateTime.Parse("2017-07-25") },
                new Advertisement{UserID="3", City="City2", Area="area5", Address="Address6", Description="Description6", Studio=false, OneRoom=true, TwoRooms= false, ThreeRooms = false, Price=40000, Contact="123455555", Date=DateTime.Parse("2017-07-21") },
                new Advertisement{UserID="3", City="City2", Area="area6", Address="Address7", Description="Description7", Studio=false, OneRoom=false, TwoRooms= false, ThreeRooms = true, Price=60000, Contact="123455555", Date=DateTime.Parse("2017-06-27") },
                new Advertisement{UserID="4", City="City3", Area="area7", Address="Address8", Description="Description8", Studio=false, OneRoom=false, TwoRooms= true, ThreeRooms = false, Price=52000, Contact="111122222", Date=DateTime.Parse("2017-07-05") },
                new Advertisement{UserID="5", City="City2", Area="area4", Address="Address9", Description="Description9", Studio=true, OneRoom=false, TwoRooms= false, ThreeRooms = false, Price=31000, Contact="123444455", Date=DateTime.Parse("2017-10-16") },
                new Advertisement{UserID="6", City="City3", Area="area8", Address="Address10", Description="Description10", Studio=false, OneRoom=false, TwoRooms= true, ThreeRooms = false, Price=46000, Contact="111115555", Date=DateTime.Parse("2017-09-21") }
            };

            foreach (Advertisement a in ads)
            {
                context.Advertisements.Add(a);
            }
            context.SaveChanges();

            var comments = new Comment[]
            {
                new Comment{UserId="1", AdvertisementID=5, DateOfComent=DateTime.Parse("2017-09-21"), Text="Text1", Like=2, Dislike=0},
                new Comment{UserId="4", AdvertisementID=3, DateOfComent=DateTime.Parse("2017-08-05"), Text="Text2", Like=3, Dislike=1},
                new Comment{UserId="4", AdvertisementID=10, DateOfComent=DateTime.Parse("2017-09-25"), Text="Text3", Like=1, Dislike=0},
                new Comment{UserId="5", AdvertisementID=7, DateOfComent=DateTime.Parse("2017-08-30"), Text="Text4", Like=4, Dislike=2},
                new Comment{UserId="6", AdvertisementID=3, DateOfComent=DateTime.Parse("2017-09-01"), Text="Text5", Like=0, Dislike=0},
                new Comment{UserId="7", AdvertisementID=1, DateOfComent=DateTime.Parse("2017-09-27"), Text="Text6", Like=2, Dislike=1},
                new Comment{UserId="8", AdvertisementID=1, DateOfComent=DateTime.Parse("2017-10-05"), Text="Text7", Like=1, Dislike=0},
                new Comment{UserId="8", AdvertisementID=2, DateOfComent=DateTime.Parse("2017-10-20"), Text="Text8", Like=0, Dislike=1},
                new Comment{UserId="8", AdvertisementID=4, DateOfComent=DateTime.Parse("2017-10-01"), Text="Text9", Like=3, Dislike=1},
                new Comment{ UserId="9", AdvertisementID=6, DateOfComent=DateTime.Parse("2017-10-11"), Text="Text10", Like=2, Dislike=0},
                new Comment{ UserId="10", AdvertisementID=8, DateOfComent=DateTime.Parse("2017-10-05"), Text="Text11", Like=2, Dislike=0},

            };
            foreach (Comment c in comments)
            {
                context.Comments.Add(c);
            }
            context.SaveChanges();
        }


    }
}
