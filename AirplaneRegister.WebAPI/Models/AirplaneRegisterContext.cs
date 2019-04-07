using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneRegister.WebAPI.Models
{
    public class AirplaneRegisterContext : DbContext
    {
        public AirplaneRegisterContext(DbContextOptions<AirplaneRegisterContext> options) : base(options)
        {

        }

        public DbSet<AirplaneRegister> AirplaneRegisters { get; set; }
        public DbSet<AirplaneTypes> AirplaneTypes { get; set; }
    }
}
