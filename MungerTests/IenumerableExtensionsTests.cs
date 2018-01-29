using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Munger.Extensions;

namespace MungerTests
{
    [TestClass]
    public class IenumerableExtensionsTests
    {
        [TestMethod]
        public void ToBinsTests()
        {
            var lst = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};

            var binned = lst.ToBins(1);
            binned.Count.Should().Be(12);
            binned = lst.ToBins(2);
            binned.Count.Should().Be(6);
            binned = lst.ToBins(3);
            binned.Count.Should().Be(4);
            binned = lst.ToBins(4);
            binned.Count.Should().Be(3);
            binned = lst.ToBins(5);
            binned.Count.Should().Be(3);
            binned = lst.ToBins(6);
            binned.Count.Should().Be(2);
            binned = lst.ToBins(7);
            binned.Count.Should().Be(2);
            binned = lst.ToBins(12);
            binned.Count.Should().Be(1);
            binned = lst.ToBins(13);
            binned.Count.Should().Be(1);
        }
     
    }
}
