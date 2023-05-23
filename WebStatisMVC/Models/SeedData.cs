/*using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebStatisMVC.Data;
using System;
using System.Linq;

namespace WebStatisMVC.Models;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new WebStatisMVCContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<WebStatisMVCContext>>());
        // Look for any movies.
        if (context.Article.Any())
        {
            return;   // DB has been seeded
        }
        context.Article.AddRange(
            new Article
            {
                Title = "When Harry Met Sally",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate",
                Excerpt = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo",
                Publish_date = DateTime.Parse("1989-2-12"),
                Author = "Sulthon",
                Time_read = 7,
                Category = "Romantic Comedy"
            },
            new Article
            {
                Title = "Ghostbusters",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate",
                Excerpt = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo",
                Publish_date = DateTime.Parse("1989-2-12"),
                Author = "Sulthon",
                Time_read = 7,
                Category = "Romantic Comedy"
            },
            new Article
            {
                Title = "Ghostbusters 2",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate",
                Excerpt = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo",
                Publish_date = DateTime.Parse("1989-2-12"),
                Author = "Sulthon",
                Time_read = 7,
                Category = "Romantic Comedy"
            }
        );
        context.SaveChanges();
    }
}*/