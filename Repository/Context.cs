using Domain.Entity;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<SimulacaoCompra> SimulacaoCompra { get; set; }
        public DbSet<ParcelasCompra> ParcelasCompra { get; set; }
    }
}
