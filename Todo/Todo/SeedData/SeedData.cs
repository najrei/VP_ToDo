using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo.Data;
using System;
using System.Linq;
using Todo.Models;

namespace Todo.SeedData
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TodoContext(
                serviceProvider.GetRequiredService<DbContextOptions<TodoContext>>()))
            {
                if (context.Aufgabe.Any())
                {
                    return; 
                }

                context.Aufgabe.AddRange(
                    new Aufgabe
                    {
                        BeschreibungText = "Ich bin eine Vergessene Aufgabe",
                        Erledigt = false,
                        AbgabeTime = DateTime.Parse("2022-01-09")
          
                    },
                    new Aufgabe
                    {
                        BeschreibungText = "Ich bin eine neue Aufgabe",
                        Erledigt = false,
                        AbgabeTime = DateTime.Parse("2022-10-10")
                    },
                    new Aufgabe
                    {
                        BeschreibungText = "Ich bin eine erledigte Aufgabe",
                        Erledigt = true,
                        AbgabeTime = DateTime.Parse("2022-06-10")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}


