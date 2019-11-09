using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Odonto.Data.EntityFramework
{
    public class DesignContextFactory : IDesignTimeDbContextFactory<Contexto>
    {
        public Contexto CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=1234;Database=odonto_teste");

            return new Contexto(optionsBuilder.Options);
        }
    }
}
