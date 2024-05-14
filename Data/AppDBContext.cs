using Microsoft.EntityFrameworkCore;
using System;

namespace InMemoryCaching.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }


    }
}
