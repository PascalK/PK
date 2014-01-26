using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Linq.Expressions;
using System.Reflection;

namespace PK.Common.Reflection
{
    [TestClass]
    public class ObjectExtensionsTest
    {
        [TestClass]
        public class TheGetPropertyInfoMethod
        {
            [TestMethod]
            public void ShouldReturnMatchingPropertyInfoInstance()
            {
                DummyTestClass testObject;
                PropertyInfo expectedProperty;
                Expression<Func<DummyTestClass, string>> actualPropertySelector;
                //Arrange
                testObject = new DummyTestClass();
                actualPropertySelector = to => to.DummyProperty1;
                expectedProperty = typeof(DummyTestClass).GetProperty("DummyProperty1");
                //Act
                var actualResult = testObject.GetPropertyInfo(actualPropertySelector);
                //Assert
                actualResult.Should().SubjectProperties.Should().Equal(expectedProperty);
            }
            [TestMethod]
            public void ShouldThrowAnExceptionWhenCalledWithAFieldAsTheSelector()
            {
                DummyTestClass testObject;
                Expression<Func<DummyTestClass, string>> actualPropertySelector;
                //Arrange
                testObject = new DummyTestClass();
                actualPropertySelector = to => to.dummyField1;
                //Act
                testObject.Invoking(to => to.GetPropertyInfo(actualPropertySelector))
                    //Assert
                    .ShouldThrow<ArgumentException>();
            }
            [TestMethod]
            public void ShouldThrowAnExceptionWhenCalledWithAFunctionAsSelector()
            {
                DummyTestClass testObject;
                Expression<Func<DummyTestClass, string>> actualPropertySelector;
                //Arrange
                testObject = new DummyTestClass();
                actualPropertySelector = to => to.ToString();
                //Act
                testObject.Invoking(to => to.GetPropertyInfo(actualPropertySelector))
                    //Assert
                    .ShouldThrow<ArgumentException>();
            }
            [TestMethod]
            public void ShouldThrowAnExceptionWhenCalledWithoutASelector()
            {
                DummyTestClass testObject;
                Expression<Func<DummyTestClass, string>> actualPropertySelector;
                //Arrange
                testObject = new DummyTestClass();
                actualPropertySelector = null;
                //Act
                testObject.Invoking(to => to.GetPropertyInfo(actualPropertySelector))
                    //Assert
                    .ShouldThrow<ArgumentNullException>();
            }
        }
    }
}