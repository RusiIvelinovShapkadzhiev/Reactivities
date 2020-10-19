using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedDataToActivities (DataContext context,
            UserManager<AppUser> userManager) 
        {
            if(!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "Bob",
                        UserName = "bob",
                        Email = "bob@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Tom",
                        UserName = "tom",
                        Email = "tom@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Jane",
                        UserName = "jane",
                        Email = "jane@test.com"
                    }
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }

            if(!context.Activities.Any())
            {
                var activities = new List<Activity> 
                {
                    new Activity
                    {
                        Title = "Past Activity 1",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity 2 months ago",
                        Category = "drinks",
                        City = "London",
                        Venue = "Pub",
                    },
                    new Activity
                    {
                        Title = "Past Activity 2",
                        Date = DateTime.Now.AddMonths(-1),
                        Description = "Activity 1 month ago",
                        Category = "culture",
                        City = "Paris",
                        Venue = "Louvre",
                    },
                    new Activity
                    {
                        Title = "Future Activity 1",
                        Date = DateTime.Now.AddMonths(1),
                        Description = "Activity 1 month in future",
                        Category = "culture",
                        City = "London",
                        Venue = "Natural History Museum",
                    },
                    new Activity
                    {
                        Title = "Future Activity 2",
                        Date = DateTime.Now.AddMonths(2),
                        Description = "Activity 2 months in future",
                        Category = "music",
                        City = "London",
                        Venue = "O2 Arena",
                    },
                    new Activity
                    {
                        Title = "Future Activity 3",
                        Date = DateTime.Now.AddMonths(3),
                        Description = "Activity 3 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Another pub",
                    },
                    new Activity
                    {
                        Title = "Future Activity 4",
                        Date = DateTime.Now.AddMonths(4),
                        Description = "Activity 4 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Yet another pub",
                    },
                    new Activity
                    {
                        Title = "Future Activity 5",
                        Date = DateTime.Now.AddMonths(5),
                        Description = "Activity 5 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Just another pub",
                    },
                    new Activity
                    {
                        Title = "Future Activity 6",
                        Date = DateTime.Now.AddMonths(6),
                        Description = "Activity 6 months in future",
                        Category = "music",
                        City = "London",
                        Venue = "Roundhouse Camden",
                    },
                    new Activity
                    {
                        Title = "Future Activity 7",
                        Date = DateTime.Now.AddMonths(7),
                        Description = "Activity 2 months ago",
                        Category = "travel",
                        City = "London",
                        Venue = "Somewhere on the Thames",
                    },
                    new Activity
                    {
                        Title = "Future Activity 8",
                        Date = DateTime.Now.AddMonths(8),
                        Description = "Activity 8 months in future",
                        Category = "film",
                        City = "London",
                        Venue = "Cinema",
                    }
                };

                context.Activities.AddRange(activities);
                context.SaveChanges();
            }
        } 

        public static void SeedDataToCountries (DataContext context)
        {
            if(!context.Countries.Any())
            {
               var countries = new List <Country> 
               {
                   new Country
                   {
                       Name = "Bulgaria",
                       Population = 7800000,
                       Language = "Bulgarian",
                       Religion = "Eastern Orthodox Church",
                       Continent = "Europe",
                       Currency = "Bulgarian lev (BGN)",
                       Region = "Balkan peninsula",
                       CreatedOn = DateTime.Now,
                       Notes = "A beatiful country in the heart of the Balkans.",
                       IsPartOfEU = true,
                       TelephoneCode = "+359",
                   },
                   new Country
                   {
                       Name = "Serbia",
                       Population = 7850000,
                       Language = "Serbian",
                       Religion = "Eastern Orthodox Church",
                       Continent = "Europe",
                       Currency = "Srbski dinar (RSD)",
                       Region = "Balkan peninsula",
                       CreatedOn = DateTime.Now,
                       Notes = "A shit country.",
                       IsPartOfEU = false,
                       TelephoneCode = "+360",
                   },
                   new Country
                   {
                       Name = "Austria",
                       Population = 9000000,
                       Language = "German",
                       Religion = "Roman Catholic Church",
                       Continent = "Europe",
                       Currency = "Euro (EUR)",
                       Region = "Central Europe",
                       CreatedOn = DateTime.Now,
                       Notes = "The little cousin of Germany.",
                       IsPartOfEU = true,
                       TelephoneCode = "+459",
                   },
                   new Country
                   {
                       Name = "Italy",
                       Population = 60000000,
                       Language = "Italian",
                       Religion = "Roman Catholic Church",
                       Continent = "Europe",
                       Currency = "Euro (EUR)",
                       Region = "Southern Europe - Apennine peninsula",
                       CreatedOn = DateTime.Now,
                       Notes = "A beatiful country andvery famous cousine.",
                       IsPartOfEU = true,
                       TelephoneCode = "+687",
                   },
                   new Country
                   {
                       Name = "Spain",
                       Population = 47300000,
                       Language = "Spanish",
                       Religion = "Roman Catholic Church",
                       Continent = "Europe",
                       Currency = "Euro (EUR)",
                       Region = "Southern Europe - Iberian peninsula",
                       CreatedOn = DateTime.Now,
                       Notes = "A very nice coutry with many bulls.",
                       IsPartOfEU = true,
                       TelephoneCode = "+999",
                   },
                   new Country
                   {
                       Name = "Hungary",
                       Population = 10000000,
                       Language = "Hungarian",
                       Religion = "Christianity - mixed (Catholicism, Protestantism and other)",
                       Continent = "Europe",
                       Currency = "Forint (HUF)",
                       Region = "Central Europe",
                       CreatedOn = DateTime.Now,
                       Notes = "A beatiful country - our brothers.",
                       IsPartOfEU = true,
                       TelephoneCode = "+777",
                   },
                   new Country
                   {
                       Name = "Poland",
                       Population = 38400000,
                       Language = "Polish",
                       Religion = "Roman Catholic Church",
                       Continent = "Europe",
                       Currency = "Polish złoty (PLN)",
                       Region = "Central Europe",
                       CreatedOn = DateTime.Now,
                       Notes = "A beatiful country with very tragedic history.",
                       IsPartOfEU = true,
                       TelephoneCode = "+657",
                   },
                   new Country
                   {
                       Name = "Greece",
                       Population = 10800000,
                       Language = "Greek",
                       Religion = "Eastern Orthodox Church",
                       Continent = "Europe",
                       Currency = "Euro (EUR)",
                       Region = "South Balkan peninsula",
                       CreatedOn = DateTime.Now,
                       Notes = "A beatiful beaches and very tasty food.",
                       IsPartOfEU = true,
                       TelephoneCode = "+753",
                   },
                   new Country
                   {
                       Name = "France",
                       Population = 66000000,
                       Language = "Français",
                       Religion = "Christianity",
                       Continent = "Europe",
                       Currency = "Euro (EUR)",
                       Region = "Atlantic coast",
                       CreatedOn = DateTime.Now,
                       Notes = "A truly unique country with huge impact on the world history and culture.",
                       IsPartOfEU = true,
                       TelephoneCode = "+590",
                   },
                   new Country
                   {
                       Name = "Germany",
                       Population = 82000000,
                       Language = "German",
                       Religion = "Christianity",
                       Continent = "Europe",
                       Currency = "Euro (EUR)",
                       Region = "Central Europe",
                       CreatedOn = DateTime.Now,
                       Notes = "A very strong exported oriented economy.",
                       IsPartOfEU = true,
                       TelephoneCode = "+004",
                   }
               };

                context.Countries.AddRange(countries);
                context.SaveChanges();
            }
        }
    }
}