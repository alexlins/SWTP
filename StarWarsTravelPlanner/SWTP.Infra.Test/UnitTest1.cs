using System;
using Xunit;

namespace SWTP.Infra.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var s = "oi";
            Assert.Equal("oi", s);
        }
    }
}
