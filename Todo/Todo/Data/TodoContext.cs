using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext (DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
        
        public DbSet<Todo.Models.Aufgabe>? Aufgabe { get; set; }
    }
}
