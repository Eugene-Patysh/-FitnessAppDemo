using FitnessAppDemo.Auth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessAppDemo.Auth
{
    public class UserContext : IdentityDbContext<User>
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
