using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Week3CodeChallenge
{
    [TestFixture]
    class Test
    {
        [Test, Timeout(10000)]
        public void testFindNPrimes6()
        {
            Assert.AreEqual(13,Program.FindNPrimes(6));
        }
        [Test, Timeout(10000)]
        public void testFindNPrimes10001()
        {
            Assert.AreEqual(104743,Program.FindNPrimes(10001));
        }
        [Test, Timeout(10000)]
        public void testCollatz()
        {
            Assert.AreEqual(837799, Program.LongestCollatzSequence());
        }
        [Test, Timeout(10000)]
        public void testEvenFibbonacciSequence5()
        {
            Assert.AreEqual(2, Program.EvenFibonacciSequencer(5));
        }
        [Test, Timeout(10000)]
        public void testEvenFibbonacciSequence50()
        {
            Assert.AreEqual(44, Program.EvenFibonacciSequencer(50));
        }
    }
}
