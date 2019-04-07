using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using AirplaneRegister.WebAPI.Models;
using System.Collections.Generic;

namespace AirplaneRegister.xUnit
{
    public class UnitTest : IUnitTest
    {
        private AirplaneRegisterContext _ctx;
        private DbContextOptionsBuilder<AirplaneRegisterContext> _builder;

        public UnitTest()
        {
            _builder = new DbContextOptionsBuilder<AirplaneRegisterContext>().UseInMemoryDatabase();
            _ctx = new AirplaneRegisterContext(_builder.Options);
        }

        [Fact]
        public void Add()
        {
            AirplaneRegister.WebAPI.Models.AirplaneRegister airplane = new AirplaneRegister.WebAPI.Models.AirplaneRegister { AirplaneTypeId = 1, Capacity = 100 };
            _ctx.AirplaneRegisters.Add(airplane);
            int changed = _ctx.SaveChanges();
            Assert.Equal(1, changed);
        }

        [Fact]
        public void Delete()
        {
            AirplaneRegister.WebAPI.Models.AirplaneRegister airplane = _ctx.AirplaneRegisters.Find(1);
            _ctx.AirplaneRegisters.Remove(airplane);
            int changed = _ctx.SaveChanges();
            Assert.Equal(1, changed);
        }
    }
}
