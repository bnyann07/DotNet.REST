using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;
// using Npgsql;

namespace api.Data
{
    public class ApplicationDBContext : DbContext{
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {}
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}