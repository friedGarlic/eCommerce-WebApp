using eTickets.DataAccess.Static;
using eTickets.Models;
using eTickets.Models.Models;
using eTickets.Models.Models.Enumerables;
using eTickets.Models.Models.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.DataAccess.Data
{
    public class ApplicationDBInitializer
    {
        public static void Seed(IApplicationBuilder appBuilder)
        {
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                //check if any data tables are created
                //then add the default table rows that are necessary for intializing the web pages
                if (!context.Cinemas.Any())
                {
                    //example
                    context.Cinemas.AddRange(new List<Cinema>() {
                        new Cinema()
                        {
                           Name = "Marvel Cinematic Universe", //other properties are not nullable so they need to be intialize
                           Description = "Movie about superheroes shit that disney or sony or any milking companies.",
                           Logo = "https://cdn.vectorstock.com/i/1000v/38/76/cinema-logo-movie-emblem-template-vector-19873876.jpg",
                           
                        }
                    });
                    context.SaveChanges();
                }


                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor() {
                            FullName = "1",
                            Bio = "11ds",
                            ProfilePictureUrl = "https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                        }
                    });

                    context.SaveChanges();
                }

                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer() {
                            FullName= "prod1",
                            Bio = "prod1 bio",
                            ProfilePictureUrl = "https://media.istockphoto.com/id/507995592/photo/pensive-man-looking-at-the-camera.jpg?s=1024x1024&w=is&k=20&c=FzIuZQjzVXxr42H6v89uG5lUm1SUsBBIBrYBHQOt70A="
                        }
                    });

                    context.SaveChanges();
                }

                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie() {
                                    Name = "Ghost",
                                    Description = "y",
                                    Price = 39.50,
                                    ImageUrl = "https://www.indiewire.com/wp-content/uploads/2019/12/us-1.jpg?w=758",
                                    StartDate = DateTime.Now,
                                    EndDate = DateTime.Now.AddDays(7),
                                    Category = MovieCategory.Action,
                                    CinemaId = 1,
                                    ProducerId = 1,
                        },
                        new Movie()
                        {
                                    Name = "Dead Rice",
                                    Description = "what a mommny loves death",
                                    Price = 42.00,
                                    ImageUrl = "https://i.ebayimg.com/images/g/smIAAOSw8UNkfzbS/s-l1600.webp",
                                    StartDate = DateTime.Now,
                                    EndDate = DateTime.Now.AddDays(7),
                                    Category = MovieCategory.Documentary,
                                    CinemaId = 1,
                                    ProducerId = 1,
                        },
                    });
                    context.SaveChanges();
                }

                if (!context.Actor_Movies.Any())
                {
                    context.Actor_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3,
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUserAndRoleAsync(IApplicationBuilder builder)
        {
            using(var servicescope = builder.ApplicationServices.CreateScope())
            {
                var roleManager = servicescope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                //Create Roles
                if (await roleManager.RoleExistsAsync(UserRole.Admin)){
                    await roleManager.CreateAsync(new IdentityRole(UserRole.Admin));
                }

                if (await roleManager.RoleExistsAsync(UserRole.User)){
                    await roleManager.CreateAsync(new IdentityRole(UserRole.User));
                }

                var userManager = servicescope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                var adminUser = await userManager.FindByEmailAsync("admin@etickets.com");

                if (adminUser != null)
                {
                    var adminuser = new AppUser()
                    { 
                        FullName = "Admin",
                        UserName = "admin",
                        Email = "admin@etickets.com",
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(adminuser, "k2XWkBYR@");
                    await userManager.AddToRoleAsync(adminuser, UserRole.User);
                }
            }
        }
    }
}



