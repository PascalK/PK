using System;
using System.Linq;
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
        [TestClass]
        public class TheGetMethod
        {
            [TestMethod]
            public void ShouldReturnTheSameInstanceWhenCalledTwice()
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
            public void ShouldThrowAnExceptionWhenEnumeratedWithRequestedValueDoesNotExist()
            {
                //Arrange
                string actualValue = "NonExistentValue";
                //Act
                this.Invoking(t =>
                    ClosedTestEnumerated.Get(actualValue)).ShouldThrow<InvalidOperationException>();
                this.Invoking(t =>
                    ClosedTestEnumerated.Get(null)).ShouldThrow<InvalidOperationException>();
            }
            [TestMethod]
            public void ShouldReturnCorrectInstanceWhenEnumeratedValueEqualsNull()
            {
                //Arrange
                string actualValue = null;
                //Act
                var actual = NullTestEnumerated.Get(actualValue);
                //Assert
                actual.Should().BeSameAs(NullTestEnumerated.Null);
            }
        }
        [TestClass]
        public class TheGetAllFunction
        {
            [TestMethod]
            public void ShouldReturnAllExistingStaticTypes()
            {
                //Arrange
                //Act
                var actualResult = ClosedTestEnumerated.GetAll();
                //Assert
                actualResult.Count().Should().Be(2);
                actualResult.Should().Contain(ClosedTestEnumerated.TestEnum1);
                actualResult.Should().Contain(ClosedTestEnumerated.TestEnum2);
            }
        }
        private class ClosedTestEnumerated : Enumerated<ClosedTestEnumerated, string>
        {
            private ClosedTestEnumerated(string value)
                : base(value)
            {
            }

            public static ClosedTestEnumerated TestEnum1 = new ClosedTestEnumerated("ClosedTestEnum1Value");
            public static ClosedTestEnumerated TestEnum2 = new ClosedTestEnumerated("ClosedTestEnum2Value");
        }
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