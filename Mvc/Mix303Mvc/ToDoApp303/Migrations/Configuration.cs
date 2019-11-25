namespace ToDoApp303.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;
    using ToDoApp303.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ToDoApp303.Models.AppDbContext>
    {
        public Configuration()
        {
            //bu  alttaki iki satır Migrations'u otomatik atama yapar.
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ToDoApp303.Models.AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.Add(new Models.Category() { Name = "Deneme", CreateDate = DateTime.Now, CreatedBy = "username", UpdateDate = DateTime.Now, UpdateBy = "username" });

                var store = new UserStore<ApplicationUser>(context);
                var manager = new ApplicationUserManager(store);
                var user = new ApplicationUser() { Email = "ozcansahin099@gmail.com", UserName = "ozcansahin099@gmail.com" };
                Task<IdentityResult> task=Task.Run(()=>manager.CreateAsync(user,"ozcan1234"));
                var result = task.Result;
                context.SaveChanges();
            }
        }
    }
}
