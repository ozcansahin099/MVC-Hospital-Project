using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDoApp303.Models
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext():base("DefCon")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Side> Sides { get; set; }
        public DbSet<Todoitem> Todoitems { get; set; }
        

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        
    }
}