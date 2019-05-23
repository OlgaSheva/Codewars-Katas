using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strings_Mix;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void test1()
        {
            Assert.AreEqual("2:eeeee/2:yy/=:hh/=:rr", Mixing.Mix("Are they here", "yes, they are here"));
            
        }

        [TestMethod]
        public void test2()
        {
            Assert.AreEqual("1:ooo/1:uuu/2:sss/=:nnn/1:ii/2:aa/2:dd/2:ee/=:gg",
                    Mixing.Mix("looping is fun but dangerous", "less dangerous than coding"));
            
        }

        [TestMethod]
        public void test3()
        {
            Assert.AreEqual("1:aaa/1:nnn/1:gg/2:ee/2:ff/2:ii/2:oo/2:rr/2:ss/2:tt",
                    Mixing.Mix(" In many languages", " there's a pair of functions"));
        }

        [TestMethod]
        public void test4()
        {
            Assert.AreEqual("1:ee/1:ll/1:oo", Mixing.Mix("Lords of the Fallen", "gamekult"));
        }

        [TestMethod]
        public void test5()
        {
            Assert.AreEqual("", Mixing.Mix("codewars", "codewars"));
        }

        [TestMethod]
        public void test6()
        {
            Assert.AreEqual("1:nnnnn/1:ooooo/1:tttt/1:eee/1:gg/1:ii/1:mm/=:rr",
                    Mixing.Mix("A generation must confront the looming ", "codewarrs"));
        }
    }
}
