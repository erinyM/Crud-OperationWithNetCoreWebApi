using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using NotaTask.Models;

namespace NotaTask.Models
{
    public class UserContext:DbContext
        
    {
        
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        { }
        public DbSet<Users> Users { get; set; }
        public DbSet<PersonPhone> PersonPhones { get; set; }
       
    }

}
