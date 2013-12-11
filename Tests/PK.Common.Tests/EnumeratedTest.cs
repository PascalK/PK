using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace PK.Common
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class EnumeratedTest
    {
        public EnumeratedTest()
        {
        }

        //private TestContext testContextInstance;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        //public TestContext TestContext
        //{
        //    get
        //    {
        //        return testContextInstance;
        //    }
        //    set
        //    {
        //        testContextInstance = value;
        //    }
        //}

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GettingTheEnumeratedByValueTwiceReturnsSameInstance()
        {
            //Arrange
            string actualValue = "ClosedTestEnum1Value";
            //Act
            var actual1 = ClosedTestEnumerated.Get(actualValue);
            var actual2 = ClosedTestEnumerated.Get(actualValue);
            //Assert
            actual1.Should().BeSameAs(actual2);
        }
        [TestMethod]
        public void GettingEnumeratedByValueWithNonExistentValueThrowsException()
        {
            //Arrange
            string actualValue = "NonExistentValue";
            //Act
            this.Invoking(t => 
                ClosedTestEnumerated.Get(actualValue)).ShouldThrow<InvalidOperationException>();
        }

        [TestMethod]
        public void GettingEnumeratedWithNullValueReturnsCorrectInstance()
        {
            //Arrange
            string actualValue = null;
            //Act
            var actual = NullTestEnumerated.Get(actualValue);
            //Assert
            actual.Should().BeSameAs(NullTestEnumerated.Null);
        }

        private class ClosedTestEnumerated : Enumerated<ClosedTestEnumerated, string>
        {
            private ClosedTestEnumerated(string value)
                : base(value)
            {
            }

            public static ClosedTestEnumerated TestEnum1 = new ClosedTestEnumerated("ClosedTestEnum1Value");
        }
        //private class OpenTestEnumerated : Enumerated<ClosedTestEnumerated, string>
        //{
        //    public OpenTestEnumerated(string value)
        //        : base(value)
        //    {
        //    }

        //    public static OpenTestEnumerated TestEnum1 = new OpenTestEnumerated("OpenTestEnum1Value");
        //}
        private class NullTestEnumerated : Enumerated<NullTestEnumerated, string>
        {
            public NullTestEnumerated(string value)
                : base(value)
            {
            }

            public static NullTestEnumerated Null = new NullTestEnumerated(null);
        }
    }
}