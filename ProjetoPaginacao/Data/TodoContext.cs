using Microsoft.EntityFrameworkCore;
using ProjetoPaginacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPaginacao.Data
{
    public class TodoContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=TodoDB;Data Source=DESKTOP-B9OTT3O\\SQLEXPRESS;");
        }

        public DbSet<Todo> Todo { get; set; } 
    }
}
