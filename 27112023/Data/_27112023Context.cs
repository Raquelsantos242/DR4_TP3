using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _27112023.Models;

namespace _27112023.Data
{
    public class _27112023Context : DbContext
    {
        public _27112023Context (DbContextOptions<_27112023Context> options)
            : base(options)
        {
        }

        public DbSet<_27112023.Models.TesteViewModel> TesteViewModel { get; set; } = default!;
    }
}
