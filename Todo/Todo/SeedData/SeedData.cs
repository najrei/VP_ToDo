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
                        BeschreibungText = "Kurz",
                        Erledigt = false,
                        AbgabeTime = DateTime.Parse("2022-06-09")
          
                    },
                    new Aufgabe
                    {
                        BeschreibungText = "Wohungs Saugen",
                        Erledigt = false,
                        AbgabeTime = DateTime.Parse("2022-06-10")
                    },
                    new Aufgabe
                    {
                        BeschreibungText = "Einkaufen gehen",
                        Erledigt = true,
                        AbgabeTime = DateTime.Parse("2022-06-10")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}


