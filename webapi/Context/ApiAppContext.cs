using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiRoutesResponses.Models;

namespace WebApiRoutesResponses.Context
{
    public class ApiAppContext : DbContext
    {
        public DbSet<User> users {get;set;}
        public DbSet<UserRole> userRoles {get;set;}
        public ApiAppContext(DbContextOptions<ApiAppContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            List<User> usersInitData = new List<User>();

            usersInitData.Add(new User{name="User 1",lastName="last name 1"});
            usersInitData.Add(new User{name="User 2",lastName="last name 2"});
            usersInitData.Add(new User{name="User 3",lastName="last name 3"});

            builder.Entity<User>().ToTable("User").HasData(usersInitData);
            builder.Entity<User>().HasKey(p=> p.userId);
            // builder.Entity<User>().HasOne<UserRole>("userRole");

            builder.Entity<UserRole>().ToTable("UserRole").HasKey(p=>p.userRoleId);

            List<UserRole> userRoles = new List<UserRole>();

            userRoles.Add(new UserRole{role="Admin", userId=usersInitData[0].userId});
            userRoles.Add(new UserRole{role="User", userId=usersInitData[1].userId});
            userRoles.Add(new UserRole{role="Suport", userId=usersInitData[2].userId});

           builder.Entity<UserRole>().HasData(userRoles);

           builder.Entity<UserRole>().HasOne<User>("user");

        }
    }
}